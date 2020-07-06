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

            var One = new Operacao(FundoImobiliarios.Where(fii => fii.Sigla == "BCIA11").First(), XP, 1M, 128.08M, TipoOperacao.Compra, new DateTime(2019, 08, 05));
            var Two = new Operacao(FundoImobiliarios.Where(fii => fii.Sigla == "FEXC11").First(), XP, 1M, 112.67M, TipoOperacao.Compra, new DateTime(2019, 10, 31));

            var Three = new Operacao(Tesouro.Where(ts => ts.Sigla == "NTN-B Principal").First(), CLEAR, 0.02M, 39.48M, TipoOperacao.Compra, new DateTime(2020, 01, 02));
            var Four = new Operacao(Tesouro.Where(ts => ts.Sigla == "NTN-B").First(), CLEAR, 0.02M, 87.81M, TipoOperacao.Compra, new DateTime(2020, 01, 02));
            var Five = new Operacao(Tesouro.Where(ts => ts.Sigla == "LTN").First(), CLEAR, 0.05M, 36.73M, TipoOperacao.Compra, new DateTime(2020, 01, 02));
            var Six = new Operacao(Tesouro.Where(ts => ts.Sigla == "LFT").First(), CLEAR, 0.02M, 209.26M, TipoOperacao.Compra, new DateTime(2020, 01, 02));

            var Seven = new Operacao(FundoImobiliarios.Where(fii => fii.Sigla == "HSML11").First(), XP, 1M, 123.53m, TipoOperacao.Compra, new DateTime(2020, 01, 07));

            var Eight = new Operacao(Tesouro.Where(ts => ts.Sigla == "LFT").First(), CLEAR, 0.01M, 104.88M, TipoOperacao.Compra, new DateTime(2020, 01, 23));
            var Nine = new Operacao(Tesouro.Where(ts => ts.Sigla == "NTN-B Principal").First(), CLEAR, 0.02M, 38.83M, TipoOperacao.Compra, new DateTime(2020, 01, 23));

            var Ten = new Operacao(Acoes.Where(ac => ac.Sigla == "NEOE3").First(), CLEAR, 2M, 50.20M, TipoOperacao.Compra, new DateTime(2020, 01, 23));
            var Eleven = new Operacao(Acoes.Where(ac => ac.Sigla == "BPAN4").First(), CLEAR, 2M, 21.28M, TipoOperacao.Compra, new DateTime(2020, 01, 23));

            var Twelve = new Operacao(FundoImobiliarios.Where(fii => fii.Sigla == "VISC11").First(), XP, 1M, 131M, TipoOperacao.Compra, new DateTime(2020, 02, 12));

            var Thirteen = new Operacao(Acoes.Where(ac => ac.Sigla == "BPAN4").First(), CLEAR, 3M, 19.50M, TipoOperacao.Compra, new DateTime(2020, 03, 11));
            var Fourteen = new Operacao(Acoes.Where(ac => ac.Sigla == "NEOE3").First(), CLEAR, 2M, 21.05M, TipoOperacao.Compra, new DateTime(2020, 03, 11));

            var Fiveteen = new Operacao(Tesouro.Where(ts => ts.Sigla == "LFT").First(), CLEAR, 0.03M, 0M, TipoOperacao.Venda, new DateTime(2020, 03, 19));

            var Sixteen = new Operacao(FundoImobiliarios.Where(fii => fii.Sigla == "BCFF11").First(), XP, 1M, 0M, TipoOperacao.Compra, new DateTime(2020, 01, 23));
            var Seventeen = new Operacao(FundoImobiliarios.Where(fii => fii.Sigla == "FEXC11").First(), XP, 1M, 0M, TipoOperacao.Compra, new DateTime(2020, 01, 23));

            var Eighteen = new Operacao(Acoes.Where(ac => ac.Sigla == "BPAN4").First(), CLEAR, 1M, 0M, TipoOperacao.Compra, new DateTime(2020, 03, 19));
            var Nineteen = new Operacao(Acoes.Where(ac => ac.Sigla == "NEOE3").First(), CLEAR, 1M, 0M, TipoOperacao.Compra, new DateTime(2020, 03, 19));
            var Twenty = new Operacao(FundoImobiliarios.Where(fii => fii.Sigla == "BCIA11").First(), CLEAR, 1M, 112M, TipoOperacao.Compra, new DateTime(2020, 03, 19));

            var TwentyOne = new Operacao(Tesouro.Where(ts => ts.Sigla == "NTN-B").First(), CLEAR, 1M, 0M, TipoOperacao.Compra, new DateTime(2020, 04, 07));
            var TwentyTwo = new Operacao(Tesouro.Where(ts => ts.Sigla == "NTN-B Principal").First(), CLEAR, 1M, 0M, TipoOperacao.Compra, new DateTime(2020, 04, 07));

            _operacoes.AddRange(new List<Operacao>() { One, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten,
                                                       Eleven, Twelve, Thirteen, Fourteen, Fiveteen, Sixteen, Seventeen, Eighteen, Nineteen, Twenty,
                                                       TwentyOne, TwentyTwo});
        }
    }
}
