using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Ultracar.API;
using Ultracar.Models;

namespace Ultracar.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        
        public IActionResult Index()
        {
            DadosPessoaisAPI obj = new();
            var clientes = obj.ListarTodos("dadospessoais", "retornalistadadospessoais");
            List<SelectListItem> lista = new();
            foreach (var item in clientes)
            {
                var itemClientes = new SelectListItem
                {
                    Value = item.idDadosPessoais.ToString(),
                    Text = item.Nome,
                };
                lista.Add(itemClientes);
            }
            ViewData["Clientes"] = lista;
            return View();
        }

        public IActionResult SelecionarCarro(DadosPessoais obj)
        {
            CarroClienteAPI porid = new();
            ViewData["Carros"] = porid.RetornaPorIdPorCliente("carro", obj.idDadosPessoais, "retornalistacarroclienteporcliente");
            return View();
        }

        public IActionResult Servico(int idCarro, int idCarroCliente)
        {
            ServicoAPI todosservicos = new();
            ViewData["Servicos"] = todosservicos.RetornaPorId("servico", idCarro, "retornaservico");
            ViewData["idCarroCliente"] = idCarroCliente;
            return View();
        }

        public IActionResult SelecioneServico(ServicoModel obj)
        {
            var settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                MissingMemberHandling = MissingMemberHandling.Ignore,
                Culture = new System.Globalization.CultureInfo("pt-BR")
            };
            obj.ServicoContratadoLista = JsonConvert.DeserializeObject<List<ServicoContratado>>(obj.JsonServico, settings);
            foreach (var item in obj.ServicoContratadoLista)
            {
                item.idCarroCliente = obj.ServicoContratado.idCarroCliente;
                ServicoContratadoAPI servicos = new();
                servicos.Inserir(item, "servico", "registrarservicocontratado");
            }
            ViewData["idCarroCliente"] = obj.ServicoContratado.idCarroCliente;
            ServicoContratadoAPI lista = new();
            var contratados = lista.ListarTodosPorId("servico", obj.ServicoContratado.idCarroCliente, "retornalistaservicocontratadoporid");
            double resultado = 0;
            foreach (var item in contratados)
            {
                resultado += item.Preco;
            }
            ViewData["Total"] = resultado.ToString("C");
            return View(contratados);
        }

        public IActionResult ServicoSelecionado(int idCarroCliente)
        {
            ServicoContratadoAPI lista = new();
            var contratados = lista.ListarTodosPorId("servico", idCarroCliente, "retornalistaservicocontratadoporid");
            ViewData["idCarroCliente"] = idCarroCliente;
            double resultado = 0;
            foreach (var item in contratados)
            {
                resultado += item.Preco;
            }
            ViewData["Total"] = resultado.ToString("C");
            return View(contratados);
        }

        [HttpGet]
        public IActionResult ExcluirServicoContratado(int idServicoContratado, int idCarroCliente)
        {
            ServicoContratadoAPI excluir = new();
            excluir.Excluir("servico", "excluirservicocontratado", idServicoContratado);
            ServicoContratadoAPI lista = new();
            var contratados = lista.ListarTodosPorId("servico", idCarroCliente, "retornalistaservicocontratadoporid");
            ViewData["idCarroCliente"] = idCarroCliente;
            double resultado = 0;
            foreach (var item in contratados)
            {
                resultado += item.Preco;
            }
            ViewData["Total"] = resultado.ToString("C");

            return View("ServicoSelecionado", contratados);
        }

        public IActionResult Checkin(int idCarroCliente)
        {
            CarroClienteAPI carro = new();
            ViewData["CarroCliente"] = carro.RetornaPorIdView("carro", idCarroCliente, "retornacarroclienteporid");
            DadosPessoaisAPI obj = new();
            var clientes = obj.ListarTodos("dadospessoais", "retornalistafuncionarios");
            List<SelectListItem> lista = new();
            foreach (var item in clientes)
            {
                var itemClientes = new SelectListItem
                {
                    Value = item.idDadosPessoais.ToString(),
                    Text = item.Nome,
                };
                lista.Add(itemClientes);
            }
            ViewData["Funcionarios"] = lista;
            return View();
        }

        public IActionResult CheckList(CarroModel obj)
        {
            var settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                MissingMemberHandling = MissingMemberHandling.Ignore,
                Culture = new System.Globalization.CultureInfo("pt-BR")
            };
            obj.CarroCheckinList = JsonConvert.DeserializeObject<List<CarroCheckin>>(obj.JsonCheckin, settings);
            foreach (var item in obj.CarroCheckinList)
            {
                var itens = item.Parte.Split(":");
                item.DescricaoCheckList = itens[1];
                item.Parte = itens[0];
                item.idCarroCliente = obj.CarroCheckin.idCarroCliente;
                CarroCheckinAPI checkin = new();
                checkin.Inserir(item, "carro", "registrarcarrochecking");
            }
            obj.Diagnostico.idCarroCliente = obj.CarroCheckin.idCarroCliente;
            DiagnosticoAPI inserirDiagnostico = new();
            inserirDiagnostico.Inserir(obj.Diagnostico, "diagnostico", "registrardiagnostico");
            ViewData["idCarroCliente"] = obj.CarroCheckin.idCarroCliente;
            CarroClienteAPI carro = new();
            ViewData["CarroCliente"] = carro.RetornaPorIdView("carro", obj.CarroCheckin.idCarroCliente, "retornacarroclienteporid");
            ServicoContratadoAPI lista = new();
            ViewData["Servico"] = lista.ListarTodosPorId("servico", obj.CarroCheckin.idCarroCliente, "retornalistaservicocontratadoporid");
            return View("Diagnostico", obj.CarroCheckin.idCarroCliente);
        }

        public IActionResult Diagnostico(int idCarroCliente)
        {
            CarroClienteAPI carro = new();
            ViewData["CarroCliente"] = carro.RetornaPorIdView("carro", idCarroCliente, "retornacarroclienteporid");
            ServicoContratadoAPI listaServico = new();
            ViewData["Servico"] = listaServico.ListarTodosPorId("servico", idCarroCliente, "retornalistaservicocontratadoporid");
            DiagnosticoAPI relatoCliente = new();
            //ViewData["Comentario"] = relatoCliente.
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
