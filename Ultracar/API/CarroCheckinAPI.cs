using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ultracar.Models;

namespace Ultracar.API
{
    public class CarroCheckinAPI
    {
        public List<CarroCheckin> ListarTodos(string controller, string metodo)
        {
            List<CarroCheckin> retorno = new List<CarroCheckin>();
            string json = RequisicaoAPI.RequestGET(controller, metodo, string.Empty);
            retorno = JsonConvert.DeserializeObject<List<CarroCheckin>>(json);
            return retorno;
        }
        public CarroCheckin RetornaPorId(string controller, int? id, string metodo)
        {
            CarroCheckin retorno = new();
            string json = RequisicaoAPI.RequestGET(controller, metodo, id.ToString());
            retorno = JsonConvert.DeserializeObject<CarroCheckin>(json);
            return retorno;
        }

        public void Inserir(CarroCheckin obj, string controller, string metodo)
        {
            string jsonData = JsonConvert.SerializeObject(obj);

            if ( obj.idCarroCheckin == 0)
            {
                RequisicaoAPI.RequestPOST(controller, metodo, jsonData);
            }
            else
            {
                RequisicaoAPI.RequestPUT(controller, metodo + "/" + obj.idCarroCheckin, jsonData);
            }
        }

        public void Excluir(string controller, string metodo, int id)
        {
            string json = RequisicaoAPI.RequestDELETE(controller, metodo + "/", id.ToString());
        }
    }
}
