using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Carteira.Models.UserApplication
{
    public class RegisterViewModel
    {
        [Display(Name = "Nome Completo")]
        [Required(ErrorMessage = "O nome é obrigatório")]
        public string NomeCompleto { get; set; }

        [Required(ErrorMessage = "O email é obrigatório")]
        [EmailAddress(ErrorMessage = "Email inválido")]
        [Remote(action: "IsEmailInUse", controller: "Account")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Telefone")]
        public string Telefone { get; set; }
    }
}
