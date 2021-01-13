using Carteira.Entity;
using Carteira.Entity.Contexto;
using Carteira.Repository;
using Carteira.Service;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carteira.Areas.Usuario.Controllers
{
    [Area("Usuario")]
    public class OperacoesController : Controller
    {
        private readonly Context _ctx;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly OperacaoRepository _rOperacao;
        private readonly OperacaoService _sOpercao;

        public OperacoesController(UserManager<ApplicationUser> userManager)
        {
            _ctx = new Context();
            _userManager = userManager;
            _rOperacao = new OperacaoRepository(_ctx);
            _sOpercao = new OperacaoService(_ctx);
        }

        public IActionResult Index()
        {
            var operacoes = _rOperacao.Listar();

            return View(operacoes);
        }

        public IActionResult Create()
        {
            ViewBag.Corretoras = _ctx.Corretoras
                .Select(m => new SelectListItem() { Text = m.Nome, Value = m.Id.ToString() }).ToList();

            ViewBag.Ativos = _ctx.Ativos
               .Select(m => new SelectListItem() { Text = m.Nome, Value = m.Id.ToString() }).ToList();

            return View();
        }

        //http://www.macoratti.net/19/09/aspc_updrel1.htm

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm] Operacao operacao)
        {
            if (ModelState.IsValid)
            {
                operacao.Data = DateTime.Today;
                operacao.Corretora = _ctx.Corretoras.Where(m => m.Id == operacao.Corretora.Id).FirstOrDefault();
                operacao.Ativo = _ctx.Ativos.Where(m => m.Id == operacao.Ativo.Id).FirstOrDefault();

                _sOpercao.Salvar(operacao);

                return RedirectToAction(nameof(Index));
            }

            return View(operacao);
        }

        public async Task<IActionResult> Edit(int id)
        {
            ViewBag.Corretoras = _ctx.Corretoras
               .Select(m => new SelectListItem() { Text = m.Nome, Value = m.Id.ToString() }).ToList();

            ViewBag.Ativos = _ctx.Ativos
               .Select(m => new SelectListItem() { Text = m.Nome, Value = m.Id.ToString() }).ToList();

            var operacao = await _ctx.Operacoes.FirstOrDefaultAsync(m => m.Id == id);

            if (operacao == null)
                operacao = new Operacao();

            return View(operacao);
        }

        [HttpPost]
        public async Task<IActionResult> Edit([FromForm] Operacao operacao)
        {
            //https://letsgoti.wordpress.com/2016/04/11/manipulacao-de-valores-monetarios-em-mvc/
            //http://cleytonferrari.com/validacao-de-data-e-moeda-asp-net-mvc-jquery-validation-em-portugues/
            if (ModelState.IsValid)
            {
                try
                {
                    operacao.Corretora = _ctx.Corretoras.Where(m => m.Id == operacao.Corretora.Id).FirstOrDefault();
                    operacao.Ativo = _ctx.Ativos.Where(m => m.Id == operacao.Ativo.Id).FirstOrDefault();

                    _ctx.Operacoes.Update(operacao);
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


    }
}
