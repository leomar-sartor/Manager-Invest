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
            //REFRENCIAS
            // https://www.devmedia.com.br/desmitificando-delegates-artigo-net-magazine-84/20410 OK
            //https://www.devmedia.com.br/csharp-orientado-a-eventos-revista-net-magazine-100-parte-2/26319
            //https://medium.com/@alexandre.malavasi/delegates-em-c-o-que-s%C3%A3o-o-que-comem-onde-vivem-e-pra-que-serv-12b5336f3d9a/
            //https://imasters.com.br/back-end/c-usando-delegates-na-pratica-ordenacao-de-objetos
            //https://gabrielschade.github.io/2017/12/04/delegates-func-action.html
            //http://www.linhadecodigo.com.br/artigo/2754/conheca-os-delegates-action-predicate-e-function-em-csharp.aspx

            //VANTAGENS
            //Execução de Operações Assíncronas
            //Reutilização de código
            //Papel de Agente Notificador - Mecanismos de eventos (comunicação entre objetos)
            //Delegates armazenam a referência (endereço de memória) de um metódo dentro de um objeto que pode ser repassado adiante
            //possuem valor de retorno e parametros - metodos e delegates devem ter a mesma assinatura
            //tipos seguros - possuem uma estrutura de metadados bem definida
            //Delegação pode ser entendida como o ato de transferir poder e responsabilidade a outros -  espera somente o resultado

            //Exemplo
            Presentation.Calc calc = new Presentation.Calc(Sum);
            calc += Multiply;

            new Presentation().Show(calc, 10, 10, 10);

            //Declarando um delegate tipado
            //Declarando um delegate anonimo
            //Utilizando Lambda





            //RetornarCabecalhoTabela
            //RetornarItensDaTabela

            //Delegate Action
            //Delegate Function



            //Exemplo

            //Dados


           

            Console.ReadKey();
        }

        static decimal Sum(params decimal[] values)
        {
            decimal result = 0;
            foreach (var value in values)
                result += value;
            return result;
        }

        static decimal Multiply(params decimal[] values)
        {
            decimal result = 1;
            foreach (var value in values)
                result *= value;
            return result;
        }
    }

    class Presentation
    {
        public delegate decimal Calc(params decimal[] values);

        public void Show(Calc operation, params decimal[] values)
        {
            foreach (Calc calc in operation.GetInvocationList())
                Console.WriteLine(string.Format("O resultado do método {0} é {1}.", calc.Method.Name, calc.Invoke(values)));
        }
    }
}
