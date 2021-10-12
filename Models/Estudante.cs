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

        public int getInt()
        {
            return this.id;
        }

        public void setId(int id)
        {
            this.id = id;
        }

        public string getNome()
        {
            return this.nome;
        }

        public void setNome(string nome)
        {
            this.nome = nome;
        }

        public string getEmail()
        {
            return this.email;
        }

        public void setEmail(string email)
        {
            this.email = email;
        }
        public string getSenha()
        {
            return this.senha;
        }

        public void setSenha(string senha)
        {
            this.senha = senha;
        }

        public string getNascimento()
        {
            return this.nascimento;
        }

        public void setNascimento(string nascimento)
        {
            this.nascimento = nascimento;
        }

    }
}
