using Carteira.Entity.Enuns;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Carteira.Entity.Contexto
{
    public class ApplicationUser : IdentityUser
    {
        public string Nome { get; set; }
        public DateTime? DataNascimento { get; set; }
        public TipoGenero? Genero { get; set; }
    }
}
