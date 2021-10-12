using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Studer.Models
{
    public class Estudante
    {
        private int id;
        private string nome;
        private string email;
        private string nascimento;
        private string senha;

        public Estudante()
        {

        }

        public int GetId()
        {
            return this.id;
        }

        public void SetId(int id)
        {
            this.id = id;
        }

        public string GetNome()
        {
            return this.nome;
        }

        public void Setnome(string nome)
        {
            this.nome = nome;
        }

        public string GetEmail()
        {
            return this.email;
        }

        public void SetEmail(string email)
        {
            this.email = email;
        }
        public string GetSenha()
        {
            return this.senha;
        }

        public void SetSenha(string senha)
        {
            this.senha = senha;
        }

        public string GetNascimento()
        {
            return this.nascimento;
        }

        public void SetNascimento(string nascimento)
        {
            this.nascimento = nascimento;
        }

    }
}
