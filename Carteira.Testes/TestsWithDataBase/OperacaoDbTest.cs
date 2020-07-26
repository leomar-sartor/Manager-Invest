using Carteira.Domain;
using Carteira.Domain.Contexto;
using Carteira.Domain.Enums;
using Carteira.Repository;
using Carteira.Service;
using Carteira.Testes.Utilitarios.ObjectDefault;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        public void DeveApurarLucroPrejuizoExemploLivroFII()
        {
            //var rOperacao = new OperacaoRepository(_context);
            var sOperacao = new OperacaoService(_context);
            var sPosicao = new PosicaoService(_context);

            var taxaIR = 20; 
            //DARF com código da receita 6015 com minimo de  reais até ultimo util dia do mes seguinte a de operacao
            var quantidadeDeCotasVendidas = 0;
            var precoUnitarioDeVenda = 0;
            var precoMedioDeCompra = 0;
            var custoDaOperacao = 0; //taxas e emolumentos

            //Calculo para Imposto de Renda de Fundos imobiliarios
            var COMPRA = TipoOperacao.Compra;
            var XP = new Corretora("XP INVESTIMENTOS");

            var AAAA11 = new Ativo("AAAA11", "AAAA11", TipoInvestimento.RendaVariavel, TipoPapel.FundoImobiliario);
            var BBBB11 = new Ativo("BBBB11", "BBBB11", TipoInvestimento.RendaVariavel, TipoPapel.FundoImobiliario);
            var CCCC11 = new Ativo("CCCC11", "CCCC11", TipoInvestimento.RendaVariavel, TipoPapel.FundoImobiliario);

            var Op1 = new Operacao(AAAA11, XP, 20, 101.20M, COMPRA, new DateTime(2017, 08, 04), 5.53M);
            var Op2 = new Operacao(BBBB11, XP, 31,  83.45M, COMPRA, new DateTime(2017, 08, 09), 6.45M);
            var Op3 = new Operacao(BBBB11, XP, 27,  82.01M, COMPRA, new DateTime(2017, 08, 18), 5.64M);
            var Op4 = new Operacao(CCCC11, XP, 14, 234.72M, COMPRA, new DateTime(2017, 08, 18), 7.12M);
            var Op5 = new Operacao(AAAA11, XP, 15,  98.88M, COMPRA, new DateTime(2017, 09, 05), 4.87M);
            var Op6 = new Operacao(AAAA11, XP, 12, 103.32M, COMPRA, new DateTime(2017, 09, 22), 3.65M);
            var Op7 = new Operacao(CCCC11, XP, 09, 219.18M, COMPRA, new DateTime(2017, 09, 22), 5.45M);

            Assert.AreEqual(101.48M, Op1.CustoMedioOperacao); 
            Assert.AreEqual(2029.53M, Op1.CustoOperacao);
            sOperacao.Salvar(Op1);
            Assert.AreEqual(20, Op1.SaldoCotas);

            Assert.AreEqual(83.66M, Op2.CustoMedioOperacao); 
            Assert.AreEqual(2593.40M, Op2.CustoOperacao);
            sOperacao.Salvar(Op2);
            Assert.AreEqual(31, Op2.SaldoCotas);

            Assert.AreEqual(82.22M, Op3.CustoMedioOperacao); 
            Assert.AreEqual(2219.91M, Op3.CustoOperacao);
            sOperacao.Salvar(Op3);
            Assert.AreEqual(58, Op3.SaldoCotas);

            Assert.AreEqual(235.23M, Op4.CustoMedioOperacao); 
            Assert.AreEqual(3293.20M, Op4.CustoOperacao);
            sOperacao.Salvar(Op4);
            Assert.AreEqual(14, Op4.SaldoCotas);

            Assert.AreEqual(99.20M, Op5.CustoMedioOperacao);
            Assert.AreEqual(1488.07M, Op5.CustoOperacao);
            sOperacao.Salvar(Op5);
            Assert.AreEqual(35, Op5.SaldoCotas);

            Assert.AreEqual(103.62M, Op6.CustoMedioOperacao);
            Assert.AreEqual(1243.49M, Op6.CustoOperacao);
            sOperacao.Salvar(Op6);
            Assert.AreEqual(47, Op6.SaldoCotas);

            Assert.AreEqual(219.79M, Op7.CustoMedioOperacao);
            Assert.AreEqual(1978.07M, Op7.CustoOperacao);
            sOperacao.Salvar(Op7);
            Assert.AreEqual(23, Op7.SaldoCotas);

            var posicaoAtual = sPosicao.PosicaoFII();

            Assert.AreEqual("AAAA11", posicaoAtual[0].Sigla);
            Assert.AreEqual(47, posicaoAtual[0].QuantidadeCotas);
            Assert.AreEqual(101.30M, posicaoAtual[0].PrecoMedioAquisicao);
            Assert.AreEqual(4761.10M, posicaoAtual[0].ValorPosicao);

            Assert.AreEqual("BBBB11", posicaoAtual[1].Sigla);
            Assert.AreEqual(58, posicaoAtual[1].QuantidadeCotas);
            Assert.AreEqual(82.99M, posicaoAtual[1].PrecoMedioAquisicao);
            Assert.AreEqual(4813.42M, posicaoAtual[1].ValorPosicao);

            Assert.AreEqual("CCCC11", posicaoAtual[2].Sigla);
            Assert.AreEqual(23, posicaoAtual[2].QuantidadeCotas);
            Assert.AreEqual(229.19M, posicaoAtual[2].PrecoMedioAquisicao);
            Assert.AreEqual(5271.37M, posicaoAtual[2].ValorPosicao);
            //var operacoesPorMes = operacoeComFundodImobiliarios.GroupBy(o => new { o.Data.Month, o.Data.Year }).ToList();

            //foreach (var noMes in operacoesPorMes)
            //{
            //    var compras = noMes.Where(o => o.TipoOperacao == TipoOperacao.Compra);
            //    var vendas = noMes.Where(o => o.TipoOperacao == TipoOperacao.Venda);
            //}
        }


        //Depois alterar para teste do serviço
        [TestMethod]
        public void DeveCalcularPrecoMedioDeVendaAposDuasOperacoresDeCompra()
        {
            var dOperacao = new OperacaoDefault();

            var rOperacao = new OperacaoRepository(_context);
            var sOperacao = new OperacaoService(_context);

            var primeiraOperacao = dOperacao._operacoes.Where(m => m.Ativo.Sigla == "BCIA11").FirstOrDefault();

            //primeiraOperacao.CustoMedio = sOperacao.CalcularCustoMedio(primeiraOperacao);

            rOperacao.Adicionar(primeiraOperacao);
            rOperacao.Salvar();

            double custoMedioEsperado = 128.08;
            double delta = 0.01;

            var operacaoSalvaNobanco = rOperacao.Buscar(o => o.Ativo.Sigla == "BCIA11").FirstOrDefault();

            //Assert.AreEqual(custoMedioEsperado, (double)operacaoSalvaNobanco.CustoMedio, delta);

            //Segunda Operação
            var segundaOperacao = dOperacao._operacoes.Where(m => m.Ativo.Sigla == "BCIA11").Skip(1).FirstOrDefault();
            //segundaOperacao.CustoMedio = sOperacao.CalcularCustoMedio(segundaOperacao);

            double novoCustoMedioEsperado = 120.04;

            rOperacao.Adicionar(segundaOperacao);
            rOperacao.Salvar();

            var ultimaOperacaoSalvaNobanco = rOperacao.Buscar(o => o.Ativo.Sigla == "BCIA11").OrderBy(m => m.Id).LastOrDefault();

            //Assert.AreEqual(novoCustoMedioEsperado, (double)ultimaOperacaoSalvaNobanco.CustoMedio, delta);

            var terceiraOperacao = dOperacao._operacoes.Where(m => m.Ativo.Sigla == "BCIA11").Skip(2).FirstOrDefault();
            //terceiraOperacao.CustoMedio = sOperacao.CalcularCustoMedio(terceiraOperacao);

            double custoMedioAposVenda = 120.04;

            rOperacao.Adicionar(terceiraOperacao);
            rOperacao.Salvar();

            //Assert.AreEqual(custoMedioAposVenda, (double)ultimaOperacaoSalvaNobanco.CustoMedio, delta);
        }

        //Depois alterar para teste do serviço
        [TestMethod]
        public void DeveCalcularPrecoMedioDaSegundaCompraDoMesmoAtivo()
        {
            var dOperacao = new OperacaoDefault();

            var rOperacao = new OperacaoRepository(_context);
            var sOperacao = new OperacaoService(_context);

            var primeiraOperacao = dOperacao._operacoes.Where(m => m.Ativo.Sigla == "BCIA11").FirstOrDefault();

            //primeiraOperacao.CustoMedio = sOperacao.CalcularCustoMedio(primeiraOperacao);

            rOperacao.Adicionar(primeiraOperacao);
            rOperacao.Salvar();

            double custoMedioEsperado = 128.08;
            double delta = 0.01;

            var operacaoSalvaNobanco = rOperacao.Buscar(o => o.Ativo.Sigla == "BCIA11").FirstOrDefault();

            //Assert.AreEqual(custoMedioEsperado, (double)operacaoSalvaNobanco.CustoMedio, delta);

            //Segunda Operação
            var segundaOperacao = dOperacao._operacoes.Where(m => m.Ativo.Sigla == "BCIA11").Skip(1).FirstOrDefault();
            //segundaOperacao.CustoMedio = sOperacao.CalcularCustoMedio(segundaOperacao);

            double novoCustoMedioEsperado = 120.04;

            rOperacao.Adicionar(segundaOperacao);
            rOperacao.Salvar();

            var ultimaOperacaoSalvaNobanco = rOperacao.Buscar(o => o.Ativo.Sigla == "BCIA11").OrderBy(m => m.Id).LastOrDefault();

            //Assert.AreEqual(novoCustoMedioEsperado, (double)ultimaOperacaoSalvaNobanco.CustoMedio, delta);
        }

        [TestMethod]
        public void DeveCalcularPrecoMedioDoPrimeiroAticoComprado()
        {
            var dOperacao = new OperacaoDefault();

            var rOperacao = new OperacaoRepository(_context);
            var sOperacao = new OperacaoService(_context);

            var primeiraOperacao = dOperacao._operacoes.Where(m => m.Ativo.Sigla == "BCIA11").FirstOrDefault();

            //primeiraOperacao.CustoMedio = sOperacao.CalcularCustoMedio(primeiraOperacao);


            rOperacao.Adicionar(primeiraOperacao);
            rOperacao.Salvar();


            double custoMedioEsperado = 128.08;
            double delta = 0.01;

            var operacaoSalvaNobanco = rOperacao.Buscar(o => o.Ativo.Sigla == "BCIA11").FirstOrDefault();

            //Assert.AreEqual(custoMedioEsperado, (double)operacaoSalvaNobanco.CustoMedio, delta);
        }


        [ClassCleanup]
        public static void TestFixtureTearDown()
        {
            _context.Database.EnsureDeleted();
        }
    }
}
