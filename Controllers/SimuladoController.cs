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

            //int idSimulado = 0;

            EstudanteBuilder estudante;

            if (User.Identity.IsAuthenticated)
            {
                //int idEstudante = int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value);

                //idSimulado = this.manager.GetSimuladoDAO().criaSimulado(idEstudante);

                estudante = new SimuladoBuilder(User, formato, vestibularSelect, DisciplinaSelect, manager);
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }

            Avaliacao avaliacao = new Avaliacao(estudante);

            /*List<Caracteristica> caracteristicas = new List<Caracteristica>();

            if (formato.Equals("vestibular"))
            {
                caracteristicas = this.manager.GetCaracteristicasDAO().getCaracteristicas(vestibularSelect);
            }
            else if (formato.Equals("disciplina"))
            {
                List<Disciplina> disciplinas = this.manager.GetDisciplinaDAO().getDisciplinas();

                Caracteristica caracteristica = new Caracteristica();

                foreach (Disciplina disciplina in disciplinas)
                {
                    if (disciplina.GetNome() == DisciplinaSelect)
                    {
                        caracteristica.SetIdDisciplina(disciplina.GetId());
                        caracteristica.SetQuantidade(5);

                        caracteristicas.Add(caracteristica);
                    }
                }
            }*/

            //List<Questao> questoes = new List<Questao>();

            /*Simulado simulado = new Simulado();

            simulado.SetListaQuestoes(this.manager.GetQuestaoDAO().getQuestoes(caracteristicas));*/

            List<SimuladoRealizado> simuladoRealizado = new List<SimuladoRealizado>();

            SimuladoRealizado questaoSimulado;

            List<int> idQuestoes = new List<int>();

            /*foreach (Questao questao in simulado.GetListaQuestoes())
            {
                idQuestoes.Add(questao.GetId());

                questaoSimulado = new SimuladoRealizado();
                questaoSimulado.setIdSimulado(idSimulado);
                questaoSimulado.setIdQuestao(questao.GetId());
                simuladoRealizado.Add(questaoSimulado);
            }

            SessionHelper.SetObjectAsJson(HttpContext.Session, "simulado", simuladoRealizado);

            SessionHelper.SetObjectAsJson(HttpContext.Session, "questoes", simulado.GetListaQuestoes());

            SessionHelper.SetObjectAsJson(HttpContext.Session, "idQuestoes", idQuestoes);

            HttpContext.Session.SetInt32("id", simulado.GetListaQuestoes()[0].GetId());

            return RedirectToAction("QuestaoSimulado", "Simulado");*/

            foreach (Questao questao in estudante.simulado.GetListaQuestoes())
            {
                idQuestoes.Add(questao.GetId());

                questaoSimulado = new SimuladoRealizado();
                questaoSimulado.setIdSimulado(estudante.simulado.GetId());
                questaoSimulado.setIdQuestao(questao.GetId());
                simuladoRealizado.Add(questaoSimulado);
            }

            SessionHelper.SetObjectAsJson(HttpContext.Session, "simulado", simuladoRealizado);

            SessionHelper.SetObjectAsJson(HttpContext.Session, "questoes", estudante.simulado.GetListaQuestoes());

            SessionHelper.SetObjectAsJson(HttpContext.Session, "idQuestoes", idQuestoes);

            HttpContext.Session.SetInt32("id", estudante.simulado.GetListaQuestoes()[0].GetId());

            return RedirectToAction("QuestaoSimulado", "Simulado");
        }

        [HttpPost]
        public IActionResult selecionaQuestao(int id, string formato)
        {
            try
            {
                if (!formato.Equals(null))
                {

                    Simulado simulado = new Simulado();

                    simulado.SetListaQuestoes(SessionHelper.GetObjectFromJson<List<Questao>>(HttpContext.Session, "questoes"));

                    //List<Questao> questoes = SessionHelper.GetObjectFromJson<List<Questao>>(HttpContext.Session, "questoes");

                    List<SimuladoRealizado> simuladoRealizado = SessionHelper.GetObjectFromJson<List<SimuladoRealizado>>(HttpContext.Session, "simulado");

                    int counter = 0;

                    foreach (Questao questao in simulado.GetListaQuestoes())
                    {
                        if (HttpContext.Session.GetInt32("id").Value == questao.GetId())
                        {
                            simuladoRealizado[counter].setAlternativa(formato);
                        }

                        counter++;
                    }

                    SessionHelper.SetObjectAsJson(HttpContext.Session, "simulado", simuladoRealizado);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            HttpContext.Session.SetInt32("id", Convert.ToInt32(id));

            return RedirectToAction("QuestaoSimulado", "Simulado");
        }

        public IActionResult QuestaoSimulado()
        {
            Simulado simulado = new Simulado();

            simulado.SetListaQuestoes(SessionHelper.GetObjectFromJson<List<Questao>>(HttpContext.Session, "questoes"));

            //List<Questao> questoes = SessionHelper.GetObjectFromJson<List<Questao>>(HttpContext.Session, "questoes");

            int id = HttpContext.Session.GetInt32("id").Value;

            List<int> idQuestoes = SessionHelper.GetObjectFromJson<List<int>>(HttpContext.Session, "idQuestoes");

            List<SimuladoRealizado> simuladoRealizado = SessionHelper.GetObjectFromJson<List<SimuladoRealizado>>(HttpContext.Session, "simulado");

            dynamic myModel = new ExpandoObject();

            myModel.questoes = simulado.GetListaQuestoes();
            myModel.id = id;
            myModel.idQuestoes = idQuestoes;
            myModel.simulado = simuladoRealizado;

            return View(myModel);
        }

        [HttpPost]
        public IActionResult simuladoFinalizado(int id, string formato)
        {

            try
            {
                if (!formato.Equals(null))
                {
                    Simulado simulado = new Simulado();

                    simulado.SetListaQuestoes(SessionHelper.GetObjectFromJson<List<Questao>>(HttpContext.Session, "questoes"));

                    //List<Questao> questoes = SessionHelper.GetObjectFromJson<List<Questao>>(HttpContext.Session, "questoes");

                    List<SimuladoRealizado> simuladoRealizado = SessionHelper.GetObjectFromJson<List<SimuladoRealizado>>(HttpContext.Session, "simulado");

                    int counter = 0;

                    foreach (Questao questao in simulado.GetListaQuestoes())
                    {
                        if (HttpContext.Session.GetInt32("id").Value == questao.GetId())
                        {
                            simuladoRealizado[counter].setAlternativa(formato);
                        }

                        counter++;
                    }

                    SessionHelper.SetObjectAsJson(HttpContext.Session, "simulado", simuladoRealizado);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            HttpContext.Session.SetInt32("id", Convert.ToInt32(id));

            List<SimuladoRealizado> simuladoFinalizado = SessionHelper.GetObjectFromJson<List<SimuladoRealizado>>(HttpContext.Session, "simulado");
            
            this.manager.GetSimuladoRealizadoDAO().insereSimuladoRealizado(simuladoFinalizado);

            return RedirectToAction("Index", "Login");
        }
    }
}
