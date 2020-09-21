using System.ComponentModel.DataAnnotations;

namespace Carteira.Entity.Enuns
{
    public enum TipoPapel : short
    {
        [Display(Name = "Fundo Imobiliário")]
        FundoImobiliario = 1,
        [Display(Name = "Ação")]
        Acao = 2,
        [Display(Name = "Tesouro Direto")]
        TesouroDireto = 3
    }
}
