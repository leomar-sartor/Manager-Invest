using Carteira.Domain.Contexto;
using Carteira.Testes.Utilitarios.ObjectDefault;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Carteira.Testes.Utilitarios;
using Carteira.Testes.Utilitarios.Mocks;

namespace Carteira.Testes.TestWithMock
{
    [TestFixture]
    public class CorretoraTest
    {
        private CorretoraDefault _corretora;

        [Test]
        public void DeveCadastraUmaCorretoraMockado()
        {
            _corretora = new CorretoraDefault();

            var mock = new ContextMock();

            var corretoras = mock._rCorretoraMock.Object.Listar();

            NUnit.Framework.Assert.AreEqual(2, corretoras.Count);
            NUnit.Framework.Assert.AreEqual("XP Investimentos", corretoras[0].Nome);
            NUnit.Framework.Assert.AreEqual("Clear Corretora", corretoras[1].Nome);
        }
    }
}
