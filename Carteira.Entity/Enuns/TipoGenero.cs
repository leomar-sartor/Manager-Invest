using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Carteira.Entity.Enuns
{
    public enum TipoGenero : short
    {
        [Display(Name = "Masculino")]
        RendaFixa = 1,
        [Display(Name = "Feminino")]
        RendaVariavel = 2
    }
}
