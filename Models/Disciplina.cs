using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Studer.Models
{
    public class Disciplina
    {
        private int id;
        private string nome;

        public Disciplina(int id, string nome)
        {
            this.id = id;
            this.nome = nome;
        }

        public Disciplina(){}

        public int GetId()
        {
            return id;
        }

        public void SetId(int id)
        {
            this.id = id;
        }

        public string GetNome()
        {
            return nome;
        }

        public void SetNome(string nome)
        {
            this.nome = nome;
        }
    }
}
