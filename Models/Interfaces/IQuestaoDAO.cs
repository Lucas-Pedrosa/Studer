using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Studer.Models.Interfaces
{
    interface IQuestaoDAO
    {
        public Questao getQuestao(int id);
        public Boolean adicionaQuestao(string enunciado, string a, string b, string c, string d, string e, string alternativaCorreta, int idProfessor, int idDisciplina);
    }
}
