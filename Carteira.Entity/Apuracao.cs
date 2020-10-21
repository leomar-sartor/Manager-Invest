using System.ComponentModel.DataAnnotations.Schema;

namespace Carteira.Entity
{
    public class Apuracao
    {
        public Apuracao(int mes, int ano, decimal valor)
        {
            Mes = mes;
            Ano = ano;
            Valor = valor;
        }
        public long Id { get; set; }

        public int Mes { get; set; }

        public int Ano { get; set; }

        public Operacao Operacao { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Valor { get; set; }
    }
}
