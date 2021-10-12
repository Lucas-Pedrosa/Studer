using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Studer.Models
{
    public class Desempenho
    {
        private int id;
        private int idEstudante;
        private List<Simulado> listaSimulado;

        public Desempenho()
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

        public int GetIdEstudante()
        {
            return idEstudante;
        }

        public void SetIdEstudante(int idEstudante)
        {
            this.idEstudante = idEstudante;
        }

        public List<Simulado> GetListaSimulado()
        {
            return listaSimulado;
        }

        public void SetListaSimulado(List<Simulado> listaSimulado)
        {
            this.listaSimulado = listaSimulado;
        }
    }
}
