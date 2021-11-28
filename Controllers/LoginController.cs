using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Studer.Database;
using Studer.Exceptions;
using Studer.Models;
using Studer.Models.DAO;
using System;
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
                await SetClaims(estudante.GetId(), estudante.GetNome(), estudante.GetEmail(), manterlogado, "aluno");
                return Json(new { msg = "Login efetuado com sucesso", icon = "success", url = "/Home" });
            }
        }

        // GET: Login/Professor
        public IActionResult Professor()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        // POST: Login/LogarProfessor
        [HttpPost]
        public async Task<IActionResult> LogarProfessor(string email, string senha, bool manterlogado)
        {
            Professor professor = manager.GetProfessorDAO().login(email, senha);

            if (professor is null)
            {
                return Json(new { msg = "Credenciais incorretas, tente novamente", icon = "error" });
            }
            else
            {
                await SetClaims(professor.GetId(), professor.GetNome(), professor.GetEmail(), manterlogado, "professor");
                return Json(new { msg = "Login efetuado com sucesso", icon = "success", url = "/Home" });
            }
        }

        // GET: Login/Cadastro
        public IActionResult Cadastro()
        {
            return View();
        }

        // POST: Login/Cadastrar
        [HttpPost]
        public async Task<IActionResult> Cadastrar(string nome, string email, string senha, string confirmarSenha)
        {
            if (senha.Equals(confirmarSenha))
            {
                try
                {
                    if (manager.GetEstudanteDAO().cadastro(nome, email, senha, "21/11/2021"))
                    {
                        Estudante estudante = manager.GetEstudanteDAO().login(email, senha);
                        await SetClaims(estudante.GetId(), estudante.GetNome(), estudante.GetEmail(), false, "aluno");
                        return Json(new { msg = "Cadastro efetuado com sucesso", icon = "success", url = "/Home" });
                    }
                }
                catch (UsuarioRepetidoException)
                {
                    return Json(new { msg = "Usuário já cadastrado", icon = "error" });
                }
            }
            else
            {
                return Json(new { msg = "Senhas não batem", icon = "error" });
            }
            
            return RedirectToAction("Index", "Cadastro");
        }

        private async Task SetClaims(int id, string nome, string email, bool manterlogado, string tipo)
        {
            List<Claim> direitosAcesso = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, id.ToString()),
                new Claim(ClaimTypes.Name, nome),
                new Claim(ClaimTypes.Email, email),
                new Claim(ClaimTypes.UserData, tipo)
            };

            var identity = new ClaimsIdentity(direitosAcesso, "Identity.Login");
            var userPrincipal = new ClaimsPrincipal(new[] { identity });

            await HttpContext.SignInAsync(userPrincipal, new AuthenticationProperties
            {
                IsPersistent = manterlogado,
                ExpiresUtc = System.DateTime.Now.AddHours(1)
            });
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
