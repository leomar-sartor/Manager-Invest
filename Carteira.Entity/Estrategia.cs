using System;
using System.Collections.Generic;
using System.Text;

namespace Carteira.Entity
{
    public class Estrategia
    {
        public long Id { get; set; }

        public DateTime VigenciaInicial { get; set; }

        public DateTime VigenciaFinal { get; set; }

        //public IList<Investimento> Investimentos { get; set; }
    }
}
