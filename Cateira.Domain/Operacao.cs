using Carteira.Domain.Enums;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Carteira.Domain
{
    public class Operacao
    {
        public Operacao() { }
        public Operacao(
            Ativo ativo,
            Corretora corretora,
            decimal quantidade,
            decimal preco,
            TipoOperacao operacao,
            DateTime data,
            decimal taxaLiquidacao = 0M,
            decimal emolumentos = 0M,
            decimal corretagem = 0M
            )
        {
            Ativo = ativo;
            Corretora = corretora;
            Quantidade = quantidade;
            PrecoUnitario = preco;
            TipoOperacao = operacao;
            Data = data;
            TaxaLiquidacao = taxaLiquidacao;
            Corretagem = corretagem;
            Emolumentos = emolumentos;
        }
        public long Id { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Quantidade { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal PrecoUnitario { get; set; }

        public TipoOperacao TipoOperacao { get; set; }

        public DateTime Data { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal TaxaLiquidacao { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Corretagem { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Emolumentos { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal SaldoCotas { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal PrecoMedioDoAtivo { get; set; }

        public Ativo Ativo { get; set; }

        public Corretora Corretora { get; set; }

        public Apuracao Apuracao { get; set; }
    }
}
