﻿using Carteira.Entity.Enuns;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Carteira.Entity
{
    public class Ativo
    {
        private string _sigla;

        public Ativo()
        {

        }

        public Ativo(
            string nome,
            string sigla,
            TipoInvestimento tipoInvestimento,
            TipoPapel tipoPapel)
        {
            Nome = nome;
            Sigla = sigla;
            TipoInvestimento = tipoInvestimento;
            TipoPapel = tipoPapel;
        }

        public long Id { get; set; }
        public string Nome { get; set; }

        public string Sigla
        {
            get
            {
                return _sigla;
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                    _sigla = value.ToUpper();
            }
        }

        [Display(Name = "Tipo de Investimento")]
        public TipoInvestimento TipoInvestimento { get; set; }

        [Display(Name = "Tipo de Papel")]
        public TipoPapel TipoPapel { get; set; }

        //Relacionamentos
        public ICollection<Operacao> Operacoes { get; set; }
    }
}