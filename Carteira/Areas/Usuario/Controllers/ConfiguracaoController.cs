using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Carteira.Entity.Contexto;
using Carteira.Repository;
using Microsoft.AspNetCore.Mvc;

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
            var configuracao = _rConfiguracao.Listar().FirstOrDefault();

            return View(configuracao);
        }
    }
}