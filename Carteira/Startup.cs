using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Carteira.Domain.Contexto;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation;
using DinkToPdf.Contracts;
using DinkToPdf;
using System.IO;
using Carteira.Utility;

namespace Carteira
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment _hostingEnvironment;

        public Startup(Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            services.AddMvc();

            services.AddControllersWithViews();
            services.AddRazorPages().AddRazorRuntimeCompilation();

            //Connect vue app - middleware
            services.AddSpaStaticFiles(options => options.RootPath = "Srcipts/index.js");

            //Dink to Pdf
            //services.AddSingleton(typeof(IConverter), new SynchronizedConverter(new PdfTools()));

            // Configurações do DinkToPDF
            // Verifica qual a arquiterura para utilizar os arquivos necessários
            var architectureFolder = (IntPtr.Size == 8) ? "64 bit" : "32 bit";
            // Encontra o caminho onde estão os arquivos
            //var wkHtmlToPdfPath = Path.Combine(_hostingEnvironment.ContentRootPath, $"v0.12.4\\{architectureFolder}\\libwkhtmltox");

            var wkHtmlToPdfPath = Path.Combine(Directory.GetCurrentDirectory(), "libwkhtmltox");
            
            // Carrega os arquivos necessários, passadas as configurações
            CustomAssemblyLoadContext context = new CustomAssemblyLoadContext();
            context.LoadUnmanagedLibrary(wkHtmlToPdfPath);

            // Configuração do DinkToPdf
            services.AddSingleton(typeof(IConverter), new SynchronizedConverter(new PdfTools()));

            // Configuração do conversor de razor views para string
            services.AddScoped<IViewRenderService, ViewRenderService>();
            //End COnfiguration

            services.AddDbContext<Context>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

        }
    }
}

