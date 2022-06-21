using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Ultracar.Models;

namespace Ultracar.API
{
    public class PecaAPI
    {
        public List<Peca> ListarTodos(string controller, string metodo)
        {
            List<Peca> retorno = new List<Peca>();
            string json = RequisicaoAPI.RequestGET(controller, metodo, string.Empty);
            retorno = JsonConvert.DeserializeObject<List<Peca>>(json);
            return retorno;
        }
        public Peca RetornaPorId(string controller, int? id, string metodo)
        {
            Peca retorno = new();
            string json = RequisicaoAPI.RequestGET(controller, metodo, id.ToString());
            retorno = JsonConvert.DeserializeObject<Peca>(json);
            return retorno;
        }

        public void Inserir(Peca obj, string controller, string metodo)
        {
            string jsonData = JsonConvert.SerializeObject(obj);

            if ( obj.idPeca == 0)
            {
                RequisicaoAPI.RequestPOST(controller, metodo, jsonData);
            }
            else
            {
                RequisicaoAPI.RequestPUT(controller, metodo + "/" + obj.idPeca , jsonData);
            }
        }

        public void Excluir(string controller, string metodo, int id)
        {
            string json = RequisicaoAPI.RequestDELETE(controller, metodo + "/", id.ToString());
        }
    }
}
