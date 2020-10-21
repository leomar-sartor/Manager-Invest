using Carteira.Entity;
using Carteira.Entity.Contexto;
using Carteira.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Carteira.Areas.Administrador.Controllers
{
    [Area("Administrador")]
    //[Authorize(Roles = "Administrador")]
    public class CorretoraController : Controller
    {
        private readonly Context _context;
        public CorretoraController(Context context)
        {
            _context = context;
        }

        //FAZER FORM ASSIM: https://codepen.io/andiio/pen/tFECp

        // GET: Arquivoes/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var corretora = await _context.Corretoras
                .FirstOrDefaultAsync(m => m.Id == id);

            if (corretora == null)
            {
                return NotFound();
            }

            return View(corretora);
        }


        public IActionResult Index(CorretoraFiltro filtro)
        {
            if (filtro == null)
            {
                filtro = new CorretoraFiltro();
            }
            else
            {
                var corretoras = _context.Corretoras.ToList();
                filtro.Corretoras = corretoras;
            }

            return View(filtro);
        }

        private PropertyInfo getProperty(string name)
        {
            var properties = typeof(Carteira.Entity.Corretora).GetProperties();
            PropertyInfo prop = null;
            foreach (var item in properties)
            {
                if (item.Name.ToLower().Equals(name.ToLower()))
                {
                    prop = item;
                    break;
                }

            }

            return prop;
        }

        //CLasse em javascript e mix-ins
        //https://developer.mozilla.org/pt-BR/docs/Web/JavaScript/Reference/Classes
        [HttpPost]
        public IActionResult Pagination()
        {

            List<Corretora> corretoras = _context.Corretoras.ToList();
            var totalCorretoras = corretoras.Count();

            var skip = Convert.ToInt32(Request.Form["start"].ToString());
            var pageSize = Convert.ToInt32(Request.Form["length"].ToString());


            StringValues tempOrder = new StringValues();

            if (Request.Form.TryGetValue("order[0][column]", out tempOrder))
            {
                var columnIndex = Request.Form["order[0][column]"].ToString();
                var sortDirection = Request.Form["order[0][dir]"].ToString();

                if (Request.Form.TryGetValue($"columns[{columnIndex}][data]", out tempOrder))
                {
                    var columnName = Request.Form[$"columns[{columnIndex}][data]"].ToString();

                    if (pageSize > 0)
                    {
                        var prop = getProperty(columnName);
                        if (sortDirection == "asc")
                        {
                            corretoras = corretoras.OrderBy(prop.GetValue).Skip(skip).Take(pageSize).ToList();
                        }
                        else
                        {
                            corretoras = corretoras.OrderByDescending(prop.GetValue).Skip(skip).Take(pageSize).ToList();
                        }
                    }
                }
            }

            //estudar json => https://codeburst.io/working-with-json-in-net-core-3-2fd1236126c1
            //https://exceptionnotfound.net/asp-net-core-demystified-action-results/
            //var draw = Request.Form.Keys;

            //Request.Form.TryGetValues()
            //corretoras = _context.Corretoras.ToList();

            //var jsonSettings = new JsonSerializerSettings
            //{
            //};

            //var corJsno =  Json(corretoras, jsonSettings);


            //var options = new JsonSerializerSettings
            //{

            //};

            //var js = Json(corretoras);
            //var jsonString = File.ReadAllText("my-model.json");
            //var jsonModel = JsonSerializer.Deserialize<Corretora>(corretoras, options);
            //var modelJson = JsonSerializer.Serialize(js, options);


            //return Json(corretoras);

            dynamic response = new
            {
                Data = corretoras,
                Draw = Request.Form["draw"],
                RecordsFiltered = totalCorretoras,
                RecordsTotal = totalCorretoras
            };

            return Ok(response);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var corretora = await _context.Corretoras.FirstOrDefaultAsync(m => m.Id == id);

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
                    _context.Corretoras.Update(corretora);
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


        // GET: Arquivoes/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Corretora corretora)
        {
            if (ModelState.IsValid)
            {
                await _context.Corretoras.AddAsync(corretora);

                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            return View(corretora);
        }

        // POST: Arquivoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var corretora = await _context.Corretoras.FindAsync(id);
            _context.Corretoras.Remove(corretora);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}