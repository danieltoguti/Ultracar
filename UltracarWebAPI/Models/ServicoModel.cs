using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UltracarWebAPI.Models
{
    public class ServicoModel
    {
        public Servico Servico { get; set; }
        public ServicoPeca ServicoPeca { get; set; }
        public ServicoContratado ServicoContratado { get; set; }
        public string JsonServico { get; set; }
    }

    public class Servico
    {
        public int idServico { get; set; }
        public string Nome { get; set; }
        public double Preco { get; set; }
    }

    public class ServicoView
    {
        public int idCarro { get; set; }
        public int idServico { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Servico { get; set; }
        public string Peca { get; set; }
    }

    public class ServicoPeca
    {
        public int idServicoPeca { get; set; }
        public int idServico { get; set; }
        public int idPecaCarro { get; set; }
    }

    public class ServicoContratado
    {
        public int idServicoContratado { get; set; }
        public int idServico { get; set; }
        public int idCarroCliente { get; set; }
    }

    public class ServicoContratadoView
    {
        public int idServicoContratado { get; set; }
        public int idCarroCliente { get; set; }
        public string Cliente { get; set; }
        public string Modelo { get; set; }
        public string Marca { get; set; }
        public int AnoModelo { get; set; }
        public string Servico { get; set; }
        public double Preco { get; set; }
    }
}
