using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Carteira.Models;

namespace Carteira.Controllers
{

    /// <summary>
    /// Para estudar 
    /// https://blog.kloud.com.au/2017/02/14/running-vuejs-on-aspnet-core-apps/
    /// </summary>
    public class VuetifyController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public VuetifyController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

