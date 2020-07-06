using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Carteira.Domain.Enums
{
    //https://www.codingame.com/playgrounds/2487/c---how-to-display-friendly-names-for-enumerations
    public enum TipoInvestimento : short
    {
        [Display(Name = "Renda Fixa")]
        RendaFixa = 1,
        [Display(Name = "Renda Variável")]
        RendaVariavel = 2
    }
}
