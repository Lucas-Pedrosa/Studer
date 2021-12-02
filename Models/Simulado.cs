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
        private List<Caracteristica> caracteristicas;
        private int idVestibular;

        public Simulado()
        {
            this.listaQuestoes = new List<Questao>();
            this.caracteristicas = new List<Caracteristica>();
        }

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

        public List<Caracteristica> GetCaracteristicas()
        {
            return caracteristicas;
        }

        public void SetCaracteristicas(List<Caracteristica> caracteristicas)
        {
            this.caracteristicas = caracteristicas;
        }

        public int GetIdVestibular()
        {
            return this.idVestibular;
        }

        public void SetIdVestibular(int idVestibular)
        {
            this.idVestibular = idVestibular;
        }
    }
}
