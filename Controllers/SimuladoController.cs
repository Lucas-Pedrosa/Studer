﻿using Microsoft.AspNetCore.Mvc;
using Studer.Database;
using Studer.Models;
using Studer.Models.DAO;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

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
            if (User.Identity.IsAuthenticated)
            {
                List<Vestibular> vestibulares = this.manager.GetVestibularDAO().getVestibulares();
                List<Disciplina> disciplinas = this.manager.GetDisciplinaDAO().getDisciplinas();

                dynamic mymodel = new ExpandoObject();
                mymodel.vestibulares = vestibulares;
                mymodel.disciplinas = disciplinas;

                Usuario usuario = new Usuario();
                usuario.nome = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name).Value;
                usuario.email = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email).Value;
                usuario.id = int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value);
                usuario.tipo = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.UserData).Value;
                mymodel.usuario = usuario;

                return View(mymodel);
            }
            return RedirectToAction("Index", "Login");
        }

        
        [HttpPost]
        public IActionResult criarSimulado(string formato, string vestibularSelect, string DisciplinaSelect)
        {

            Console.WriteLine(formato+"" +
                            "\n vestibular: "+vestibularSelect+
                            "\n disciplina: "+ DisciplinaSelect);

            List<Caracteristica> caracteristicas = new List<Caracteristica>();

            if (formato.Equals("vestibular"))
            {
                caracteristicas = this.manager.GetCaracteristicasDAO().getCaracteristicas(vestibularSelect);
            }
            else if (formato.Equals("disciplina"))
            {
                caracteristicas = this.manager.GetCaracteristicasDAO().getCaracteristicas(DisciplinaSelect);
            }

            List<Questao> questoes = new List<Questao>();

            questoes = this.manager.GetQuestaoDAO().getQuestoes(caracteristicas);

            SessionHelper.SetObjectAsJson(HttpContext.Session, "questoes", questoes);

            HttpContext.Session.SetInt32("id", 0);

            return RedirectToAction("QuestaoSimulado", "Simulado");

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

        [HttpPost]
        public void selecionaQuestao(string id)
        {
            Console.WriteLine(""+id);
        }

        public IActionResult QuestaoSimulado()
        {
            List<Questao> questoes = SessionHelper.GetObjectFromJson<List<Questao>>(HttpContext.Session, "questoes");

            string id = HttpContext.Session.GetString("id");

            dynamic myModel = new ExpandoObject();

            myModel.questoes = questoes;
            myModel.id = id;

            return View(myModel);
        }
    }
}
