using Carteira.Entity;
using Carteira.Entity.Enuns;
using Carteira.Testes.Utilitarios.ObjectDefault;
using System;
using System.Linq;

namespace Carteira.ConsoleTestes
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome!");
            Console.WriteLine("Starting Test...");



            //Custo médio
            var CustoMedio = Math.Round(11.255M, 2, MidpointRounding.ToEven);

            Console.WriteLine($"Custo Medio 1 : {CustoMedio}");


            CustoMedio = Math.Round(11.55555M, 2, MidpointRounding.ToEven);

            Console.WriteLine($"Custo Medio 2 : {CustoMedio}");

            CustoMedio = Math.Round(11.4554321M, 2, MidpointRounding.ToEven);

            Console.WriteLine($"Custo Medio 3 : {CustoMedio}");


            CustoMedio = Math.Round(11.2546789M, 2, MidpointRounding.ToEven);
            Console.WriteLine($"Custo Medio 1 : {CustoMedio}");


            CustoMedio = Math.Round(11.55444M, 2, MidpointRounding.ToEven);

            Console.WriteLine($"Custo Medio 2 : {CustoMedio}");

            CustoMedio = Math.Round(11.454321M, 2, MidpointRounding.ToEven);

            Console.WriteLine($"Custo Medio 3 : {CustoMedio}");


            Console.WriteLine($"SOMA: ");

            Console.WriteLine("Finished Test!");
            Console.ReadKey();
        }
    }
}
