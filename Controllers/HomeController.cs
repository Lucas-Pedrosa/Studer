using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MySql.Data.MySqlClient;
using Studer.Database;
using Studer.Models;
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
        private MySqlDatabase MySqlDatabase { get; set; }

        /*public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }*/

        public HomeController(MySqlDatabase mySqlDatabase)
        {
            this.MySqlDatabase = mySqlDatabase;
        }

        public IActionResult Index()
        {

            var ret = new List<Estudante>();

            var cmd = this.MySqlDatabase.Connection.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT id, nome FROM estudante";

            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    var estudante = new Estudante();

                    estudante.SetId(Convert.ToInt32(reader["id"]));
                    estudante.Setnome(reader["nome"].ToString());

                    ret.Add(estudante);
                }
            }

            if(ret.Count > 0)
            {
                int count = 0;
                while(count < ret.Count)
                {
                    Console.WriteLine("Nome: "+ ret[count].GetNome());
                    count++;
                }
            }

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
