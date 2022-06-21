using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ultracar.Models;
using Ultracar.API;

namespace Ultracar.Controllers
{
    public class _DadosPessoaisController : Controller
    {
        public static string dadosPessoais = "dadospessoais";

        [HttpPost]
        public IActionResult RegistrarPessoa(DadosPessoais dados)
        {
            DadosPessoaisAPI pessoa = new();
            pessoa.Inserir(dados, dadosPessoais, "registrardadospessoais");
            return View();
        }
        [HttpPost]
        public IActionResult AtualizarPessoa(DadosPessoais dados)
        {
            DadosPessoaisAPI pessoa = new();
            pessoa.Inserir(dados, dadosPessoais, "atualizardadospessoais");
            return View();
        }
        public IActionResult ExcluirPessoa(int id)
        {
            DadosPessoaisAPI pessoa = new();
            pessoa.Excluir(dadosPessoais, "excluirdadospessoais", id);
            return View("ListarTodos");
        }
        public IActionResult RetornaPessoaPorId(int id)
        {
            DadosPessoaisAPI porid = new();
            var pessoa = porid.RetornaPorId(dadosPessoais, id, "retornadadospessoais");
            return View(pessoa);
        }

        public IActionResult ListarTodasPessoas()
        {
            DadosPessoaisAPI objCliente = new();
            ViewBag.ListaClientes = objCliente.ListarTodos(dadosPessoais, "retornalistadadospessoais");
            return View();
        }

        [HttpPost]
        public IActionResult RegistrarEndereco(Endereco dados)
        {
            EnderecoAPI pessoa = new();
            pessoa.Inserir(dados, dadosPessoais, "registrarendereco");
            return View();
        }
        [HttpPost]
        public IActionResult AtualizarEndereco(Endereco dados)
        {
            EnderecoAPI pessoa = new();
            pessoa.Inserir(dados, dadosPessoais, "atualizarendereco");
            return View();
        }
        public IActionResult ExcluirEndereco(int id)
        {
            EnderecoAPI pessoa = new();
            pessoa.Excluir(dadosPessoais, "excluirendereco", id);
            return View("ListarTodos");
        }
        public IActionResult RetornaEnderecoPorId(int id)
        {
            EnderecoAPI porid = new();
            var pessoa = porid.RetornaPorId(dadosPessoais, id, "retornaendereco");
            return View(pessoa);
        }
        public IActionResult ListarTodosEnderecos()
        {
            EnderecoAPI objCliente = new();
            ViewBag.ListaClientes = objCliente.ListarTodos(dadosPessoais, "retornaendereco");
            return View();
        }

        [HttpPost]
        public IActionResult RegistrarTipo(Tipo dados)
        {
            TipoAPI pessoa = new();
            pessoa.Inserir(dados, dadosPessoais, "registrartipo");
            return View();
        }
        [HttpPost]
        public IActionResult AtualizarTipo(Tipo dados)
        {
            TipoAPI pessoa = new();
            pessoa.Inserir(dados, dadosPessoais, "registrartipo");
            return View();
        }
        public IActionResult ExcluirTipo(int id)
        {
            TipoAPI pessoa = new();
            pessoa.Excluir(dadosPessoais, "excluirtipo", id);
            return View("ListarTodosTipos");
        }
        public IActionResult RetornaTipoPorId(int id)
        {
            TipoAPI porid = new();
            var pessoa = porid.RetornaPorId(dadosPessoais, id, "retornatipo");
            return View(pessoa);
        }
        public IActionResult ListarTodosTipos()
        {
            TipoAPI objCliente = new();
            ViewBag.ListaClientes = objCliente.ListarTodos(dadosPessoais, "retornatipo");
            return View();
        }
    }
}
