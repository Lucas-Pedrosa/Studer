using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Studer.Models
{
    public class Questao
    {
        private int id;
        private string enunciado;
        private string a;
        private string b;
        private string c;
        private string d;
        private string e;
        private string alternativaCorreta;
        private int idProfessor;
        private int idDisciplina;

        public Questao()
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

        public string GetEnunciado()
        {
            return enunciado;
        }

        public void SetEnunciado(string enunciado)
        {
            this.enunciado = enunciado;
        }

        public string GetA()
        {
            return a;
        }

        public void SetA(string a)
        {
            this.a = a;
        }

        public string GetB()
        {
            return b;
        }

        public void SetB(string b)
        {
            this.b = b;
        }

        public string GetC()
        {
            return c;
        }

        public void SetC(string c)
        {
            this.c = c;
        }

        public string GetD()
        {
            return d;
        }

        public void SetD(string d)
        {
            this.d = d;
        }

        public string GetE()
        {
            return e;
        }

        public void SetE(string e)
        {
            this.e = e;
        }

        public string GetAlternativaCorreta()
        {
            return alternativaCorreta;
        }

        public void SetAlternativaCorreta(string alternativaCorreta)
        {
            this.alternativaCorreta = alternativaCorreta;
        }

        public int GetIdProfessor()
        {
            return this.idProfessor;
        }
        public void SetIdProfessor(int idProfessor)
        {
            this.idProfessor = idProfessor;
        }

        public int GetIdDisciplina()
        {
            return this.idDisciplina;
        }

        public void SetIdDisciplina(int idDisciplina)
        {
            this.idDisciplina = idDisciplina;
        }
    }
}
