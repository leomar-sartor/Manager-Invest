using Carteira.Entity;
using System.Collections.Generic;

namespace Carteira.Testes.Utilitarios.ObjectDefault
{
    public class CorretoraDefault
    {
        public List<Corretora> _corretoras = new List<Corretora>();

        public CorretoraDefault() => BuildCorretora();

        private void BuildCorretora()
        {
            var FirstCorretora = new Corretora("XP Investimentos");
            var SecondCorretora = new Corretora("Clear Corretora");

            _corretoras.AddRange(new List<Corretora> { FirstCorretora, SecondCorretora });
        }
    }
}
