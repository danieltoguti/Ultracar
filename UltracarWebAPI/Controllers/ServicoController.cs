using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UltracarWebAPI.Models;

namespace UltracarWebAPI.Data
{
    [Route("api/[controller]")]
    public class ServicoController : Controller
    {
        #region "Servico"
        [HttpPost]
        [Route("registrarservico")]
        public string InserirServico([FromBody] Servico dados)
        {
            ServicoDB servico = new();
            if (servico.InserirServico(dados))
            {
                return "Registrado com sucesso";
            }
            else
            {
                return "Falhou";
            }
        }

        [HttpPut]
        [Route("atualizarservico")]
        public string AtualizarServico([FromBody] Servico dados)
        {
            ServicoDB servico = new();
            if (servico.AtualizarServico(dados))
            {
                return "Registrado com sucesso";
            }
            else
            {
                return "Falhou";
            }
        }

        [HttpDelete]
        [Route("excluirservico/{id}")]
        public string ExcluirServico(int id)
        {
            ServicoDB servico = new();
            if (servico.ExcluirServico(id))
            {
                return "Registrado com sucesso";
            }
            else
            {
                return "Falhou";
            }
        }

        [HttpGet]
        [Route("retornaservico/{id}")]
        public List<ServicoView> RetornaServico(int id)
        {
            ServicoDB servico = new();
            return servico.RetornaServicoPorId(id);
        }

        [HttpGet]
        [Route("retornalistaservico")]
        public List<Servico> RetornaListaServico()
        {
            ServicoDB servicos = new();
            return servicos.RetornaListaServico();
        }
        #endregion

        #region "Servico Peca"
        [HttpPost]
        [Route("registraservicopeca")]
        public string InserirServicoPeca([FromBody] ServicoPeca dados)
        {
            ServicoDB servicopeca = new();
            if (servicopeca.InserirServicoPeca(dados))
            {
                return "Registrado com sucesso";
            }
            else
            {
                return "Falhou";
            }

        }

        [HttpPut]
        [Route("atualizarservicopeca")]
        public string AtualizarServicoPeca([FromBody] ServicoPeca dados)
        {
            ServicoDB servicopeca = new();
            if (servicopeca.AtualizarServicoPeca(dados))
            {
                return "Registrado com sucesso";
            }
            else
            {
                return "Falhou";
            }
        }

        [HttpDelete]
        [Route("excluirservicopeca/{id}")]
        public string ExcluirServicoPeca(int id)
        {
            ServicoDB servicopeca = new();
            if (servicopeca.ExcluirServicoPeca(id))
            {
                return "Registrado com sucesso";
            }
            else
            {
                return "Falhou";
            }
        }

        [HttpGet]
        [Route("retornacarrocliente/{id}")]
        public ServicoPeca RetornaServicoPeca(int id)
        {
            ServicoDB servicopeca = new();
            return servicopeca.RetornaServicoPeca(id);
        }

        [HttpGet]
        [Route("retornalistaservicopeca")]
        public List<ServicoPeca> RetornaListaServicoPeca()
        {
            ServicoDB servicopeca = new();
            return servicopeca.RetornaListaServicoPeca();
        }
        #endregion

        #region "Servico Contratado"
        [HttpPost]
        [Route("registrarservicocontratado")]
        public string InserirServicoContratado([FromBody] ServicoContratado dados)
        {

            ServicoDB servicocontratado = new();
            if (servicocontratado.InserirServicoContratado(dados))
            {
                return "Registrado com sucesso";
            }
            else
            {
                return "Falhou";
            }
        }

        [HttpPut]
        [Route("atualizarservicocontratado")]
        public string AtualizarServicoContratado([FromBody] ServicoContratado dados)
        {
            ServicoDB servicocontratado = new();
            if (servicocontratado.AtualizarServicoContratado(dados))
            {
                return "Registrado com sucesso";
            }
            else
            {
                return "Falhou";
            }
        }

        [HttpDelete]
        [Route("excluirservicocontratado/{id}")]
        public string ExcluirServicoContratado(int id)
        {
            ServicoDB servicocontratado = new();
            if (servicocontratado.ExcluirServicoContratado(id))
            {
                return "Registrado com sucesso";
            }
            else
            {
                return "Falhou";
            }
        }

        [HttpGet]
        [Route("retornaservicocontratado/{id}")]
        public ServicoContratado RetornaServicoContratado(int id)
        {
            ServicoDB servicocontratado = new();
            return servicocontratado.RetornaServicoContratado(id);
        }

        [HttpGet]
        [Route("retornalistaservicocontratado")]
        public List<ServicoContratado> RetornaServicoContratado()
        {
            ServicoDB servicocontratado = new();
            return servicocontratado.RetornaListaServicoContratado();
        }

        [HttpGet]
        [Route("retornalistaservicocontratadoporid/{id}")]
        public List<ServicoContratadoView> RetornaServicoContratadoPorId(int id)
        {
            ServicoDB servicocontratado = new();
            return servicocontratado.RetornaListaServicoContratadoPorId(id);
        }
        #endregion
    }
}
