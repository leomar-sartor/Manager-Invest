using System;
using System.Collections.Generic;
using System.Text;

namespace Carteira.Entity
{
    public class AtivoUsuario
    {
        public long Id { get; set; }

        public long AtivoId { get; set; }

        public string UsuairoId { get; set; }

        public long Quantidade { get; set; }

        public Ativo Ativo { get; set; }
    }
}
