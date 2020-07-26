using Carteira.Domain;
using Carteira.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Carteira.Testes.Utilitarios.ObjectDefault
{
    public class OperacaoDefault
    {
        public List<Operacao> _operacoes = new List<Operacao>();
        public List<Corretora> _corretoras = new CorretoraDefault()._corretoras;
        public List<Ativo> _ativos = new AtivoDefault()._ativos;

        public OperacaoDefault() => BuildOperacao();

        private void BuildOperacao()
        {
            var FundoImobiliarios = _ativos.Where(a => a.TipoPapel == TipoPapel.FundoImobiliario);
            var Acoes = _ativos.Where(a => a.TipoPapel == TipoPapel.Acao);
            var Tesouro = _ativos.Where(a => a.TipoPapel == TipoPapel.TesouroDireto);

            var XP = _corretoras.Where(a => a.Nome == "XP Investimentos").First();
            var CLEAR = _corretoras.Where(a => a.Nome == "Clear Corretora").First();

            // AGOSTO 2019
            var One = new Operacao(FundoImobiliarios.Where(fii => fii.Sigla == "BCIA11").First(), XP, 1M, 128.08M, TipoOperacao.Compra, new DateTime(2019, 08, 05), 0.0M);

            // OUTUBRO 2019
            var Two = new Operacao(FundoImobiliarios.Where(fii => fii.Sigla == "FEXC11").First(), XP, 1M, 112.67M, TipoOperacao.Compra, new DateTime(2019, 10, 31), 122.67M);

            // JANEIRO 2020
            var Three = new Operacao(Tesouro.Where(ts => ts.Sigla == "NTN-B PRINCIPAL").First(), CLEAR, 0.02M, 39.48M, TipoOperacao.Compra, new DateTime(2020, 01, 02), 0.0M);
            var Four = new Operacao(Tesouro.Where(ts => ts.Sigla == "NTN-B").First(), CLEAR, 0.02M, 87.81M, TipoOperacao.Compra, new DateTime(2020, 01, 02), 0.0M);
            var Five = new Operacao(Tesouro.Where(ts => ts.Sigla == "LTN").First(), CLEAR, 0.05M, 36.73M, TipoOperacao.Compra, new DateTime(2020, 01, 02), 0.0M);
            var Six = new Operacao(Tesouro.Where(ts => ts.Sigla == "LFT").First(), CLEAR, 0.02M, 209.26M, TipoOperacao.Compra, new DateTime(2020, 01, 02), 0.0M);

            var Seven = new Operacao(FundoImobiliarios.Where(fii => fii.Sigla == "HSML11").First(), XP, 1M, 123.53m, TipoOperacao.Compra, new DateTime(2020, 01, 07), 123.53M);

            var Eight = new Operacao(Tesouro.Where(ts => ts.Sigla == "LFT").First(), CLEAR, 0.01M, 104.88M, TipoOperacao.Compra, new DateTime(2020, 01, 23), 0.0M);
            var Nine = new Operacao(Tesouro.Where(ts => ts.Sigla == "NTN-B PRINCIPAL").First(), CLEAR, 0.02M, 38.83M, TipoOperacao.Compra, new DateTime(2020, 01, 23), 0.0M);

            var Ten = new Operacao(Acoes.Where(ac => ac.Sigla == "NEOE3").First(), CLEAR, 2M, 50.20M, TipoOperacao.Compra, new DateTime(2020, 01, 23), 25.10M);
            var Eleven = new Operacao(Acoes.Where(ac => ac.Sigla == "BPAN4").First(), CLEAR, 2M, 21.28M, TipoOperacao.Compra, new DateTime(2020, 01, 23), 10.64M);

            // FEVEREIRO 2020
            var Twelve = new Operacao(FundoImobiliarios.Where(fii => fii.Sigla == "VISC11").First(), XP, 1M, 131M, TipoOperacao.Compra, new DateTime(2020, 02, 12), 131.00M);

            // MARÇO 2020
            var Thirteen = new Operacao(Acoes.Where(ac => ac.Sigla == "BPAN4").First(), CLEAR, 3M, 19.50M, TipoOperacao.Compra, new DateTime(2020, 03, 11), 0.0M);
            var Fourteen = new Operacao(Acoes.Where(ac => ac.Sigla == "NEOE3").First(), CLEAR, 2M, 21.05M, TipoOperacao.Compra, new DateTime(2020, 03, 11), 0.0M);

            var Fiveteen = new Operacao(Tesouro.Where(ts => ts.Sigla == "LFT").First(), CLEAR, 0.03M, 0M, TipoOperacao.Venda, new DateTime(2020, 03, 19), 0.0M);

            var Sixteen = new Operacao(FundoImobiliarios.Where(fii => fii.Sigla == "BCFF11").First(), XP, 2M, 193.60M, TipoOperacao.Compra, new DateTime(2020, 03, 13), 0.0M);
            var Seventeen = new Operacao(FundoImobiliarios.Where(fii => fii.Sigla == "FEXC11").First(), XP, 1M, 108.85M, TipoOperacao.Compra, new DateTime(2020, 03, 13), 0.0M);

            var Eighteen = new Operacao(Acoes.Where(ac => ac.Sigla == "BPAN4").First(), CLEAR, 1M, 0M, TipoOperacao.Compra, new DateTime(2020, 03, 19), 0.0M);
            var Nineteen = new Operacao(Acoes.Where(ac => ac.Sigla == "NEOE3").First(), CLEAR, 1M, 0M, TipoOperacao.Compra, new DateTime(2020, 03, 19), 0.0M);
            var Twenty = new Operacao(FundoImobiliarios.Where(fii => fii.Sigla == "BCIA11").First(), CLEAR, 1M, 112M, TipoOperacao.Compra, new DateTime(2020, 03, 19), 0.0M);

            // ABRIL 2020
            var TwentyOne = new Operacao(Tesouro.Where(ts => ts.Sigla == "NTN-B").First(), CLEAR, 1M, 0M, TipoOperacao.Compra, new DateTime(2020, 04, 07), 0.0M);
            var TwentyTwo = new Operacao(Tesouro.Where(ts => ts.Sigla == "NTN-B PRINCIPAL").First(), CLEAR, 1M, 0M, TipoOperacao.Compra, new DateTime(2020, 04, 07), 0.0M);

            var TwentyThree = new Operacao(FundoImobiliarios.Where(ts => ts.Sigla == "BCIA11").First(), CLEAR, 1M, 177.96M, TipoOperacao.Venda, new DateTime(2020, 04, 23), 0.0M);
            var TwentyFour = new Operacao(FundoImobiliarios.Where(ts => ts.Sigla == "HSML11").First(), XP, 2M, 84.06M, TipoOperacao.Venda, new DateTime(2020, 04, 23), 0.0M);
            var TwentyFive = new Operacao(FundoImobiliarios.Where(ts => ts.Sigla == "VISC11").First(), XP, 1M, 100.30M, TipoOperacao.Venda, new DateTime(2020, 04, 23), 0.0M);
            var TwentySix = new Operacao(FundoImobiliarios.Where(ts => ts.Sigla == "IRDM11").First(), XP, 2M, 102.00M, TipoOperacao.Compra, new DateTime(2020, 04, 23), 0.0M);
            
            // MAIO 2020
            var TwentySeven = new Operacao(FundoImobiliarios.Where(ts => ts.Sigla == "HSML11").First(), XP, 2M, 80.00M, TipoOperacao.Compra, new DateTime(2020, 05, 12), 0.0M);
            var TwentyEight = new Operacao(FundoImobiliarios.Where(ts => ts.Sigla == "VISC11").First(), XP, 1M, 95.85M, TipoOperacao.Compra, new DateTime(2020, 05, 12), 0.0M);

            _operacoes.AddRange(new List<Operacao>() { One, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten,
                                                       Eleven, Twelve, Thirteen, Fourteen, Fiveteen, Sixteen, Seventeen, Eighteen, Nineteen, Twenty,
                                                       TwentyOne, TwentyTwo, TwentyThree, TwentyFour, TwentyFive, TwentySix, TwentySeven, TwentyEight});
        }
    }
}
