using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Ultracar.Models;

namespace Ultracar.API
{ 
    public class CarroClienteAPI
    {
        public List<CarroCliente> ListarTodos(string controller, string metodo)
        {
            List<CarroCliente> retorno = new List<CarroCliente>();
            string json = RequisicaoAPI.RequestGET(controller, metodo, string.Empty);
            retorno = JsonConvert.DeserializeObject<List<CarroCliente>>(json);
            return retorno;
        }

        public List<CarroCliente> ListarTodosDoCliente(string controller, int? id, string metodo)
        {
            List<CarroCliente> retorno = new List<CarroCliente>();
            string json = RequisicaoAPI.RequestGET(controller, metodo, id.ToString());
            retorno = JsonConvert.DeserializeObject<List<CarroCliente>>(json);
            return retorno;
        }
        public CarroCliente RetornaPorId(string controller, int? id, string metodo)
        {
            CarroCliente retorno = new();
            string json = RequisicaoAPI.RequestGET(controller, metodo, id.ToString());
            retorno = JsonConvert.DeserializeObject<CarroCliente>(json);
            return retorno;
        }

        public CarroClienteView RetornaPorIdView(string controller, int? id, string metodo)
        {
            CarroClienteView retorno = new();
            string json = RequisicaoAPI.RequestGET(controller, metodo, id.ToString());
            retorno = JsonConvert.DeserializeObject<CarroClienteView>(json);
            return retorno;
        }

        public List<CarroClienteView> RetornaPorIdPorCliente(string controller, int? id, string metodo)
        {
            List<CarroClienteView> retorno = new();
            string json = RequisicaoAPI.RequestGET(controller, metodo, id.ToString());
            retorno = JsonConvert.DeserializeObject<List<CarroClienteView>>(json);
            return retorno;
        }

        public void Inserir(CarroCliente obj, string controller, string metodo)
        {
            string jsonData = JsonConvert.SerializeObject(obj);

            if ( obj.idCarroCliente == 0)
            {
                RequisicaoAPI.RequestPOST(controller, metodo, jsonData);
            }
            else
            {
                RequisicaoAPI.RequestPUT(controller, metodo + "/" + obj.idCarroCliente , jsonData);
            }
        }

        public void Excluir(string controller, string metodo, int id)
        {
            string json = RequisicaoAPI.RequestDELETE(controller, metodo + "/", id.ToString());
        }
    }
}
