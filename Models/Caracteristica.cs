using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Studer.Models
{
    public class Caracteristica
    {
        private int id;
        private int idVestibular;
        private int idDisciplina;
        private int quantidade;

        public Caracteristica()
        {

        }

        public int GetId()
        {
            return id;
        }

        public void SetId(int id)
        {
            this.id = id;
        }

        public int GetIdVestibular()
        {
            return idVestibular;
        }

        public void SetIdVestibular(int idVestibular)
        {
            this.idVestibular = idVestibular;
        }

        public int GetIdDisciplina()
        {
            return idDisciplina;
        }

        public void SetIdDisciplina(int idDisciplina)
        {
            this.idDisciplina = idDisciplina;
        }

        public int GetQuantidade()
        {
            return quantidade;
        }

        public void SetQuantidade(int quantidade)
        {
            this.quantidade = quantidade;
        }
    }
}
