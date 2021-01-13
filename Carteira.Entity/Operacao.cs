using Carteira.Entity.Enuns;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Carteira.Entity
{
    public class Operacao
    {
        public Operacao() { Corretora = new Corretora(); }
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
        [Display(Name = "Código")]
        public long Id { get; set; }

        [Display(Name = "Quantidade")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Quantidade { get; set; }

        [Display(Name = "Preço Unitário")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal PrecoUnitario { get; set; }

        [Display(Name = "Compra/Venda")]
        public TipoOperacao TipoOperacao { get; set; }

        [Display(Name = "Data")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Data { get; set; }

        [Display(Name = "Taxa de Liquidação")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal TaxaLiquidacao { get; set; }

        [Display(Name = "Corretagem")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Corretagem { get; set; }

        [Display(Name = "Emolumentos")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Emolumentos { get; set; }

        [Display(Name = "Saldo")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal SaldoCotas { get; set; }

        [Display(Name = "Preço médio")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal PrecoMedioDoAtivo { get; set; }

        public Ativo Ativo { get; set; }

        public Corretora Corretora { get; set; }

        public Apuracao Apuracao { get; set; }
    }
}
