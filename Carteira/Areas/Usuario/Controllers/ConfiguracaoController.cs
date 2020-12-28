using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Carteira.Entity;
using Carteira.Entity.Contexto;
using Carteira.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Carteira.Areas.Usuario.Controllers
{
    [Area("Usuario")]
    public class ConfiguracaoController : Controller
    {
        private readonly Context _ctx;
        private readonly ConfiguracaoRepository _rConfiguracao;

        public ConfiguracaoController()
        {
            _ctx = new Context();
            _rConfiguracao = new ConfiguracaoRepository(_ctx);
        }
        public IActionResult Index()
        {
            var configuracao = _rConfiguracao.Listar();

            return View(configuracao);
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm] Configuracao conf)
        {
            if (ModelState.IsValid)
            {
                await _ctx.Configuracoes.AddAsync(conf);

                await _ctx.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(conf);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var configuracao = await _ctx.Configuracoes.FirstOrDefaultAsync(m => m.Id == id);

            if (configuracao == null)
                configuracao = new Configuracao();

            return View(configuracao);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Configuracao configuracao)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _ctx.Configuracoes.Update(configuracao);
                    await _ctx.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException e)
                {
                    throw new Exception(e.InnerException.Message);
                }
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int id)
        {
            var configuracao = await _ctx.Configuracoes
                .FirstOrDefaultAsync(m => m.Id == id);

            if (configuracao == null)
            {
                return NotFound();
            }

            return View(configuracao);
        }

        // GET: At/Delete/5
        public ActionResult Delete(long id)
        {
            return View();
        }

        // POST: Arquivoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            _rConfiguracao.Excluir(m => m.Id == id);
            _rConfiguracao.Salvar();

            return RedirectToAction(nameof(Index));
        }
    }
}