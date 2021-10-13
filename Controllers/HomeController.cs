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
        private SimuladoDAO simuladoDAO;

        /*public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }*/

        public HomeController(MySqlDatabase mySqlDatabase)
        {
            this.estudanteDAO = new EstudanteDAO(mySqlDatabase);
            this.questaoDAO = new QuestaoDAO(mySqlDatabase);
            this.simuladoDAO = new SimuladoDAO(mySqlDatabase);
        }

        public IActionResult Index()
        {
            Estudante estudante = new Estudante();
            Questao questao = new Questao();
            Simulado simulado = new Simulado();

            estudante = this.estudanteDAO.getEstudante(0);
            questao = this.questaoDAO.getQuestao(0);
            simulado = this.simuladoDAO.GetSimulado(0);

            Console.WriteLine("nome: "+estudante.GetNome());
            Console.WriteLine("questao: "+questao.GetEnunciado());
            Console.WriteLine("questao: " + simulado.GetListaQuestoes()[0].GetEnunciado());

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
