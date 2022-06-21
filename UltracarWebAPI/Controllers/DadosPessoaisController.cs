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
    public class DadosPessoaisController : Controller
    {
        // POST api/values
        [HttpPost]
        [Route("registrardadospessoais")]
        public string InserirDadosPessoais([FromBody] DadosPessoais dados)
        {
            DadosPessoaisDB pessoa = new();
            if (pessoa.InserirDadosPessoais(dados))
            {
                return "Registrado com sucesso";
            }
            else
            {
                return "Falhou";
            }
        }

        [HttpPut]
        [Route("atualizardadospessoais")]
        public string AtualizarDadosPessoais([FromBody] DadosPessoais dados)
        {
            DadosPessoaisDB pessoa = new();
            if (pessoa.AtualizarDadosPessoais(dados))
            {
                return "Registrado com sucesso";
            }
            else
            {
                return "Falhou";
            }
        }

        [HttpDelete]
        [Route("excluirdadospessoais/{id}")]
        public string ExcluirDadosPessoais(int id)
        {
            DadosPessoaisDB pessoa = new();
            if (pessoa.ExcluirDadosPessoais(id))
            {
                return "Registrado com sucesso";
            }
            else
            {
                return "Falhou";
            }
        }

        [HttpGet]
        [Route("retornadadospessoais/{id}")]
        public DadosPessoais RetornaPessoa(int id)
        {
            DadosPessoaisDB pessoa = new();
            return pessoa.Pessoa(id);
        }

        [HttpGet]
        [Route("retornalistadadospessoais")]
        public List<DadosPessoais> RetornaListaPessoas()
        {
            DadosPessoaisDB pessoas = new();
            return pessoas.ListaPessoas();
        }

        [HttpGet]
        [Route("retornalistafuncionarios")]
        public List<DadosPessoais> RetornaListaFuncionarios()
        {
            DadosPessoaisDB pessoas = new();
            return pessoas.ListaFuncionario();
        }

        [HttpPost]
        [Route("registrarendereco")]
        public string InserirEndereco([FromBody] Endereco dados)
        {
            DadosPessoaisDB endereco = new();
            if (endereco.InserirEndereco(dados))
            {
                return "Registrado com sucesso";
            }
            else
            {
                return "Falhou";
            }

        }

        [HttpPut]
        [Route("atualizarendereco")]
        public string AtualizarEndereco([FromBody] Endereco dados)
        {
            DadosPessoaisDB endereco = new();
            if (endereco.AtualizarEndereco(dados))
            {
                return "Registrado com sucesso";
            }
            else
            {
                return "Falhou";
            }
        }

        [HttpDelete]
        [Route("excluirendereco/{id}")]
        public string ExcluirEndereco(int id)
        {
            DadosPessoaisDB endereco = new();
            if (endereco.ExcluirEndereco(id))
            {
                return "Registrado com sucesso";
            }
            else
            {
                return "Falhou";
            }
        }

        [HttpGet]
        [Route("retornaendereco/{id}")]
        public DadosPessoais RetornaEndereco(int id)
        {
            DadosPessoaisDB endereco = new();
            return endereco.RetornaEndereco(id);
        }

        [HttpGet]
        [Route("retornalistaenderecos/{id}")]
        public List<Endereco> RetornaEnderecos(int id)
        {
            DadosPessoaisDB endereco = new();
            return endereco.RetornaEnderecos(id);
        }

        [HttpPost]
        [Route("registrartipo")]
        public string InserirTipo([FromBody] Tipo dados)
        {

            DadosPessoaisDB tipo = new();
            if (tipo.InserirTipo(dados))
            {
                return "Registrado com sucesso";
            }
            else
            {
                return "Falhou";
            }
        }

        [HttpPut]
        [Route("atualizartipo")]
        public string AtualizarTipo([FromBody] Tipo dados)
        {
            DadosPessoaisDB tipo = new();
            if (tipo.AtualizarTipo(dados))
            {
                return "Registrado com sucesso";
            }
            else
            {
                return "Falhou";
            }
        }

        [HttpDelete]
        [Route("excluirtipo/{id}")]
        public string ExcluirTipo(int id)
        {
            DadosPessoaisDB tipo = new();
            if (tipo.ExcluirTipo(id))
            {
                return "Registrado com sucesso";
            }
            else
            {
                return "Falhou";
            }
        }

        [HttpGet]
        [Route("retornatipo/{id}")]
        public DadosPessoais RetornaTipo(int idTipo)
        {
            DadosPessoaisDB tipo = new();
            return tipo.RetornaTipo(idTipo);
        }

        [HttpGet]
        [Route("retornalistatipos")]
        public List<Tipo> RetornaTipos()
        {
            DadosPessoaisDB tipos = new();
            return tipos.RetornaTipos();
        }
    }
}
