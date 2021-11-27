using Microsoft.AspNetCore.Mvc;
using Studer.Database;
using Studer.Models;
using Studer.Models.DAO;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Studer.Controllers
{
    public class SimuladoController : Controller
    {
        private Manager manager;

        public SimuladoController(MySqlDatabase mySqlDatabase)
        {
            this.manager = new Manager(mySqlDatabase);
        }

        public IActionResult Index()
        {

            Console.WriteLine("Simulado");

            List<Vestibular> vestibulares = this.manager.GetVestibularDAO().getVestibulares();
            List<Disciplina> disciplinas = this.manager.GetDisciplinaDAO().getDisciplinas();

            dynamic mymodel = new ExpandoObject();
            mymodel.vestibulares = vestibulares;
            mymodel.disciplinas = disciplinas;

            if (User.Identity.IsAuthenticated)
            {
                Estudante estudante = new Estudante();
                estudante.SetNome(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name).Value);
                estudante.SetEmail(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email).Value);
                estudante.SetId(int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value));

                mymodel.estudante = estudante;

            }

            return View(mymodel);
        }

        [HttpPost]
        public void criarSimulado(string formato, string vestibularSelect, string DisciplinaSelect)
        {

            /*Console.WriteLine("\nvestibularInputRadio: "+vestibularInputRadio+
                              "\ndisciplinaInputRadio: " + disciplinaInputRadio +
                              "\nvestibularSelect: " + vestibularSelect +
                              "\ndisciplinaSelect: " + disciplinaSelect);*/

            Console.WriteLine(formato+"" +
                            "\n vestibular: "+vestibularSelect+
                            "\n disciplina: "+ DisciplinaSelect);

           

            //return RedirectToAction("Index", "Simulado");

            /*Estudante estudante = manager.GetEstudanteDAO().login(email, senha);

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

                return Json(new { msg = $"Login efetuado com sucesso!", url = "Home", icon = "success" });
            }*/
        }
    }
}
