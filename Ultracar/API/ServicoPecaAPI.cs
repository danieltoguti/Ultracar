using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Ultracar.Models;

namespace Ultracar.API
{
    public class ServicoPecaAPI
    {
        public List<ServicoPeca> ListarTodos(string controller, string metodo)
        {
            List<ServicoPeca> retorno = new List<ServicoPeca>();
            string json = RequisicaoAPI.RequestGET(controller, metodo, string.Empty);
            retorno = JsonConvert.DeserializeObject<List<ServicoPeca>>(json);
            return retorno;
        }
        public ServicoPeca RetornaPorId(string controller, int? id, string metodo)
        {
            ServicoPeca retorno = new();
            string json = RequisicaoAPI.RequestGET(controller, metodo, id.ToString());
            retorno = JsonConvert.DeserializeObject<ServicoPeca>(json);
            return retorno;
        }

        public void Inserir(ServicoPeca obj, string controller, string metodo)
        {
            string jsonData = JsonConvert.SerializeObject(obj);

            if ( obj.idServicoPeca == 0)
            {
                RequisicaoAPI.RequestPOST(controller, metodo, jsonData);
            }
            else
            {
                RequisicaoAPI.RequestPUT(controller, metodo + "/" + obj.idServicoPeca, jsonData);
            }
        }

        public void Excluir(string controller, string metodo, int id)
        {
            string json = RequisicaoAPI.RequestDELETE(controller, metodo + "/", id.ToString());
        }
    }
}
