using Carteira.Entity;
using Carteira.Entity.Contexto;
using Carteira.Repository;
using Carteira.Service;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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
            return View();
        }

        //http://www.macoratti.net/19/09/aspc_updrel1.htm

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm] Operacao operacao)
        {
            if (ModelState.IsValid)
            {
                _sOpercao.Salvar(operacao);

                return RedirectToAction(nameof(Index));
            }

            return View(operacao);
        }
    }
}
