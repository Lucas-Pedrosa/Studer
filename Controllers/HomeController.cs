using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MySql.Data.MySqlClient;
using Studer.Database;
using Studer.Models;
using Studer.Models.DAO;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Dynamic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Studer.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private Manager manager;

        /*public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }*/

        public HomeController(MySqlDatabase mySqlDatabase)
        {
            this.manager = new Manager(mySqlDatabase);
        }

        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                dynamic myModel = new ExpandoObject();

                Usuario usuario = new Usuario();
                usuario.nome = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name).Value;
                usuario.email = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email).Value;
                usuario.id = int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value);
                usuario.tipo = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.UserData).Value;
                myModel.usuario = usuario;

                return View(myModel);
            }

            return RedirectToAction("Index", "Login");
            

            /*
            Estudante estudante1 = new Estudante();

            estudante1.SetEmail("matheus@gmail.com");
            estudante1.SetNome("Matheus Souza");
            estudante1.SetSenha("#%%$1552");
            estudante1.SetNascimento("16/01/1986");

            manager.GetEstudanteDAO().cadastro(estudante1.GetNome(), estudante1.GetEmail(), estudante1.GetSenha(), estudante1.GetNascimento());

            // Login
            Estudante estudante2 = manager.GetEstudanteDAO().login("matheus@gmail.com", "#%%$1552");
            Console.WriteLine("id: " + estudante2.GetId());

            // Buscar questão de um simulado
            Simulado simulado = new Simulado();
            simulado = this.manager.GetSimuladoDAO().getSimulado(1);
            Console.WriteLine("questao: " + simulado.GetListaQuestoes()[0].GetEnunciado());
            */
        }

        public IActionResult CriarSimulado()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Simulado");
            }
            return RedirectToAction("Index", "Login");
        }

        public IActionResult VerDesempenho()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Desempenho");
            }
            return RedirectToAction("Index", "Login");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
