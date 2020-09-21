using Carteira.Entity.Contexto;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Carteira.Testes.TestsWithDataBase.Services
{
    [TestClass]
    public class PosicaoDbTest
    {
        private static Context _context;
        

        [ClassInitialize]
        public static void TestFixtureSetup(TestContext context)
        {
            _context = new Context(true);
            _context.Database.EnsureCreated();
        }


        [TestMethod]
        public void DeveRetornarTodoODinheiroAplicadoDB()
        {
            
        }

        [ClassCleanup]
        public static void TestFixtureTearDown()
        {
            _context.Database.EnsureDeleted();
        }
    }
}
