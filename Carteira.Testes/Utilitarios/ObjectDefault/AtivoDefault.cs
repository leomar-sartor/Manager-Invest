using Carteira.Domain;
using Carteira.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Carteira.Testes.Utilitarios.ObjectDefault
{
    public class AtivoDefault
    {
        public List<Ativo> _ativos = new List<Ativo>();
        public AtivoDefault() => BuildAtivo();

        private void BuildAtivo()
        {
            var AtivoOne = new Ativo("Banco Pan", "Bpan4", TipoInvestimento.RendaVariavel, TipoPapel.Acao);
            var AtivoTwo = new Ativo("Neo Energia", "Neoe3", TipoInvestimento.RendaVariavel, TipoPapel.Acao);
            var AtivoThree = new Ativo("Bcia", "Bcia11", TipoInvestimento.RendaVariavel, TipoPapel.FundoImobiliario);
            var AtivoFour = new Ativo("Bcff", "Bcff11", TipoInvestimento.RendaVariavel, TipoPapel.FundoImobiliario);
            var AtivoFive = new Ativo("Fexc", "Fexc11", TipoInvestimento.RendaVariavel, TipoPapel.FundoImobiliario);
            var AtivoSix = new Ativo("Irdm", "Irdm11", TipoInvestimento.RendaVariavel, TipoPapel.FundoImobiliario);
            var AtivoSeven = new Ativo("Hsml", "Hsml11", TipoInvestimento.RendaVariavel, TipoPapel.FundoImobiliario);
            var AtivoEight = new Ativo("Tesouro Pré Fixado","LTN", TipoInvestimento.RendaFixa, TipoPapel.TesouroDireto);
            var AtivoNine = new Ativo("Tesouro Selic", "LFT", TipoInvestimento.RendaFixa, TipoPapel.TesouroDireto);
            var AtivoTen = new Ativo("Tesouro IPCA +", "NTN-B Principal", TipoInvestimento.RendaFixa, TipoPapel.TesouroDireto);
            var AtivoEleven = new Ativo("Tesouro IPCA + com Juros Semestrais ", "NTN-B", TipoInvestimento.RendaFixa, TipoPapel.TesouroDireto);
            var AtivoTwelve = new Ativo("Visc", "Visc11", TipoInvestimento.RendaVariavel, TipoPapel.FundoImobiliario);

            _ativos.AddRange(new List<Ativo> { AtivoOne, AtivoTwo, AtivoThree, AtivoFour, AtivoFive, AtivoSix, AtivoSeven, AtivoEight, AtivoNine, AtivoTen, AtivoEleven, AtivoTwelve });
        }
    }
}
