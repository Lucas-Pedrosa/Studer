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

        // GET: Login
        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        // POST: Login/Logar
        [HttpPost]
        public async Task<IActionResult> Logar(string email, string senha, bool manterlogado)
        {
            Estudante estudante = manager.GetEstudanteDAO().login(email, senha);

            if (estudante is null)
            {
                return Json(new { msg = "Credenciais incorretas, tente novamente", icon = "error" });
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

                return Json(new { msg = $"Login efetuado com sucesso!", url = "Home", icon = "success" });
            }
        }

        // GET: Login/Cadastro
        public IActionResult Cadastro()
        {
            return View();
        }

        // GET: Login/Logout
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
