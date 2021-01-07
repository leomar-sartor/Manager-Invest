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
    public class CorretoraController : Controller
    {
        private readonly Context _ctx;
        private readonly CorretoraRepository _rCorretora;

        public CorretoraController()
        {
            _ctx = new Context();
            _rCorretora = new CorretoraRepository(_ctx);
        }
        public IActionResult Index()
        {
            var corretora = _rCorretora.Listar();

            return View(corretora);
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm] Corretora corretora)
        {
            if (ModelState.IsValid)
            {
                await _ctx.Corretoras.AddAsync(corretora);

                await _ctx.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(corretora);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var corretora = await _ctx.Corretoras.FirstOrDefaultAsync(m => m.Id == id);

            if (corretora == null)
                corretora = new Corretora();

            return View(corretora);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Corretora corretora)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _ctx.Corretoras.Update(corretora);
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
            var corretora = await _ctx.Corretoras
                .FirstOrDefaultAsync(m => m.Id == id);

            if (corretora == null)
            {
                return NotFound();
            }

            return View(corretora);
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
            _rCorretora.Excluir(m => m.Id == id);
            _rCorretora.Salvar();

            return RedirectToAction(nameof(Index));
        }
    }
}
