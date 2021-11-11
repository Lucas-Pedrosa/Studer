using Studer.Database;
using Studer.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Studer.Models.DAO
{
    class Manager {
        private QuestaoDAO questaoDAO;
        private SimuladoDAO simuladoDAO;
        private EstudanteDAO estudanteDAO;

        public Manager(MySqlDatabase mySqlDatabase)
        {
            this.estudanteDAO = new EstudanteDAO(mySqlDatabase);
            this.simuladoDAO = new SimuladoDAO(mySqlDatabase);
            this.questaoDAO = new QuestaoDAO(mySqlDatabase);
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
    }
}
