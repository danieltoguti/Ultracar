using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Ultracar.Models;

namespace Ultracar.API
{
    public class PecaCarroAPI
    {
        public List<PecaCarro> ListarTodos(string controller, string metodo)
        {
            List<PecaCarro> retorno = new List<PecaCarro>();
            string json = RequisicaoAPI.RequestGET(controller, metodo, string.Empty);
            retorno = JsonConvert.DeserializeObject<List<PecaCarro>>(json);
            return retorno;
        }
        public PecaCarro RetornaPorId(string controller, int? id, string metodo)
        {
            PecaCarro retorno = new();
            string json = RequisicaoAPI.RequestGET(controller, metodo, id.ToString());
            retorno = JsonConvert.DeserializeObject<PecaCarro>(json);
            return retorno;
        }

        public void Inserir(PecaCarro obj, string controller, string metodo)
        {
            string jsonData = JsonConvert.SerializeObject(obj);

            if ( obj.idPecaCarro == 0)
            {
                RequisicaoAPI.RequestPOST(controller, metodo, jsonData);
            }
            else
            {
                RequisicaoAPI.RequestPUT(controller, metodo + "/" + obj.idPecaCarro , jsonData);
            }
        }

        public void Excluir(string controller, string metodo, int id)
        {
            string json = RequisicaoAPI.RequestDELETE(controller, metodo + "/", id.ToString());
        }
    }
}
