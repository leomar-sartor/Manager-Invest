﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Carteira.Entity;
using Carteira.Entity.Contexto;
using Carteira.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Carteira.Areas.Usuario.Controllers
{
    [Area("Usuario")]
    public class MeusAtivosController : Controller
    {
        private readonly Context _ctx;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly AtivoRepository _rAtivo;

        public MeusAtivosController(UserManager<ApplicationUser> userManager)
        {
            _ctx = new Context();
            _userManager = userManager;
            _rAtivo = new AtivoRepository(_ctx);
        }

        public IActionResult Index()
        {
            
            var ativos = _ctx.Ativos.ToList();

            //var userLogado =
            //    _userManager.FindByNameAsync(HttpContext.User.Identity.Name).Result;

            return View(ativos);
        }

        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm] Ativo ativo)
        {
            if (ModelState.IsValid)
            {
                await _ctx.Ativos.AddAsync(ativo);

                await _ctx.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(ativo);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var ativo = await _ctx.Ativos.FirstOrDefaultAsync(m => m.Id == id);

            if (ativo == null)
                ativo = new Ativo();

            return View(ativo);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Ativo ativo)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _ctx.Ativos.Update(ativo);
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
            var ativo = await _ctx.Ativos
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
            _rAtivo.Excluir(m => m.Id == id);
            _rAtivo.Salvar();

            return RedirectToAction(nameof(Index));
        }
    }
}