using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Carteira.Entity.Contexto;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Carteira.Areas.Usuario.Controllers
{
    [Area("Usuario")]
    public class MeusAtivosController : Controller
    {
        private readonly Context _ctx;
        private readonly UserManager<ApplicationUser> _userManager;
        //private readonly ConfiguracaoRepository _rConfiguracao;

        public MeusAtivosController(UserManager<ApplicationUser> userManager)
        {
            _ctx = new Context();
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            
            ViewBag.Ativos = _ctx.Ativos.ToList();

            var userLogado =
                _userManager.FindByNameAsync(HttpContext.User.Identity.Name).Result;

            var meusAtivos = _ctx.AtivosUsuario.Where(m => m.UsuairoId == userLogado.Id).ToList();

            return View(meusAtivos);
        }


    }
}
