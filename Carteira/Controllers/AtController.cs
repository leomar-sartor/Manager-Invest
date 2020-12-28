using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Carteira.Models;
using Carteira.Utility;
using DinkToPdf;
using DinkToPdf.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Carteira.Controllers
{
    public class AtController : Controller
    {

        //DINK TO PDF
        //https://code-maze.com/create-pdf-dotnetcore/
        //https://github.com/rdvojmoc/DinkToPdf/releases/tag/v1.0.8
        //https://medium.com/volosoft/convert-html-and-export-to-pdf-using-dinktopdf-on-asp-net-boilerplate-e2354676b357
        //https://medium.com/@erikthiago/gerador-de-pdf-no-asp-net-core-e494650eb3c9
        //https://stackoverflow.com/questions/61726433/dinktopdf-html-div-on-one-pdf-page
        //https://stackoverflow.com/questions/55419335/separating-page-breaks-with-dinktopdf
        //https://github.com/worlduniting/bookshop/wiki/wkhtmltopdf-options
        //https://www.csharpcodi.com/csharp-examples/DinkToPdf.BasicConverter.ApplyConfig(System.IntPtr,%20ISettings,%20bool)/
        //https://wkhtmltopdf.org/libwkhtmltox/pagesettings.html#pagePdfObject
        private IConverter _converter;

        private readonly IViewRenderService _viewRenderService;
        //private IConverter _converter;

        //public AtController(IConverter converter)
        //{
        //    _converter = converter;
        //}

        public AtController(IViewRenderService viewRenderService, IConverter converter)
        {
            _viewRenderService = viewRenderService;
            _converter = converter;
        }

        // GET: At
        public ActionResult Index()
        {
            var globalSettings = new GlobalSettings
            {
                ColorMode = ColorMode.Color,
                Orientation = Orientation.Portrait,
                PaperSize = PaperKind.A4,
                Margins = new MarginSettings { Top = 15},
                DocumentTitle = "FIRST PDF"
            };

            var objectSettings = new ObjectSettings
            {
                PagesCount = true,
                HtmlContent = TemplateGenerator.GetHTMLString(),
                //Page = "https://code-maze.com/",
                WebSettings = { DefaultEncoding = "utf-8", UserStyleSheet = Path.Combine(Directory.GetCurrentDirectory(), "assets", "styles.css") },
                HeaderSettings = { Spacing = 0, FontName = "Arial", FontSize = 15, Right = "Pag. [page] de [toPage]", Line = true, Center = "TESTE LEOMAR" },
                FooterSettings = { FontName = "Arial", FontSize = 9, Line = true, Center = "Rodapé" },
            };

            var pdf = new HtmlToPdfDocument()
            {
                GlobalSettings = globalSettings,
                Objects = { objectSettings }
            };

            var file = _converter.Convert(pdf);

            //return Ok("Sucessfuly created your First PDF Document");
            //return File(file, "application/pdf", "EmployeeReport.pdf");
            return File(file, "application/pdf");
        }

        // GET: At/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: At/Create
        public async Task<ActionResult> CreateAsync()
        {
            Employee empregado = new Employee()
            {
                Name = "Leomar",
                LastName = "Sartor",
                Age = 27,
                Gender = "Male"
            };

            var employees = DataStorage.GetEmployees();

            var arq = await _viewRenderService.RenderToStringAsync("Create", employees);

            var doc = new HtmlToPdfDocument()
            {
                GlobalSettings = {
                ColorMode = ColorMode.Color,
                Orientation = Orientation.Landscape,
                PaperSize = PaperKind.A4Plus,
                Margins = new MarginSettings{ Top = 25.000, Left= 15.000, Bottom = 25.000 }
            },
                Objects = {
                    new ObjectSettings() {
                        PagesCount = true,
                        HtmlContent = arq,
                        WebSettings = { DefaultEncoding = "utf-8" },
                        HeaderSettings = { FontName = "Arial", FontSize = 9, Right = "Página [page] de [toPage]", Line = true, Spacing = 5.000},
                        //, Spacing = -13.000 
                        FooterSettings = { FontName = "Arial", FontSize = 9, Line = true, Center = "Report Footer", Spacing = 10.000 },
                    }
                }
            };

            byte[] pdf = _converter.Convert(doc);

            return File(pdf, "application/pdf");
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
        public ActionResult Edit()
        {
            var globalSettings = new GlobalSettings
            {
                ColorMode = ColorMode.Color,
                Orientation = Orientation.Portrait,
                PaperSize = PaperKind.A4,
                Margins = new MarginSettings { Top = 1, Bottom = 0, Left = 0, Right = 0 },
                DocumentTitle = "FIRST PDF"
                //Out = @"C:\Projetos\Employee_Report.pdf"
            };

            var dados = DataStorage.GetEmployees();

            
            var relatorio = new RelatorioTemplate();


            var objectSettings = new ObjectSettings
            {
                //PagesCount = true,
                //HtmlContent = relatorio.Layout(),
                //Page = "https://code-maze.com/",
                WebSettings = { DefaultEncoding = "utf-8", UserStyleSheet = Path.Combine(Directory.GetCurrentDirectory(), "assets", "styles.css") },
                //HeaderSettings = { FontName = "Arial", FontSize = 9, Right = "Page [page] of [toPage]", Line = true },
                //FooterSettings = { FontName = "Arial", FontSize = 9, Line = true, Center = "Report Footer" },
            };

            var pdf = new HtmlToPdfDocument()
            {
                GlobalSettings = globalSettings,
                Objects = { objectSettings }
            };

            var file = _converter.Convert(pdf);

            //return Ok("Sucessfuly created your First PDF Document");
            //return File(file, "application/pdf", "EmployeeReport.pdf");
            return File(file, "application/pdf");
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
        public ActionResult Delete()
        {
            var globalSettings = new GlobalSettings
            {
                ColorMode = ColorMode.Color,
                Orientation = Orientation.Portrait,
                PaperSize = PaperKind.A4,
                Margins = new MarginSettings { Top = 1, Bottom = 0, Left = 0, Right = 0 },
                DocumentTitle = "FIRST PDF"
                //Out = @"C:\Projetos\Employee_Report.pdf"
            };

            var dados = DataStorage.GetEmployees();

            var objectSettings = new ObjectSettings
            {
                //PagesCount = true,
                HtmlContent = TemplateLeomar.GeneratePDF(dados),
                //Page = "https://code-maze.com/",
                WebSettings = { DefaultEncoding = "utf-8", UserStyleSheet = Path.Combine(Directory.GetCurrentDirectory(), "assets", "styles.css") },
                //HeaderSettings = { FontName = "Arial", FontSize = 9, Right = "Page [page] of [toPage]", Line = true },
                //FooterSettings = { FontName = "Arial", FontSize = 9, Line = true, Center = "Report Footer" },
            };

            var pdf = new HtmlToPdfDocument()
            {
                GlobalSettings = globalSettings,
                Objects = { objectSettings }
            };

            var file = _converter.Convert(pdf);

            //return Ok("Sucessfuly created your First PDF Document");
            //return File(file, "application/pdf", "EmployeeReport.pdf");
            return File(file, "application/pdf");
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


        public ActionResult Leomar()
        {
            var dados = DataStorage.GetEmployees();

            var template = new RelatorioTemplate();
            template.Body.FontSize = 48;
            var elements = template.GeneratePDF(dados);

            var globalSettings = new GlobalSettings
            {
                ColorMode = ColorMode.Color,
                Orientation = Orientation.Portrait,
                PaperSize = PaperKind.A4,
                Margins = new MarginSettings { Top = 1, Bottom = 0, Left = 0, Right = 0 },
                DocumentTitle = "FIRST PDF"
            };

            var objectSettings = new ObjectSettings
            {
                //PagesCount = true,
                HtmlContent = elements,
                //Page = "https://code-maze.com/",
                WebSettings = { DefaultEncoding = "utf-8" }
                //HeaderSettings = { FontName = "Arial", FontSize = 9, Right = "Page [page] of [toPage]", Line = true },
                //FooterSettings = { FontName = "Arial", FontSize = 9, Line = true, Center = "Report Footer" },
            };
            
            var pdf = new HtmlToPdfDocument()
            {
                GlobalSettings = globalSettings,
                Objects = { objectSettings }
            };

            var file = _converter.Convert(pdf);

            //return Ok("Sucessfuly created your First PDF Document");
            //return File(file, "application/pdf", "EmployeeReport.pdf");
            return File(file, "application/pdf");
        }

        public ActionResult Default()
        {
            var dados = DataStorage.GetEmployees();

            var template = new RelatorioTemplate();
            template.Body.FontSize = 48;
            var elements = template.GeneratePDF(dados);

            var globalSettings = new GlobalSettings
            {
                ColorMode = ColorMode.Color,
                Orientation = Orientation.Portrait,
                PaperSize = PaperKind.A4,
                Margins = new MarginSettings { Top = 1, Bottom = 0, Left = 0, Right = 0 },
                DocumentTitle = "FIRST PDF"
            };

            var objectSettings = new ObjectSettings
            {
                //PagesCount = true,
                HtmlContent = elements,
                //Page = "https://code-maze.com/",
                WebSettings = { DefaultEncoding = "utf-8" }
                //HeaderSettings = { FontName = "Arial", FontSize = 9, Right = "Page [page] of [toPage]", Line = true },
                //FooterSettings = { FontName = "Arial", FontSize = 9, Line = true, Center = "Report Footer" },
            };

            var pdf = new HtmlToPdfDocument()
            {
                GlobalSettings = globalSettings,
                Objects = { objectSettings }
            };

            var file = _converter.Convert(pdf);

            //return Ok("Sucessfuly created your First PDF Document");
            //return File(file, "application/pdf", "EmployeeReport.pdf");
            return File(file, "application/pdf");
        }


    }
}