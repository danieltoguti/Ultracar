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
    public class CarroController : Controller
    {
        #region "Carro"
        // POST api/values
        [HttpPost]
        [Route("registrarcarro")]
        public string InserirCarro([FromBody] Carro dados)
        {
            CarroDB carro = new();
            if (carro.InserirCarro(dados))
            {
                return "Registrado com sucesso";
            }
            else
            {
                return "Falhou";
            }
        }

        [HttpPut]
        [Route("atualizarcarro")]
        public string AtualizarCarro([FromBody] Carro dados)
        {
            CarroDB carro = new();
            if (carro.AtualizarCarro(dados))
            {
                return "Registrado com sucesso";
            }
            else
            {
                return "Falhou";
            }
        }

        [HttpDelete]
        [Route("excluircarro/{id}")]
        public string ExcluirCarro(int id)
        {
            CarroDB carro = new();
            if (carro.ExcluirCarro(id))
            {
                return "Registrado com sucesso";
            }
            else
            {
                return "Falhou";
            }
        }

        [HttpGet]
        [Route("retornacarro/{id}")]
        public Carro RetornaCarro(int id)
        {
            CarroDB carro = new();
            return carro.RetornaCarro(id);
        }

        [HttpGet]
        [Route("retornalistacarro")]
        public List<Carro> RetornaListaCarros()
        {
            CarroDB carros = new();
            return carros.RetornaListaCarro();
        }
        #endregion

        #region "Carro Cliente"
        [HttpPost]
        [Route("registracarrocliente")]
        public string InserirCarroCliente([FromBody] CarroCliente dados)
        {
            CarroDB carrocliente = new();
            if (carrocliente.InserirCarroCliente(dados))
            {
                return "Registrado com sucesso";
            }
            else
            {
                return "Falhou";
            }

        }

        [HttpPut]
        [Route("atualizarcarrocliente")]
        public string AtualizarCarroCliente([FromBody] CarroCliente dados)
        {
            CarroDB carrocliente = new();
            if (carrocliente.AtualizarCarroCliente(dados))
            {
                return "Registrado com sucesso";
            }
            else
            {
                return "Falhou";
            }
        }

        [HttpDelete]
        [Route("excluircarrocliente/{id}")]
        public string ExcluirCarroCliente(int id)
        {
            CarroDB carrocliente = new();
            if (carrocliente.ExcluirCarroCliente(id))
            {
                return "Registrado com sucesso";
            }
            else
            {
                return "Falhou";
            }
        }


        [HttpGet]
        [Route("retornacarroclienteporid/{id}")]
        public CarroClienteView RetornaCarroClientePorId(int id)
        {
            CarroDB carrocliente = new();
            return carrocliente.RetornaCarroCliente(id);
        }

        [HttpGet]
        [Route("retornalistacarrocliente/{id}")]
        public List<CarroCliente> RetornaListaCarroCliente(int id)
        {
            CarroDB carrocliente = new();
            return carrocliente.RetornaCarrosCliente(id);
        }

        [HttpGet]
        [Route("retornalistacarroclienteporcliente/{id}")]
        public List<CarroClienteView> RetornaListaCarroClientePorCliente(int id)
        {
            CarroDB carrocliente = new();
            return carrocliente.RetornaCarrosClientePorCliente(id);
        }
        #endregion

        #region "Carro Cheking"
        [HttpPost]
        [Route("registrarcarrochecking")]
        public string InserirCarroChecking([FromBody] CarroCheckin dados)
        {

            CarroDB carrochecking = new();
            if (carrochecking.InserirCarroCheckin(dados))
            {
                return "Registrado com sucesso";
            }
            else
            {
                return "Falhou";
            }
        }

        [HttpPut]
        [Route("atualizarcarrochecking")]
        public string AtualizarCarroChecking([FromBody] CarroCheckin dados)
        {
            CarroDB carrochecking = new();
            if (carrochecking.AtualizarCarroCheckin(dados))
            {
                return "Registrado com sucesso";
            }
            else
            {
                return "Falhou";
            }
        }

        [HttpDelete]
        [Route("excluircarrochecking/{id}")]
        public string ExcluirCarroChecking(int id)
        {
            CarroDB carrochecking = new();
            if (carrochecking.ExcluirCarroCheckin(id))
            {
                return "Registrado com sucesso";
            }
            else
            {
                return "Falhou";
            }
        }

        [HttpGet]
        [Route("retornacarrochecking/{id}")]
        public CarroCheckin RetornaCarroChecking(int id)
        {
            CarroDB carrochecking = new();
            return carrochecking.RetornaCarroCheckin(id);
        }

        [HttpGet]
        [Route("retornalistacarrochecking")]
        public List<CarroCheckin> RetornaCarroChecking()
        {
            CarroDB carroschecking = new();
            return carroschecking.RetornaCarrosCheckin();
        }
        #endregion
    }
}
