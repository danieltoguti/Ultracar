using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Ultracar.Models;

namespace Ultracar.API
{
    public class ServicoContratadoAPI
    {
        public List<ServicoContratado> ListarTodos(string controller, string metodo)
        {
            List<ServicoContratado> retorno = new List<ServicoContratado>();
            string json = RequisicaoAPI.RequestGET(controller, metodo, string.Empty);
            retorno = JsonConvert.DeserializeObject<List<ServicoContratado>>(json);
            return retorno;
        }

        public List<ServicoContratadoView> ListarTodosPorId(string controller, int? id, string metodo)
        {
            List<ServicoContratadoView> retorno = new List<ServicoContratadoView>();
            string json = RequisicaoAPI.RequestGET(controller, metodo, id.ToString());
            retorno = JsonConvert.DeserializeObject<List<ServicoContratadoView>>(json);
            return retorno;
        }

        public ServicoContratado RetornaPorId(string controller, int? id, string metodo)
        {
            ServicoContratado retorno = new();
            string json = RequisicaoAPI.RequestGET(controller, metodo, id.ToString());
            retorno = JsonConvert.DeserializeObject<ServicoContratado>(json);
            return retorno;
        }

        public void Inserir(ServicoContratado obj, string controller, string metodo)
        {
            string jsonData = JsonConvert.SerializeObject(obj);

            if ( obj.idServicoContratado == 0)
            {
                RequisicaoAPI.RequestPOST(controller, metodo, jsonData);
            }
            else
            {
                RequisicaoAPI.RequestPUT(controller, metodo + "/" + obj.idServicoContratado, jsonData);
            }
        }

        public void Excluir(string controller, string metodo, int id)
        {
            string json = RequisicaoAPI.RequestDELETE(controller, metodo, id.ToString());
        }
    }
}
