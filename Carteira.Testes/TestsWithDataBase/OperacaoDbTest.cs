using Carteira.Entity;
using Carteira.Entity.Contexto;
using Carteira.Entity.Enuns;
using Carteira.Repository;
using Carteira.Service;
using Carteira.Testes.Utilitarios.ObjectDefault;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Carteira.Testes.TestsWithDataBase
{
    [TestClass]
    public class OperacaoDbTest
    {
        private static Context _context;

        [ClassInitialize]
        public static void TestFixtureSetup(TestContext context)
        {
            _context = new Context(true);
            _context.Database.EnsureCreated();
        }

        [TestMethod]
        public async Task DeveSalvarUmaOperacaoDB()
        {
            var dOperacao = new OperacaoDefault();

            var rOperacao = new OperacaoRepository(_context);

            var operacoes = dOperacao._operacoes;




            await rOperacao.AdicionarAsync(operacoes);

            await rOperacao.SalvarAsync();
        }

        [TestMethod]
        public void DeveProcessarPrecoMedioOperacoesCompraEVenda()
        {
            var sOperacao = new OperacaoService(_context);
            var COMPRA = TipoOperacao.Compra;
            var VENDA = TipoOperacao.Venda;

            var XP = new Corretora("XP INVESTIMENTOS");

            var AAAA11 = new Ativo("AAAA11", "AAAA11", TipoInvestimento.RendaVariavel, TipoPapel.FundoImobiliario);

            //AGOSTO
            var Op1 = new Operacao(AAAA11, XP, 20, 101.20M, COMPRA, new DateTime(2017, 08, 04), 5.53M);
            sOperacao.Salvar(Op1);
            Assert.AreEqual(101.48M, Op1.PrecoMedioDoAtivo);

            //SETEMBRO
            var Op2 = new Operacao(AAAA11, XP, 15, 98.88M, COMPRA, new DateTime(2017, 09, 05), 4.87M);
            sOperacao.Salvar(Op2);
            Assert.AreEqual(100.50M, Op2.PrecoMedioDoAtivo);

            var Op3 = new Operacao(AAAA11, XP, 12, 103.32M, COMPRA, new DateTime(2017, 09, 22), 3.65M);
            sOperacao.Salvar(Op3);
            Assert.AreEqual(101.30M, Op3.PrecoMedioDoAtivo);

            //OUTUBRO
            var Op4 = new Operacao(AAAA11, XP, 17, 106.71M, VENDA, new DateTime(2017, 10, 11), 5.41M);
            sOperacao.Salvar(Op4);
            Assert.AreEqual(101.30M, Op4.PrecoMedioDoAtivo);

            var Op5 = new Operacao(AAAA11, XP, 10, 108.32M, VENDA, new DateTime(2017, 10, 25), 5.63M);
            sOperacao.Salvar(Op5);
            Assert.AreEqual(101.30M, Op5.PrecoMedioDoAtivo);

            //NOVEMBRO
            var Op6 = new Operacao(AAAA11, XP, 10, 103.20M, COMPRA, new DateTime(2017, 11, 13), 4.80M);
            sOperacao.Salvar(Op6);
            Assert.AreEqual(102.09M, Op6.PrecoMedioDoAtivo);

            var Op7 = new Operacao(AAAA11, XP, 20, 98.90M, VENDA, new DateTime(2017, 11, 20), 6.00M);
            sOperacao.Salvar(Op7);
            Assert.AreEqual(102.09M, Op7.PrecoMedioDoAtivo);
        }

        [TestMethod]
        public void DeveProcessarSaldoCotasEQuantidadeOperacoesCompraEVenda()
        {
            var sOperacao = new OperacaoService(_context);
            var COMPRA = TipoOperacao.Compra;
            var VENDA = TipoOperacao.Venda;

            var XP = new Corretora("XP INVESTIMENTOS");

            var AAAA11 = new Ativo("AAAA11", "AAAA11", TipoInvestimento.RendaVariavel, TipoPapel.FundoImobiliario);

            var Op1 = new Operacao(AAAA11, XP, 20, 101.20M, COMPRA, new DateTime(2017, 08, 04), 5.53M);
            sOperacao.Salvar(Op1);
            Assert.AreEqual(20M, Op1.Quantidade);
            Assert.AreEqual(20M, Op1.SaldoCotas);

            var Op2 = new Operacao(AAAA11, XP, 15, 98.88M, COMPRA, new DateTime(2017, 09, 05), 4.87M);
            sOperacao.Salvar(Op2);
            Assert.AreEqual(15M, Op2.Quantidade);
            Assert.AreEqual(35M, Op2.SaldoCotas);

            var Op3 = new Operacao(AAAA11, XP, 12, 103.32M, COMPRA, new DateTime(2017, 09, 22), 3.65M);
            sOperacao.Salvar(Op3);
            Assert.AreEqual(12M, Op3.Quantidade);
            Assert.AreEqual(47M, Op3.SaldoCotas);

            //OUTUBRO
            var Op4 = new Operacao(AAAA11, XP, 17, 106.71M, VENDA, new DateTime(2017, 10, 11), 5.41M);
            sOperacao.Salvar(Op4);
            Assert.AreEqual(17M, Op4.Quantidade);
            Assert.AreEqual(30M, Op4.SaldoCotas);

            var Op5 = new Operacao(AAAA11, XP, 10, 108.32M, VENDA, new DateTime(2017, 10, 25), 5.63M);
            sOperacao.Salvar(Op5);
            Assert.AreEqual(10M, Op5.Quantidade);
            Assert.AreEqual(20M, Op5.SaldoCotas);

            //NOVEMBRO
            var Op6 = new Operacao(AAAA11, XP, 10, 103.20M, COMPRA, new DateTime(2017, 11, 13), 4.80M);
            sOperacao.Salvar(Op6);
            Assert.AreEqual(10M, Op6.Quantidade);
            Assert.AreEqual(30M, Op6.SaldoCotas);

            var Op7 = new Operacao(AAAA11, XP, 20, 98.90M, VENDA, new DateTime(2017, 11, 20), 6.00M);
            sOperacao.Salvar(Op7);
            Assert.AreEqual(20M, Op7.Quantidade);
            Assert.AreEqual(10M, Op7.SaldoCotas);
        }

        [TestMethod]
        public void DeveApurarLucroPrejuizoFII()
        {
            var rApuracao = new ApuracaoRepository(_context);
            var sOperacao = new OperacaoService(_context);
            var sPosicao = new PosicaoService(_context);
            var COMPRA = TipoOperacao.Compra;
            var VENDA = TipoOperacao.Venda;
            var XP = new Corretora("XP INVESTIMENTOS");
            var AAAA11 = new Ativo("AAAA11", "AAAA11", TipoInvestimento.RendaVariavel, TipoPapel.FundoImobiliario);

            //AGOSTO
            var Op1 = new Operacao(AAAA11, XP, 20, 101.20M, COMPRA, new DateTime(2017, 08, 04), 5.53M);
            sOperacao.Salvar(Op1);

            //SETEMBRO
            var Op2 = new Operacao(AAAA11, XP, 15, 98.88M, COMPRA, new DateTime(2017, 09, 05), 4.87M);
            sOperacao.Salvar(Op2);

            var Op3 = new Operacao(AAAA11, XP, 12, 103.32M, COMPRA, new DateTime(2017, 09, 22), 3.65M);
            sOperacao.Salvar(Op3);

            //OUTUBRO
            var Op4 = new Operacao(AAAA11, XP, 17, 106.71M, VENDA, new DateTime(2017, 10, 11), 5.41M);
            sOperacao.Salvar(Op4);
            var apuracao = rApuracao.Listar().FirstOrDefault();
            Assert.AreEqual(86.56M, apuracao.Valor);

            var Op5 = new Operacao(AAAA11, XP, 10, 108.32M, VENDA, new DateTime(2017, 10, 25), 5.63M);
            sOperacao.Salvar(Op5);
            apuracao = rApuracao.Buscar(m => m.Operacao == Op5).FirstOrDefault();
            Assert.AreEqual(64.57M, apuracao.Valor);

            //NOVEMBRO
            var Op6 = new Operacao(AAAA11, XP, 10, 103.20M, COMPRA, new DateTime(2017, 11, 13), 4.80M);
            sOperacao.Salvar(Op6);

            var Op7 = new Operacao(AAAA11, XP, 20, 98.90M, VENDA, new DateTime(2017, 11, 20), 6.00M);
            sOperacao.Salvar(Op7);
            apuracao = rApuracao.Buscar(m => m.Operacao == Op7).FirstOrDefault();
            Assert.AreEqual(-69.80M, apuracao.Valor);
        }

        [TestMethod]
        public void DeveApurarLucroPrejuizoMensalConsiderandoMaisDeUmAtivoFII()
        {
            var rApuracao = new ApuracaoRepository(_context);
            var sOperacao = new OperacaoService(_context);
            var sPosicao = new PosicaoService(_context);
            var COMPRA = TipoOperacao.Compra;
            var VENDA = TipoOperacao.Venda;
            var XP = new Corretora("XP INVESTIMENTOS");
            var AAAA11 = new Ativo("AAAA11", "AAAA11", TipoInvestimento.RendaVariavel, TipoPapel.FundoImobiliario);
            var BBBB11 = new Ativo("BBBB11", "BBBB11", TipoInvestimento.RendaVariavel, TipoPapel.FundoImobiliario);
            var CCCC11 = new Ativo("CCCC11", "CCCC11", TipoInvestimento.RendaVariavel, TipoPapel.FundoImobiliario);

            //AGOSTO
            var Op1 = new Operacao(AAAA11, XP, 20, 101.20M, COMPRA, new DateTime(2017, 08, 04), 5.53M);
            var Op2 = new Operacao(BBBB11, XP, 31, 83.45M, COMPRA, new DateTime(2017, 08, 09), 6.45M);
            var Op3 = new Operacao(BBBB11, XP, 27, 82.01M, COMPRA, new DateTime(2017, 08, 18), 5.64M);
            var Op4 = new Operacao(CCCC11, XP, 14, 234.72M, COMPRA, new DateTime(2017, 08, 18), 7.12M);
            sOperacao.Salvar(Op1);
            sOperacao.Salvar(Op2);
            sOperacao.Salvar(Op3);
            sOperacao.Salvar(Op4);

            //SETEMBRO
            var Op5 = new Operacao(AAAA11, XP, 15, 98.88M, COMPRA, new DateTime(2017, 09, 05), 4.87M);
            var Op6 = new Operacao(AAAA11, XP, 12, 103.32M, COMPRA, new DateTime(2017, 09, 22), 3.65M);
            var Op7 = new Operacao(CCCC11, XP, 09, 219.18M, COMPRA, new DateTime(2017, 09, 17), 5.45M);
            sOperacao.Salvar(Op5);
            sOperacao.Salvar(Op6);
            sOperacao.Salvar(Op7);

            //OUTUBRO
            var Op8 = new Operacao(AAAA11, XP, 17, 106.71M, VENDA, new DateTime(2017, 10, 11), 5.41M);
            var Op9 = new Operacao(AAAA11, XP, 10, 108.32M, VENDA, new DateTime(2017, 10, 25), 5.63M);
            sOperacao.Salvar(Op8);
            sOperacao.Salvar(Op9);

            //NOVEMBRO
            var Op10 = new Operacao(AAAA11, XP, 10, 103.20M, COMPRA, new DateTime(2017, 11, 13), 4.80M);
            var Op11 = new Operacao(AAAA11, XP, 20, 98.90M, VENDA, new DateTime(2017, 11, 20), 6.00M);
            var Op12 = new Operacao(BBBB11, XP, 20, 95.00M, VENDA, new DateTime(2017, 11, 27), 5.20M);
            sOperacao.Salvar(Op10);
            sOperacao.Salvar(Op11);
            sOperacao.Salvar(Op12);

            var apuracaoOutubro = rApuracao.Buscar(m => m.Mes == 10 && m.Ano == 2017).Sum(m => m.Valor);
            Assert.AreEqual(151.13M, apuracaoOutubro);

            var apuracaoNovembro = rApuracao.Buscar(m => m.Mes == 11 && m.Ano == 2017).Sum(m => m.Valor);
            Assert.AreEqual(165.20M, apuracaoNovembro);
        }

        [TestMethod]
        public void DeveRetornarPosicaoDoAtivo()
        {
            var sOperacao = new OperacaoService(_context);
            var sPosicao = new PosicaoService(_context);
            var COMPRA = TipoOperacao.Compra;
            var VENDA = TipoOperacao.Venda;
            var XP = new Corretora("XP INVESTIMENTOS");
            var AAAA11 = new Ativo("AAAA11", "AAAA11", TipoInvestimento.RendaVariavel, TipoPapel.FundoImobiliario);

            //AGOSTO
            var Op1 = new Operacao(AAAA11, XP, 20, 101.20M, COMPRA, new DateTime(2017, 08, 04), 5.53M);
            sOperacao.Salvar(Op1);
            var posicao = sPosicao.PosicaoFII().Where(m => m.Sigla == "AAAA11").FirstOrDefault();
            Assert.AreEqual(20M, posicao.QuantidadeCotas);
            Assert.AreEqual(101.48M, posicao.PrecoMedioAquisicao);
            Assert.AreEqual(2029.60M, posicao.ValorPosicao);

            //SETEMBRO
            var Op2 = new Operacao(AAAA11, XP, 15, 98.88M, COMPRA, new DateTime(2017, 09, 05), 4.87M);
            sOperacao.Salvar(Op2);
            posicao = sPosicao.PosicaoFII().Where(m => m.Sigla == "AAAA11").FirstOrDefault();
            Assert.AreEqual(35M, posicao.QuantidadeCotas);
            Assert.AreEqual(100.50M, posicao.PrecoMedioAquisicao);
            Assert.AreEqual(3517.50M, posicao.ValorPosicao);

            var Op3 = new Operacao(AAAA11, XP, 12, 103.32M, COMPRA, new DateTime(2017, 09, 22), 3.65M);
            sOperacao.Salvar(Op3);
            posicao = sPosicao.PosicaoFII().Where(m => m.Sigla == "AAAA11").FirstOrDefault();
            Assert.AreEqual(47M, posicao.QuantidadeCotas);
            Assert.AreEqual(101.30M, posicao.PrecoMedioAquisicao);
            Assert.AreEqual(4761.10M, posicao.ValorPosicao);

            //OUTUBRO
            var Op4 = new Operacao(AAAA11, XP, 17, 106.71M, VENDA, new DateTime(2017, 10, 11), 5.41M);
            sOperacao.Salvar(Op4);
            posicao = sPosicao.PosicaoFII().Where(m => m.Sigla == "AAAA11").FirstOrDefault();
            Assert.AreEqual(30M, posicao.QuantidadeCotas);
            Assert.AreEqual(101.30M, posicao.PrecoMedioAquisicao);
            Assert.AreEqual(3039.00M, posicao.ValorPosicao);

            var Op5 = new Operacao(AAAA11, XP, 10, 108.32M, VENDA, new DateTime(2017, 10, 25), 5.63M);
            sOperacao.Salvar(Op5);
            posicao = sPosicao.PosicaoFII().Where(m => m.Sigla == "AAAA11").FirstOrDefault();
            Assert.AreEqual(20M, posicao.QuantidadeCotas);
            Assert.AreEqual(101.30M, posicao.PrecoMedioAquisicao);
            Assert.AreEqual(2026.00M, posicao.ValorPosicao);

            //NOVEMBRO
            var Op6 = new Operacao(AAAA11, XP, 10, 103.20M, COMPRA, new DateTime(2017, 11, 13), 4.80M);
            sOperacao.Salvar(Op6);
            posicao = sPosicao.PosicaoFII().Where(m => m.Sigla == "AAAA11").FirstOrDefault();
            Assert.AreEqual(30M, posicao.QuantidadeCotas);
            Assert.AreEqual(102.09M, posicao.PrecoMedioAquisicao);
            Assert.AreEqual(3062.70M, posicao.ValorPosicao);

            var Op7 = new Operacao(AAAA11, XP, 20, 98.90M, VENDA, new DateTime(2017, 11, 20), 6.00M);
            sOperacao.Salvar(Op7);
            posicao = sPosicao.PosicaoFII().Where(m => m.Sigla == "AAAA11").FirstOrDefault();
            Assert.AreEqual(10M, posicao.QuantidadeCotas);
            Assert.AreEqual(102.09M, posicao.PrecoMedioAquisicao);
            Assert.AreEqual(1020.90M, posicao.ValorPosicao);
        }

        [TestMethod]
        public void DeveApurarDARFFII()
        {

        }

        [TestMethod]
        public void DeveRetornarPorcentagensPosicao()
        {
            var sOperacao = new OperacaoService(_context);
            var sPosicao = new PosicaoService(_context);

            var dOperacao = new OperacaoDefault();
            var operacoes = dOperacao._operacoes
                .Where(o => o.Ativo.TipoPapel == TipoPapel.FundoImobiliario)
                .ToList();

            foreach (var operacao in operacoes)
            {
                sOperacao.Salvar(operacao);
            }

            var posicaoFinal = sPosicao.PosicaoFII();

            Assert.AreEqual(100.0M, posicaoFinal.Sum(m => m.Percentagem));
        }

        [TestMethod]
        public void DeveZerarPrecoMedioEQuantidadeDoAtivoAposVendaTotal()
        {

        }

        [TestMethod]
        public void DeveCalcularTaxaDeLiquidacao()
        {

        }

        [TestMethod]
        public void CenarioRealFundoImobiliario()
        {
            var sOperacao = new OperacaoService(_context);
            var sPosicao = new PosicaoService(_context);
            var rApuracao = new ApuracaoRepository(_context);
            var COMPRA = TipoOperacao.Compra;
            var VENDA = TipoOperacao.Venda;

            var XP = new Corretora("XP INVESTIMENTOS");
            var CLEAR = new Corretora("CLEAR");

            var BCIA11 = new Ativo("BCIA11", "BCIA11", TipoInvestimento.RendaVariavel, TipoPapel.FundoImobiliario);
            var FEXC11 = new Ativo("FEXC11", "FEXC11", TipoInvestimento.RendaVariavel, TipoPapel.FundoImobiliario);
            var HSML11 = new Ativo("HSML11", "HSML11", TipoInvestimento.RendaVariavel, TipoPapel.FundoImobiliario);
            var VISC11 = new Ativo("VISC11", "VISC11", TipoInvestimento.RendaVariavel, TipoPapel.FundoImobiliario);
            var BCFF11 = new Ativo("BCFF11", "BCFF11", TipoInvestimento.RendaVariavel, TipoPapel.FundoImobiliario);

            //2019
            //AGOSTO
            var Op1 = new Operacao(BCIA11, XP, 1, 128.05M, COMPRA, new DateTime(2019, 08, 01), 0.03M);
            sOperacao.Salvar(Op1);

            var posicao = sPosicao.PosicaoFII().Where(m => m.Sigla == "BCIA11").FirstOrDefault();
            var apuracaoAgosto = rApuracao.Buscar(m => m.Mes == 08 && m.Ano == 2019).Sum(m => m.Valor);
            var apuracao = rApuracao.Buscar(m => m.Operacao == Op1).FirstOrDefault();

            Assert.AreEqual(0.0M, apuracaoAgosto);
            Assert.IsNull(apuracao);

            Assert.AreEqual(1.0M, Op1.Quantidade);
            Assert.AreEqual(1.0M, Op1.SaldoCotas);
            Assert.AreEqual(128.08M, Op1.PrecoMedioDoAtivo);

            Assert.AreEqual(1.0M, posicao.QuantidadeCotas);
            Assert.AreEqual(128.08M, posicao.PrecoMedioAquisicao);
            Assert.AreEqual(128.08M, posicao.ValorPosicao);

            //OUTUBRO
            var Op2 = new Operacao(FEXC11, XP, 1, 112.64M, COMPRA, new DateTime(2019, 10, 29), 0.03M);
            sOperacao.Salvar(Op2);

            posicao = sPosicao.PosicaoFII().Where(m => m.Sigla == "FEXC11").FirstOrDefault();
            var apuracaoOutubro = rApuracao.Buscar(m => m.Mes == 10 && m.Ano == 2019).Sum(m => m.Valor);
            apuracao = rApuracao.Buscar(m => m.Operacao == Op1).FirstOrDefault();

            Assert.AreEqual(0.0M, apuracaoOutubro);
            Assert.IsNull(apuracao);

            Assert.AreEqual(1.0M, Op2.Quantidade);
            Assert.AreEqual(1.0M, Op2.SaldoCotas);
            Assert.AreEqual(112.67M, Op2.PrecoMedioDoAtivo);

            Assert.AreEqual(1.0M, posicao.QuantidadeCotas);
            Assert.AreEqual(112.67M, posicao.PrecoMedioAquisicao);
            Assert.AreEqual(112.67M, posicao.ValorPosicao);

            //2020
            //JANEIRO
            var Op3 = new Operacao(HSML11, XP, 1, 123.50M, COMPRA, new DateTime(2020, 01, 03), 0.03M);
            sOperacao.Salvar(Op3);

            posicao = sPosicao.PosicaoFII().Where(m => m.Sigla == "HSML11").FirstOrDefault();
            var apuracaoJaneiro = rApuracao.Buscar(m => m.Mes == 01 && m.Ano == 2020).Sum(m => m.Valor);
            apuracao = rApuracao.Buscar(m => m.Operacao == Op3).FirstOrDefault();

            Assert.AreEqual(0.0M, apuracaoJaneiro);
            Assert.IsNull(apuracao);

            Assert.AreEqual(1.0M, Op3.Quantidade);
            Assert.AreEqual(1.0M, Op3.SaldoCotas);
            Assert.AreEqual(123.53M, Op3.PrecoMedioDoAtivo);

            Assert.AreEqual(1.0M, posicao.QuantidadeCotas);
            Assert.AreEqual(123.53M, posicao.PrecoMedioAquisicao);
            Assert.AreEqual(123.53M, posicao.ValorPosicao);

            //FEVEREIRO
            var Op4 = new Operacao(VISC11, XP, 1, 131.00M, COMPRA, new DateTime(2020, 02, 12), 0.03M);
            sOperacao.Salvar(Op4);

            posicao = sPosicao.PosicaoFII().Where(m => m.Sigla == "VISC11").FirstOrDefault();
            var apuracaoFevereiro = rApuracao.Buscar(m => m.Mes == 02 && m.Ano == 2020).Sum(m => m.Valor);
            apuracao = rApuracao.Buscar(m => m.Operacao == Op4).FirstOrDefault();

            Assert.AreEqual(0.0M, apuracaoFevereiro);
            Assert.IsNull(apuracao);

            Assert.AreEqual(1.0M, Op4.Quantidade);
            Assert.AreEqual(1.0M, Op4.SaldoCotas);
            Assert.AreEqual(131.03M, Op4.PrecoMedioDoAtivo);

            Assert.AreEqual(1.0M, posicao.QuantidadeCotas);
            Assert.AreEqual(131.03M, posicao.PrecoMedioAquisicao);
            Assert.AreEqual(131.03M, posicao.ValorPosicao);

            //MARÇO
            var Op5 = new Operacao(BCFF11, XP, 2, 96.80M, COMPRA, new DateTime(2020, 03, 11), 0.05M);
            var Op6 = new Operacao(FEXC11, XP, 1, 108.85M, COMPRA, new DateTime(2020, 03, 11), 0.03M);
            var Op7 = new Operacao(BCIA11, XP, 1, 112.00M, COMPRA, new DateTime(2020, 03, 11), 0.03M);
            sOperacao.Salvar(Op5);
            sOperacao.Salvar(Op6);
            sOperacao.Salvar(Op7);

            var apuracaoMarco = rApuracao.Buscar(m => m.Mes == 03 && m.Ano == 2020).Sum(m => m.Valor);
            var apuracao5 = rApuracao.Buscar(m => m.Operacao == Op5).FirstOrDefault();
            var apuracao6 = rApuracao.Buscar(m => m.Operacao == Op6).FirstOrDefault();
            var apuracao7 = rApuracao.Buscar(m => m.Operacao == Op7).FirstOrDefault();

            Assert.AreEqual(0.0M, apuracaoMarco);
            Assert.IsNull(apuracao5);
            Assert.IsNull(apuracao6);
            Assert.IsNull(apuracao7);

            posicao = sPosicao.PosicaoFII().Where(m => m.Sigla == "BCFF11").FirstOrDefault();

            Assert.AreEqual(2.0M, Op5.Quantidade);
            Assert.AreEqual(2.0M, Op5.SaldoCotas);
            Assert.AreEqual(96.82M, Op5.PrecoMedioDoAtivo);

            Assert.AreEqual(2.0M, posicao.QuantidadeCotas);
            Assert.AreEqual(96.82M, posicao.PrecoMedioAquisicao);
            Assert.AreEqual(193.64M, posicao.ValorPosicao);

            posicao = sPosicao.PosicaoFII().Where(m => m.Sigla == "FEXC11").FirstOrDefault();

            Assert.AreEqual(1.0M, Op6.Quantidade);
            Assert.AreEqual(2.0M, Op6.SaldoCotas);
            Assert.AreEqual(110.78M, Op6.PrecoMedioDoAtivo);

            Assert.AreEqual(2.0M, posicao.QuantidadeCotas);
            Assert.AreEqual(110.78M, posicao.PrecoMedioAquisicao);
            Assert.AreEqual(221.56M, posicao.ValorPosicao);

            posicao = sPosicao.PosicaoFII().Where(m => m.Sigla == "BCIA11").FirstOrDefault();

            Assert.AreEqual(1.0M, Op7.Quantidade);
            Assert.AreEqual(2.0M, Op7.SaldoCotas);
            Assert.AreEqual(120.06M, Op7.PrecoMedioDoAtivo);

            Assert.AreEqual(2.0M, posicao.QuantidadeCotas);
            Assert.AreEqual(120.06M, posicao.PrecoMedioAquisicao);
            Assert.AreEqual(240.12M, posicao.ValorPosicao);

            //ABRIL
            var Op8 = new Operacao(HSML11, XP, 1, 84.06M, VENDA, new DateTime(2020, 04, 23), 0.02M);
            var Op9 = new Operacao(VISC11, XP, 1, 100.30M, VENDA, new DateTime(2020, 04, 23), 0.03M);
            var Op10 = new Operacao(BCIA11, CLEAR, 1, 178.00M, VENDA, new DateTime(2020, 04, 23), 0.04M);

            sOperacao.Salvar(Op8);
            var apuracaoAbril = rApuracao.Buscar(m => m.Mes == 04 && m.Ano == 2020).Sum(m => m.Valor);
            var apuracao8 = rApuracao.Buscar(m => m.Operacao == Op8).FirstOrDefault();
            Assert.AreEqual(-39.49M, apuracaoAbril);
            Assert.IsNotNull(apuracao8);

            sOperacao.Salvar(Op9);
            apuracaoAbril = rApuracao.Buscar(m => m.Mes == 04 && m.Ano == 2020).Sum(m => m.Valor);
            var apuracao9 = rApuracao.Buscar(m => m.Operacao == Op9).FirstOrDefault();
            Assert.AreEqual(-70.25M, apuracaoAbril);
            Assert.IsNotNull(apuracao9);

            sOperacao.Salvar(Op10);
            apuracaoAbril = rApuracao.Buscar(m => m.Mes == 04 && m.Ano == 2020).Sum(m => m.Valor);
            var apuracao10 = rApuracao.Buscar(m => m.Operacao == Op10).FirstOrDefault();
            Assert.AreEqual(-12.35M, apuracaoAbril);
            Assert.IsNotNull(apuracao10);
        }

        [ClassCleanup]
        public static void TestFixtureTearDown()
        {
            _context.Database.EnsureDeleted();
        }
    }
}
