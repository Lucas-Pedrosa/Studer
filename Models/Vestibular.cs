using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Studer.Models
{
    public class Vestibular
    {
        private int id;
        private string nome;
        private List<Caracteristica> caracteristicas;
        private string ano;

        public Vestibular()
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

        public List<Caracteristica> getCaracteristicas()
        {
            return caracteristicas;
        }

        public void SetCaracteristicas(List<Caracteristica> caracteristicas)
        {
            this.caracteristicas = caracteristicas;
        }

        public string GetAno()
        {
            return ano;
        }

        public void SetAno(string ano)
        {
            this.ano = ano;
        }
    }
}
