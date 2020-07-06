using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Carteira.Controllers
{
    public class AtController : Controller
    {
        // GET: At
        public ActionResult Index()
        {
            return View();
        }

        // GET: At/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: At/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: At/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: At/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: At/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: At/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: At/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}