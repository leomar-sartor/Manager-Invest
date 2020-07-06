using Carteira.Domain.Contexto;
using Carteira.Repository;
using Carteira.Testes.Utilitarios.ObjectDefault;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
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



        [ClassCleanup]
        public static void TestFixtureTearDown()
        {
            _context.Database.EnsureDeleted();
        }
    }
}
