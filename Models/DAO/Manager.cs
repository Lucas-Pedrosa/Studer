using Studer.Database;
using Studer.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Studer.Models.DAO
{
    public class Manager {

        private QuestaoDAO questaoDAO;
        private SimuladoDAO simuladoDAO;
        private EstudanteDAO estudanteDAO;
        private VestibularDAO vestibularDAO;
        private DisciplinaDAO disciplinasDAO;
        private ProfessorDAO professorDAO;
        private CaracteristicasDAO caracteristicasDAO;
        private SimuladoRealizadoDAO simuladoRealizadoDAO;

        public Manager(MySqlDatabase mySqlDatabase)
        {
            this.estudanteDAO = new EstudanteDAO(mySqlDatabase);
            this.simuladoDAO = new SimuladoDAO(mySqlDatabase);
            this.questaoDAO = new QuestaoDAO(mySqlDatabase);
            this.vestibularDAO = new VestibularDAO(mySqlDatabase);
            this.disciplinasDAO = new DisciplinaDAO(mySqlDatabase);
            this.professorDAO = new ProfessorDAO(mySqlDatabase);
            this.caracteristicasDAO = new CaracteristicasDAO(mySqlDatabase);
            this.simuladoRealizadoDAO = new SimuladoRealizadoDAO(mySqlDatabase);
        }

        public IEstudanteDAO GetEstudanteDAO()
        {
            return this.estudanteDAO;
        }

        public ISimuladoDAO GetSimuladoDAO()
        {
            return this.simuladoDAO;
        }

        public IQuestaoDAO GetQuestaoDAO()
        {
            return this.questaoDAO;
        }

        public IVestibularDAO GetVestibularDAO()
        {
            return this.vestibularDAO;
        }

        public IDisciplinaDAO GetDisciplinaDAO()
        {
            return this.disciplinasDAO;
        }

        public IProfessorDAO GetProfessorDAO()
        {
            return this.professorDAO;
        }

        public ICaracteristicasDAO GetCaracteristicasDAO()
        {
            return this.caracteristicasDAO;
        }

        public ISimuladoRealizadoDAO GetSimuladoRealizadoDAO()
        {
            return this.simuladoRealizadoDAO;
        }
    }
}
