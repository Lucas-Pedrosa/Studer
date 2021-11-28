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
    public class QuestaoController : Controller
    {
        private Manager manager;

        public QuestaoController(MySqlDatabase mySqlDatabase)
        {
            this.manager = new Manager(mySqlDatabase);
        }

        // GET: Questao
        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                dynamic myModel = new ExpandoObject();

                List<Disciplina> disciplinas = this.manager.GetDisciplinaDAO().getDisciplinas();
                myModel.disciplinas = disciplinas;             

                Usuario usuario = new Usuario();
                usuario.nome = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name).Value;
                usuario.email = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email).Value;
                usuario.id = int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value);
                usuario.tipo = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.UserData).Value;
                myModel.usuario = usuario;

                return View(myModel);
            }
            return RedirectToAction("Index", "Login");
        }

        // POST: Questao/Cadastrar
        [HttpPost]
        public IActionResult Cadastrar(
            string enunciado, 
            string alternativa_a, 
            string alternativa_b, 
            string alternativa_c, 
            string alternativa_d, 
            string alternativa_e,
            string alternativa,
            int disciplinaSelect
        )
        {
            if (User.Identity.IsAuthenticated)
            {
                if (alternativa is null)
                {
                    return Json(new { msg = "Escolha a alternativa correta!", icon = "error" });
                }

                if (manager.GetQuestaoDAO().adicionaQuestao(
                    enunciado,
                    alternativa_a,
                    alternativa_b,
                    alternativa_c,
                    alternativa_d,
                    alternativa_e,
                    alternativa,
                    User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value,
                    disciplinaSelect
                ))
                {
                    return Json(new { msg = "Questão cadastrada com sucesso!", icon = "success", url = "/Home" });
                }
                else
                {
                    return Json(new { msg = "Erro desconhecido", icon = "error" });
                }                
            }
            return RedirectToAction("Index", "Login");
        }
    }
}
