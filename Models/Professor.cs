using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Studer.Models
{
    public class Professor
    {
        private int id;
        private string nome;
        private string email;
        private string senha;

        public Professor()
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

        public string GetNome()
        {
            return nome;
        }

        public void SetNome(string nome)
        {
            this.nome = nome;
        }

        public string GetEmail()
        {
            return email;
        }

        public void SetEmail(string email)
        {
            this.email = email;
        }

        public string GetSenha()
        {
            return senha;
        }

        public void SetSenha(string senha)
        {
            this.senha = senha;
        }
    }
}
