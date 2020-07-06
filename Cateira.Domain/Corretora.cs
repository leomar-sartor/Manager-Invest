using System.Collections.Generic;

namespace Carteira.Domain
{
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
    }
}
