using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Carteira.Entity.Contexto;
using Carteira.Models.UserApplication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Carteira.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;

            
        }

        [HttpGet]
        public async Task<IActionResult> RegisterAsync()
        {

            //var res = await _userManager.GetUserAsync(User);

            //if(res is not null)
              //  var tt = res.Nome;

            return View();

        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Copia os dados do RegisterViewModel para o IdentityUser
                var user = new ApplicationUser
                {
                    Nome = model.NomeCompleto,
                    UserName = model.Email,
                    Email = model.Email,
                    PhoneNumber = model.Telefone,
                    EmailConfirmed = true
                };
                // Armazena os dados do usuário na tabela AspNetUsers
                var result = await _userManager.CreateAsync(user, model.Password);
                // Se o usuário foi criado com sucesso, faz o login do usuário
                // usando o serviço SignInManager e redireciona para o Método Action Index
                if (result.Succeeded)
                {
                    /*
                        Um cookie de sessão é criado e armazenado na instância de sessão do navegador. Um cookie de sessão não contém uma data de validade e é excluído permanentemente quando a janela do navegador é fechada.
                        Um cookie persistente, por outro lado, não é excluído quando a janela do navegador é fechada. Geralmente, tem uma data de validade e é excluída na data de validade.
                        Se a propriedade IsPersistent de AuthenticationProperties estiver configurada como false, o tempo de expiração do cookie será definido como Session.
                    */

                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("index", "home");
                }
                // Se houver erros então inclui no ModelState
                // que será exibido pela tag helper summary na validação
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("index", "home");
        }

        [AcceptVerbs("Get", "Post")]
        [AllowAnonymous]
        public async Task<IActionResult> IsEmailInUse(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                return Json(true);
            }
            else
            {
                return Json($"O Email {email} já está sendo usado.");
            }
        }

        [HttpGet]
        public IActionResult Login(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return View(); //RedirectToAction("index", "home");
            }
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(
                    model.Email, model.Password, model.RememberMe, false);

                if (result.Succeeded)
                {
                    return RedirectToAction("index", "home");
                }

                ModelState.AddModelError(string.Empty, "Login Inválido");
            }
            return View(model);
        }
    }
}