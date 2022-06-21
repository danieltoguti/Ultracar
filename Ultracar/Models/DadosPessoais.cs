using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ultracar.Models
{
    public class DadosPessoaisModel
    {
        public DadosPessoais DadosPessoais { get; set; }
        public Tipo Tipo { get; set; }
        public Endereco Endereco { get; set; }
    }
    public class DadosPessoais
    {
        public int idDadosPessoais { get; set; }
        public int idTipo { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Email { get; set; }
    }
    public class Tipo
    {
        public int idTipo { get; set; }
        public string Descricao { get; set; }
    }
    public class Endereco
    {
        public int idEndereco { get; set; }
        public int idDadosPessoais { get; set; }
        public string Descricao { get; set; }
        public string CEP { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }
    }
}
