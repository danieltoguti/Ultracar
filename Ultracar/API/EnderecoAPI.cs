using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ultracar.Models;

namespace Ultracar.API
{
    public class EnderecoAPI
    {
        public List<Endereco> ListarTodos(string controller, string metodo)
        {
            List<Endereco> retorno = new List<Endereco>();
            string json = RequisicaoAPI.RequestGET(controller, metodo, string.Empty);
            retorno = JsonConvert.DeserializeObject<List<Endereco>>(json);
            return retorno;
        }
        public Endereco RetornaPorId(string controller, int? id, string metodo)
        {
            Endereco retorno = new();
            string json = RequisicaoAPI.RequestGET(controller, metodo, id.ToString());
            retorno = JsonConvert.DeserializeObject<Endereco>(json);
            return retorno;
        }

        public void Inserir(Endereco obj, string controller, string metodo)
        {
            string jsonData = JsonConvert.SerializeObject(obj);
            if ( obj.idEndereco == 0)
            {
                RequisicaoAPI.RequestPOST(controller, metodo, jsonData);
            }
            else
            {
                RequisicaoAPI.RequestPUT(controller, metodo + "/" + obj.idEndereco , jsonData);
            }
        }

        public void Excluir(string controller, string metodo, int id)
        {
            string json = RequisicaoAPI.RequestDELETE(controller, metodo + "/", id.ToString());
        }
    }
}
