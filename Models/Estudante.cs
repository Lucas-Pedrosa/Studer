using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Studer.Models
{
    public class Estudante : Usuario
    {
        private string nascimento;
        private string senha;
        private Desempenho desempenho;

        public Estudante()
        {}

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

        public void SetNome(string nome)
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

        public Desempenho GetDesempenho()
        {
            return this.desempenho;
        }

        public void setDesempenho(Desempenho desempenho)
        {
            this.desempenho = desempenho;
        }

    }
}
