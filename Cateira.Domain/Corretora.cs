using System.Collections.Generic;

namespace Carteira.Domain
{
    //Usaar Entidade Financeira e extender Cooretora e Bancos
    public class Corretora
    {
        public Corretora() { }

        public Corretora(string nome)
        {
            Nome = nome;
        }

        public int Id { get; set; }
        public string Nome { get; set; }

        public ICollection<Operacao> Operacoes { get; set; }

        public ICollection<Deposito> Depositos { get; set; }
    }
}
