using Carteira.Domain;
using Carteira.Domain.Contexto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Carteira.Controllers
{
    public class AtivoController : Controller
    {
        private readonly Context _context;
        public AtivoController(Context context)
        {
            _context = context;
        }

        // https://codingblast.com/asp-net-core-mvc-custom-tag-helpers/
        // https://www.yogihosting.com/aspnet-core-custom-tag-helpers/

        public IActionResult Index()
        {
            var ativos = _context.Ativos.ToList();

            return View(ativos);
        }

        public IActionResult Create()
        {
            //https://www.learnrazorpages.com/razor-pages/tag-helpers/select-tag-helper
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Ativo ativo)
        {
            if (ModelState.IsValid)
            {
                await _context.Ativos.AddAsync(ativo);

                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(ativo);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var corretora = await _context.Ativos.FirstOrDefaultAsync(m => m.Id == id);

            if (corretora == null)
                corretora = new Ativo();

            return View(corretora);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Ativo ativo)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Ativos.Update(ativo);
                    await _context.SaveChangesAsync();
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
            var ativo = await _context.Ativos
                .FirstOrDefaultAsync(m => m.Id == id);

            if (ativo == null)
            {
                return NotFound();
            }

            return View(ativo);
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
            var ativo = await _context.Ativos.FindAsync(id);
            _context.Ativos.Remove(ativo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}



