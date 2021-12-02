using Studer.Models.DAO;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace Studer.Models
{
    public class SimuladoBuilder : EstudanteBuilder
    {
        public string formato;
        public string vestibularSelect;
        public string DisciplinaSelect;

        public SimuladoBuilder(ClaimsPrincipal User, string formato, string vestibularSelect, string DisciplinaSelect, Manager manager)
        {
            this.estudante = new Estudante();
            this.simulado = new Simulado();
            this.manager = manager;

            int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value);

            this.formato = formato;
            this.vestibularSelect = vestibularSelect;
            this.DisciplinaSelect = DisciplinaSelect;

            this.estudante.SetId(int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value));
        }

        public override void criaSimulado()
        {
            this.simulado = new Simulado();
            this.simulado.SetId(this.manager.GetSimuladoDAO().criaSimulado(this.estudante.GetId()));
        }

        public override void criaCaracteristicas()
        {

            if (this.formato.Equals("vestibular"))
            {
                this.simulado.SetCaracteristicas(this.manager.GetCaracteristicasDAO().getCaracteristicas(vestibularSelect));
            }
            else if (this.formato.Equals("disciplina"))
            {
                List<Disciplina> disciplinas = this.manager.GetDisciplinaDAO().getDisciplinas();

                Caracteristica caracteristica = new Caracteristica();

                foreach (Disciplina disciplina in disciplinas)
                {
                    if (disciplina.GetNome() == DisciplinaSelect)
                    {
                        caracteristica.SetIdDisciplina(disciplina.GetId());
                        caracteristica.SetQuantidade(5);

                        this.simulado.GetCaracteristicas().Add(caracteristica);
                    }
                }
            }
        }

        public override void criaQuestoes()
        {
            simulado.SetListaQuestoes(this.manager.GetQuestaoDAO().getQuestoes(this.simulado.GetCaracteristicas()));
        }
    }
}
