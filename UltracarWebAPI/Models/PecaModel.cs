using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UltracarWebAPI.Models
{
    public class PecaModel
    {
    }

    public class Peca
    {
        public int idPeca { get; set; }
        public string Nome { get; set; }
        public double Preco { get; set; }
    }

    public class PecaCarro
    {
        public int idPecaCarro { get; set; }
        public int idCarro { get; set; }
        public int idPeca { get; set; }
    }
}
