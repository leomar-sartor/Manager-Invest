using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Carteira.Entity
{
    public class Configuracao
    {
        public int Id { get; set; }

        [Display(Name = "Valor")]
        public string Nome { get; set; }

        [Display(Name = "User")]
        public string Usuario { get; set; }

        [Display(Name = "Senha")]
        public string Senha { get; set; }
    }
}
