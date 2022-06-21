using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Ultracar.API
{
    public class RequisicaoAPI
    {
        public static string URI = "http://localhost:53680/api/";

        private static string RequestGETs(string controller, string metodo, string parametro, string tipo)
        {
            var request = (HttpWebRequest)WebRequest.Create(URI + controller + "/" + metodo + "/" + parametro);
            request.Method = tipo;
            var response = (HttpWebResponse)request.GetResponse();
            var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
            return responseString;
        }

        public static string RequestGET(string controller, string metodo, string parametro)
        {
            return RequestGETs(controller, metodo, parametro, "GET");
        }

        public static string RequestDELETE(string controller, string metodo, string parametro)
        {
            return RequestGETs(controller, metodo, parametro, "DELETE");
        }

        public static string RequestPOST(string controller, string metodo, string jsonData)
        {
            var request = (HttpWebRequest)WebRequest.Create(URI + controller + "/" + metodo);
            var data = Encoding.ASCII.GetBytes(jsonData);
            request.Method = "POST";
            request.ContentType = "application/json";
            request.ContentLength = data.Length;

            using (var stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }
            var response = (HttpWebResponse)request.GetResponse();
            var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();

            return responseString;
        }

        public static string RequestPUT(string controller, string metodo, string jsonData)
        {
            var request = (HttpWebRequest)WebRequest.Create(URI + controller + "/" + metodo);
            var data = Encoding.ASCII.GetBytes(jsonData);
            request.Method = "PUT";
            request.ContentType = "application/json";
            request.ContentLength = data.Length;

            using (var stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }
            var response = (HttpWebResponse)request.GetResponse();
            var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();

            return responseString;
        }
    }
}
