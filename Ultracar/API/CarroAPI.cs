using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ultracar.Models;

namespace Ultracar.API
{
    public class CarroAPI
    {
        public List<Carro> ListarTodos(string controller, string metodo)
        {
            List<Carro> retorno = new List<Carro>();
            string json = RequisicaoAPI.RequestGET(controller, metodo, string.Empty);
            retorno = JsonConvert.DeserializeObject<List<Carro>>(json);
            return retorno;
        }
        public Carro RetornaPorId(string controller, int? id, string metodo)
        {
            Carro retorno = new();
            string json = RequisicaoAPI.RequestGET(controller, metodo, id.ToString());
            retorno = JsonConvert.DeserializeObject<Carro>(json);
            return retorno;
        }

        public void Inserir(Carro obj, string controller, string metodo)
        {
            string jsonData = JsonConvert.SerializeObject(obj);

            if ( obj.idCarro == 0)
            {
                RequisicaoAPI.RequestPOST(controller, metodo, jsonData);
            }
            else
            {
                RequisicaoAPI.RequestPUT(controller, metodo + "/" + obj.idCarro , jsonData);
            }
        }

        public void Excluir(string controller, string metodo, int id)
        {
            string json = RequisicaoAPI.RequestDELETE(controller, metodo + "/", id.ToString());
        }
    }
}
