using System;
using System.Collections.Generic;
using System.Text;

namespace Carteira.Service.Models
{
    public class PosicaoViewModel
    {
        public string Sigla { get; set; }
        public decimal QuantidadeCotas { get; set; }
        public decimal PrecoMedioAquisicao { get; set; }
        public decimal ValorPosicao { get; set; }

        public decimal Percentagem { get; set; }
    }
}
