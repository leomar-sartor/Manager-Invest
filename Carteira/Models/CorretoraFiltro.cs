using Carteira.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Carteira.Models
{
    public class CorretoraFiltro
    {
        public CorretoraFiltro()
        {
            Corretoras = new List<Corretora>();
        }
        public int Codigo { get; set; }
        public string Nome { get; set; }

        public List<Corretora> Corretoras { get; set; }
    }
}
