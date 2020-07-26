using Carteira.Domain.Enums;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Carteira.Domain
{
    public class Operacao
    {
        public decimal _custoMedioOperacao;

        public decimal _custoOperacao;

        public Operacao()
        {

        }

        public Operacao(Ativo ativo, Corretora corretora, decimal quantidade, decimal preco, TipoOperacao operacao, DateTime data, decimal corretagem = 0M, decimal emolumentos = 0M)
        {
            Ativo = ativo;
            Corretora = corretora;
            Quantidade = quantidade;
            PrecoUnitario = preco;
            TipoOperacao = operacao;
            Data = data;
            Corretagem = corretagem;
            Emolumentos = emolumentos;
        }

        public long Id { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Quantidade { get; set; }


        [Column(TypeName = "decimal(18,2)")]
        public decimal PrecoUnitario { get; set; }

        public Ativo Ativo { get; set; }

        public Corretora Corretora { get; set; }

        public TipoOperacao TipoOperacao { get; set; }

        public DateTime Data { get; set; }


        [Column(TypeName = "decimal(18,2)")]
        public decimal Corretagem { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Emolumentos { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal SaldoCotas { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal CustoMedioOperacao
        {
            get
            {
                _custoMedioOperacao = Math.Round((((Quantidade * PrecoUnitario) + (Emolumentos + Corretagem)) / Quantidade), 2);
                return _custoMedioOperacao;
            }
            set
            {
                _custoMedioOperacao = value;
            }
        }

        [Column(TypeName = "decimal(18,2)")]
        public decimal CustoOperacao
        {
            get
            {
                _custoOperacao = Math.Round(((Quantidade * PrecoUnitario) + (Emolumentos + Corretagem)), 2);
                return _custoOperacao;
            }
            set
            {
                _custoOperacao = value;
            }
        }

        //[Column(TypeName = "decimal(18,2)")]
        //public decimal CustoMedio { get; set; }
    }
}
