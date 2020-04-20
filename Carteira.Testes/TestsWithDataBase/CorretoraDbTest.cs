using Carteira.Domain.Contexto;
using Carteira.Repository;
using Carteira.Testes.Utilitarios.ObjectDefault;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace Carteira.Testes.TestsWithDataBase
{
    [TestClass]
    public class CorretoraDbTest
    {
        private static Context _context;

        [ClassInitialize]
        public static void TestFixtureSetup(TestContext context)
        {
            _context = new Context(true);
            _context.Database.EnsureCreated();
        }

        [TestMethod]
        public async Task DeveCadastraUmaCorretoraDB()
        {
            var corretora = new CorretoraDefault();

            var rCorretora = new CorretoraRepository(_context);

            var listaCorretoras = corretora._corretoras;

            await rCorretora.AdicionarAsync(listaCorretoras);

            await rCorretora.SalvarAsync();

            var retornoDoBanco = await rCorretora.ListarAsync();

            Assert.AreEqual(2, retornoDoBanco.Count);

            Assert.AreEqual("XP Investimentos", retornoDoBanco[0].Nome);
            Assert.AreEqual("Clear Corretora", retornoDoBanco[1].Nome);

            //listaCorretoras.ForEach(async a => await rCorretora.ExcluirAsync(ap => ap.Id == a.Id));

            await rCorretora.SalvarAsync();
        }

        [ClassCleanup]
        public static void TestFixtureTearDown()
        {
            _context.Database.EnsureDeleted();
        }
    }
}
