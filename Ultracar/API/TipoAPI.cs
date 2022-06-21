using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Ultracar.Models;

namespace Ultracar.API
{
    public class TipoAPI
    {
        public List<Tipo> ListarTodos(string controller, string metodo)
        {
            List<Tipo> retorno = new List<Tipo>();
            string json = RequisicaoAPI.RequestGET(controller, metodo, string.Empty);
            retorno = JsonConvert.DeserializeObject<List<Tipo>>(json);
            return retorno;
        }
        public Tipo RetornaPorId(string controller, int? id, string metodo)
        {
            Tipo retorno = new();
            string json = RequisicaoAPI.RequestGET(controller, metodo, id.ToString());
            retorno = JsonConvert.DeserializeObject<Tipo>(json);
            return retorno;
        }

        public void Inserir(Tipo obj, string controller, string metodo)
        {
            string jsonData = JsonConvert.SerializeObject(obj);

            if ( obj.idTipo == 0)
            {
                RequisicaoAPI.RequestPOST(controller, metodo, jsonData);
            }
            else
            {
                RequisicaoAPI.RequestPUT(controller, metodo + "/" + obj.idTipo , jsonData);
            }
        }

        public void Excluir(string controller, string metodo, int id)
        {
            string json = RequisicaoAPI.RequestDELETE(controller, metodo + "/", id.ToString());
        }
    }
}
