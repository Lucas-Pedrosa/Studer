using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Studer.Models
{
    public class Simulado
    {
        private int id;
        private int idDesempenho;
        private List<Questao> listaQuestoes;
        private int idVestibular;

        public Simulado()
        {}

        public int GetId()
        {
            return id;
        }

        public void SetId(int id)
        {
            this.id = id;
        }

        public int GetIdDesempenho()
        {
            return idDesempenho;
        }

        public void SetIdDesempenho(int idDesempenho)
        {
            this.idDesempenho = idDesempenho;
        }

        public List<Questao> GetListaQuestoes()
        {
            return listaQuestoes;
        }

        public void SetListaQuestoes(List<Questao> listaQuestoes)
        {
            this.listaQuestoes = listaQuestoes;
        }

        public int GetIdVestibular()
        {
            return id;
        }

        public void SetIdVestibular(int idVestibular)
        {
            this.idVestibular = idVestibular;
        }
    }
}
