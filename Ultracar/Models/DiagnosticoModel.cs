using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ultracar.Models
{
    public class DiagnosticoModel
    {
        public Diagnostico Diagnostico { get; set; }
    }

    public class Diagnostico
    {
        public int idDiagnostico { get; set; }
        public int idDadosPessoaisFuncionario { get; set; }
        public int idCarroCliente { get; set; }
        public DateTime Data { get; set; }
        public string DescricaoCliente { get; set; }
        //Contratado ou orçamento
        public string Situacao { get; set; }

    }

}
