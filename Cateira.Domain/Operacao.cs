using Carteira.Domain.Enums;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Carteira.Domain
{
    public class Operacao
    {
        public Operacao()
        {

        }

        public Operacao(Ativo ativo, Corretora corretora, decimal quantidade, decimal preco, TipoOperacao operacao, DateTime data )
        {
            Ativo = ativo;
            Corretora = corretora;
            Quantidade = quantidade;
            Preco = preco;
            TipoOperacao = operacao;
            Data = data;
        }

        public long Id { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Quantidade { get; set; }


        [Column(TypeName = "decimal(18,2)")]
        public decimal Preco { get; set; }

        public Ativo Ativo { get; set; }

        public Corretora Corretora { get; set; }

        public TipoOperacao TipoOperacao { get; set; }

        public DateTime Data { get; set; }
    }
}
