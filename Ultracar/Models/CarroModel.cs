using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ultracar.Models
{
    public class CarroModel
    {
        public Carro Carro { get; set; }
        public CarroCliente CarroCliente { get; set; }
        public List<CarroCheckin> CarroCheckinList { get; set; }
        public CarroCheckin CarroCheckin { get; set; }
        public string JsonCheckin { get; set; }
        public Diagnostico Diagnostico { get; set; }
    }

    public class Carro
    {
        public int idCarro { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Cor { get; set; }
        public int AnoFabricacao { get; set; }
        public int AnoModelo { get; set; }
    }

    public class CarroCliente
    {
        public int idCarroCliente { get; set; }
        public int idDadosPessoais { get; set; }
        public int idCarro { get; set; }
    }

    public class CarroClienteView
    {
        public int idCarroCliente { get; set; }
        public int idCarro { get; set; }
        public string Proprietario { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Cor { get; set; }
        public int AnoFabricacao { get; set; }
        public int AnoModelo { get; set; }
    }

    public class CarroCheckin
    {
        public int idCarroCheckin { get; set; }
        public int idCarroCliente { get; set; }
        public string Parte { get; set; }
        public string DescricaoCheckList { get; set; }
    }

}
