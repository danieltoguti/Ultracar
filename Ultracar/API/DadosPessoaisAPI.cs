using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Ultracar.Models;

namespace Ultracar.API
{ 
    public class DadosPessoaisAPI
    {
        public List<DadosPessoais> ListarTodos(string controller, string metodo)
        {
            List<DadosPessoais> retorno = new List<DadosPessoais>();
            string json = RequisicaoAPI.RequestGET(controller, metodo, string.Empty);
            retorno = JsonConvert.DeserializeObject<List<DadosPessoais>>(json);
            return retorno;
        }
        public DadosPessoais RetornaPorId(string controller, int? id, string metodo)
        {
            DadosPessoais retorno = new();
            string json = RequisicaoAPI.RequestGET(controller, metodo, id.ToString());
            retorno = JsonConvert.DeserializeObject<DadosPessoais>(json);
            return retorno;
        }

        public void Inserir(DadosPessoais obj, string controller, string metodo)
        {
            string jsonData = JsonConvert.SerializeObject(obj);

            if ( obj.idDadosPessoais == 0)
            {
                RequisicaoAPI.RequestPOST(controller, metodo, jsonData);
            }
            else
            {
                RequisicaoAPI.RequestPUT(controller, metodo + "/" + obj.idDadosPessoais , jsonData);
            }
        }

        public void Excluir(string controller, string metodo, int id)
        {
            string json = RequisicaoAPI.RequestDELETE(controller, metodo + "/", id.ToString());
        }
    }
}
