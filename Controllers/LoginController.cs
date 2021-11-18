using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Studer.Database;
using Studer.Models;
using Studer.Models.DAO;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Studer.Controllers
{
    public class LoginController : Controller
    {
        private Manager manager;

        public LoginController(MySqlDatabase mySqlDatabase)
        {
            manager = new Manager(mySqlDatabase);
        }

        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                return Json(new { Msg = "Usuário já logado!" });
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Logar(string email, string senha, bool manterlogado)
        {
            Estudante estudante = manager.GetEstudanteDAO().login(email, senha);

            if (estudante is null)
            {
                return Json(new { Msg = "Invalido" });
            }
            else
            {
                List<Claim> direitosAcesso = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, estudante.GetId().ToString()),
                    new Claim(ClaimTypes.Name, estudante.GetNome()),
                    new Claim(ClaimTypes.Email, estudante.GetEmail())
                };

                var identity = new ClaimsIdentity(direitosAcesso, "Identity.Login");
                var userPrincipal = new ClaimsPrincipal(new[] { identity });

                await HttpContext.SignInAsync(userPrincipal, new AuthenticationProperties
                {
                    IsPersistent = manterlogado,
                    ExpiresUtc = System.DateTime.Now.AddHours(1)
                });

                return Json(new { Msg = "Válido", usuario = $"{estudante.GetNome()}", id = $"{estudante.GetId()}" });
            }
        }

        public async Task<IActionResult> Logout()
        {
            if (User.Identity.IsAuthenticated)
            {
                await HttpContext.SignOutAsync();
            }
            return RedirectToAction("Index", "Login");
        }
    }
}
