using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ultracar.Models;

namespace Ultracar.API
{ 
    public class DiagnosticoAPI
    {
        public List<Diagnostico> ListarTodos(string controller, string metodo)
        {
            List<Diagnostico> retorno = new List<Diagnostico>();
            string json = RequisicaoAPI.RequestGET(controller, metodo, string.Empty);
            retorno = JsonConvert.DeserializeObject<List<Diagnostico>>(json);
            return retorno;
        }
        public Diagnostico RetornaPorId(string controller, int? id, string metodo)
        {
            Diagnostico retorno = new();
            string json = RequisicaoAPI.RequestGET(controller, metodo, id.ToString());
            retorno = JsonConvert.DeserializeObject<Diagnostico>(json);
            return retorno;
        }

        public void Inserir(Diagnostico obj, string controller, string metodo)
        {
            string jsonData = JsonConvert.SerializeObject(obj);
            if ( obj.idDiagnostico == 0)
            {
                RequisicaoAPI.RequestPOST(controller, metodo, jsonData);
            }
            else
            {
                RequisicaoAPI.RequestPUT(controller, metodo + "/" + obj.idDiagnostico, jsonData);
            }
        }

        public void Excluir(string controller, string metodo, int id)
        {
            string json = RequisicaoAPI.RequestDELETE(controller, metodo + "/", id.ToString());
        }
    }
}
