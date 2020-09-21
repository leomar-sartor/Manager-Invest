using System;
using System.Collections.Generic;
using System.Text;

namespace Carteira.Domain
{
    public class EstrategiaInvestimento
    {
        public long Id { get; set; }

        public Estrategia Estrategia { get; set; }

        public Investimento Investimento { get; set; }

        public decimal Percentagem { get; set; }
    }
}
