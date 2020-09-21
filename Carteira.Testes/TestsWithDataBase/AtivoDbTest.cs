using Carteira.Entity.Contexto;
using Carteira.Entity.Enuns;
using Carteira.Repository;
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
    public class AtivoDbTest
    {
        private static Context _context;

        [ClassInitialize]
        public static void TestFixtureSetup(TestContext context)
        {
            _context = new Context(true);
            _context.Database.EnsureCreated();
        }

        [TestMethod]
        public async Task DeveCadastraDezAtivoVariadosDB()
        {
            var dAtivo = new AtivoDefault();

            var rAtivo = new AtivoRepository(_context);

            var listaDeAtivos = dAtivo._ativos;

            await rAtivo.AdicionarAsync(listaDeAtivos);

            await rAtivo.SalvarAsync();

            var ativosBanco = await rAtivo.ListarAsync();

            Assert.AreEqual(10, ativosBanco.Count);

            Assert.AreEqual("BPAN4", ativosBanco[0].Sigla);
            Assert.AreEqual("NEOE3", ativosBanco[1].Sigla);
            Assert.AreEqual("BCIA11", ativosBanco[2].Sigla);
            Assert.AreEqual("BCFF11", ativosBanco[3].Sigla);
            Assert.AreEqual("FEXC11", ativosBanco[4].Sigla);
            Assert.AreEqual("IRDM11", ativosBanco[5].Sigla);
            Assert.AreEqual("LTN", ativosBanco[6].Sigla);
            Assert.AreEqual("LFT", ativosBanco[7].Sigla);
            Assert.AreEqual("NTN-B PRINCIPAL", ativosBanco[8].Sigla);
            Assert.AreEqual("NTN-B", ativosBanco[9].Sigla);

            ativosBanco.ForEach(async a => await rAtivo.ExcluirAsync(ap => ap.Id == a.Id));

            await rAtivo.SalvarAsync();
        }

        [TestMethod]
        public async Task DeveEditarUmAtivoRendaVariavelAcaoDB()
        {
            var dAtivo = new AtivoDefault();

            var rAtivo = new AtivoRepository(_context);

            var Ativo = dAtivo._ativos.Where(a => a.TipoPapel == TipoPapel.Acao).First();

            await rAtivo.AdicionarAsync(Ativo);

            await rAtivo.SalvarAsync();

            var ativoDoBanco = rAtivo.Listar().Where(a => a.TipoPapel == TipoPapel.Acao).First();

            ativoDoBanco.Nome = "Banco do Brasil";
            ativoDoBanco.Sigla = "bbas3";

            await rAtivo.AtualizarAsync(ativoDoBanco);

            var ativoDoBancoAtualizado = rAtivo.Listar().Where(a => a.TipoPapel == TipoPapel.Acao).First();

            Assert.AreEqual(ativoDoBanco.Id, ativoDoBancoAtualizado.Id);
            Assert.AreEqual("Banco do Brasil", ativoDoBancoAtualizado.Nome);
            Assert.AreEqual("BBAS3", ativoDoBancoAtualizado.Sigla);

            await rAtivo.ExcluirAsync(a => a.Id == ativoDoBancoAtualizado.Id);
        }

        [TestMethod]
        public async Task DeveEditarUmAtivoRendaVariavelFundoImobiliarioParaRendaFixaTesouroDiretoDB()
        {
            var dAtivo = new AtivoDefault();

            var rAtivo = new AtivoRepository(_context);

            var Ativo = dAtivo._ativos.Where(a => a.TipoPapel == TipoPapel.Acao).First();

            await rAtivo.AdicionarAsync(Ativo);

            await rAtivo.SalvarAsync();

            var ativoDoBanco = rAtivo.Listar().Where(a => a.TipoPapel == TipoPapel.Acao).First();

            ativoDoBanco.Nome = "Tesouro Selic";
            ativoDoBanco.Sigla = "LFT";
            ativoDoBanco.TipoInvestimento = TipoInvestimento.RendaFixa;
            ativoDoBanco.TipoPapel = TipoPapel.TesouroDireto;

            await rAtivo.AtualizarAsync(ativoDoBanco);

            var ativoDoBancoAtualizado = rAtivo.Listar().Where(a => a.TipoPapel == TipoPapel.TesouroDireto).First();

            Assert.AreEqual(ativoDoBanco.Id, ativoDoBancoAtualizado.Id);
            Assert.AreEqual("Tesouro Selic", ativoDoBancoAtualizado.Nome);
            Assert.AreEqual("LFT", ativoDoBancoAtualizado.Sigla);
            Assert.AreEqual(TipoInvestimento.RendaFixa, ativoDoBancoAtualizado.TipoInvestimento);
            Assert.AreEqual(TipoPapel.TesouroDireto, ativoDoBancoAtualizado.TipoPapel);

            await rAtivo.ExcluirAsync(a => a.Id == ativoDoBancoAtualizado.Id);
        }

        [TestMethod]
        public async Task DeveExcluirTodoAtivosDB()
        {
            var dAtivo = new AtivoDefault();

            var rAtivo = new AtivoRepository(_context);

            var listaDeAtivos = dAtivo._ativos;

            await rAtivo.AdicionarAsync(listaDeAtivos);

            await rAtivo.SalvarAsync();

            var ativosBanco = await rAtivo.ListarAsync();

            foreach (var item in ativosBanco)
            {
                await rAtivo.ExcluirAsync(a => a.Id == item.Id);
            }
           
            await rAtivo.SalvarAsync();

            var AtivosNoBanco = await rAtivo.ListarAsync();

            Assert.AreEqual(0, AtivosNoBanco.Count());
        }

        [ClassCleanup]
        public static void TestFixtureTearDown()
        {
            _context.Database.EnsureDeleted();
        }
    }
}
