using Carteira.Utility;
using System;

namespace Carteira.ConsoleFastTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Started Tests!");

            var pdf = new RelatorioTemplate();

            var style = pdf.BuildStyle();
            
            Console.WriteLine(style);

            Console.WriteLine("Finished Test!");

            Console.ReadKey();


        }
    }
}
