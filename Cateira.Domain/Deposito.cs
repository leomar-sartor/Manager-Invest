using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Carteira.Domain
{
    //Utilizar Herança para saques também
    public class Deposito
    {
        public Deposito() { }

        public Deposito(DateTime data, decimal valor, Corretora corretora)
        {
            Valor = valor;
            Data = data;
            Corretora = corretora;
        }

        public long Id { get; set; }
        [Display(Name = "Data")]
        public DateTime Data { get; set; }
        [Display(Name = "Valor")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Valor { get; set; }
        [Display(Name = "Acumulado")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal SaldoAcumulado { get; set; }
        public Corretora Corretora { get; set; }
    }
}
