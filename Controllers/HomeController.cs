using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MySql.Data.MySqlClient;
using Studer.Database;
using Studer.Models;
using Studer.Models.DAO;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Studer.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private EstudanteDAO estudanteDAO;
        private QuestaoDAO questaoDAO;

        /*public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }*/

        public HomeController(MySqlDatabase mySqlDatabase)
        {
            this.estudanteDAO = new EstudanteDAO(mySqlDatabase);
            this.questaoDAO = new QuestaoDAO(mySqlDatabase);
        }

        public IActionResult Index()
        {
            Estudante estudante = new Estudante();
            Questao questao = new Questao();

            estudante = this.estudanteDAO.getEstudante(0);
            questao = this.questaoDAO.getQuestao(0);

            Console.WriteLine("nome: "+estudante.getNome());
            Console.WriteLine("questao: "+questao.GetEnunciado());

            return View();
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
