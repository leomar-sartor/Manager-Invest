using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using static System.Net.Mime.MediaTypeNames;
using System.Threading;
using System.Linq;

namespace Carteira.ConsoleComands
{
    class Program
    {
        static async System.Threading.Tasks.Task Main(string[] args)
        {
            Console.WriteLine("Welcome!");

            Console.WriteLine("Starting Test...");

            using (var ps = PowerShell.Create())
            {
                ps.AddCommand("C:\\Projetos\\Carteira\\Manager-Invest\\Carteira\\Opencover\\OpenCover.Console.exe")
                  .AddParameter("-target:", "C:\\Program Files\\dotnet\\dotnet.exe")
                  .AddParameter("-targetargs:", "test C:\\Projetos\\Carteira\\Manager-Invest\\Carteira.Testes\\Carteira.Testes.csproj")
                  .AddParameter("-output:", "C:\\Projetos\\Carteira\\Manager-Invest\\Carteira\\OpenCoverXML\\Teste.xml")
                  .AddParameter("-oldStyle", "")
                  .AddParameter("-filter:", "+[Carteira.Testes*]*")
                  .AddParameter("-register:", "user")
                  .Invoke();

                var pipelineObjects = await ps.InvokeAsync().ConfigureAwait(false);

                foreach (var item in pipelineObjects)
                {
                    Console.WriteLine(item.BaseObject.ToString());
                }
            }

            
            Console.WriteLine("Finished Test!");

            Console.ReadKey();
        }



    }
}
