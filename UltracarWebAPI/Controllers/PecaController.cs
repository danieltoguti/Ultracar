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
    public class PecaController : Controller
    {
        #region "Peca"
        [HttpPost]
        [Route("registrarpeca")]
        public string InserirPeca([FromBody] Peca dados)
        {
            PecaDB peca = new();
            if (peca.InserirPeca(dados))
            {
                return "Registrado com sucesso";
            }
            else
            {
                return "Falhou";
            }
        }

        [HttpPut]
        [Route("atualizarpeca")]
        public string AtualizarPeca([FromBody] Peca dados)
        {
            PecaDB peca = new();
            if (peca.AtualizarPeca(dados))
            {
                return "Registrado com sucesso";
            }
            else
            {
                return "Falhou";
            }
        }

        [HttpDelete]
        [Route("excluirpeca/{id}")]
        public string ExcluirPeca(int id)
        {
            PecaDB peca = new();
            if (peca.ExcluirPeca(id))
            {
                return "Registrado com sucesso";
            }
            else
            {
                return "Falhou";
            }
        }

        [HttpGet]
        [Route("retornapeca/{id}")]
        public Peca RetornaPeca(int id)
        {
            PecaDB peca = new();
            return peca.RetornaPeca(id);
        }

        [HttpGet]
        [Route("retornalistapeca")]
        public List<Peca> RetornaListaPeca()
        {
            PecaDB pecas = new();
            return pecas.RetornaListaPecas();
        }
        #endregion

        #region "Peca Carro"
        [HttpPost]
        [Route("registrapecacarro")]
        public string InserirPecaCarro([FromBody] PecaCarro dados)
        {
            PecaDB pecacarro = new();
            if (pecacarro.InserirPecaCarro(dados))
            {
                return "Registrado com sucesso";
            }
            else
            {
                return "Falhou";
            }

        }

        [HttpPut]
        [Route("atualizarpecacarro")]
        public string AtualizarPecaCarro([FromBody] PecaCarro dados)
        {
            PecaDB pecacarro = new();
            if (pecacarro.AtualizarPecaCarro(dados))
            {
                return "Registrado com sucesso";
            }
            else
            {
                return "Falhou";
            }
        }

        [HttpDelete]
        [Route("excluirpecacarro/{id}")]
        public string ExcluirPecaCarro(int id)
        {
            PecaDB pecacarro = new();
            if (pecacarro.ExcluirPecaCarro(id))
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
        public PecaCarro RetornaPecaCarro(int id)
        {
            PecaDB pecacarro = new();
            return pecacarro.RetornaPecaCarro(id);
        }

        [HttpGet]
        [Route("retornalistapecacarro")]
        public List<PecaCarro> RetornaListaPecaCarro()
        {
            PecaDB pecacarro = new();
            return pecacarro.RetornaListaPecaCarro();
        }
        #endregion

     }
}
