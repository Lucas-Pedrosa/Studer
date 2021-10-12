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

        public int getId()
        {
            return this.id;
        }

        public void setId(int id)
        {
            this.id = id;
        }

        public int getIdEstudante()
        {
            return this.idEstudante;
        }

        public void setIdEstudante(int idEstudante)
        {
            this.idEstudante = idEstudante;
        }

        public List<Simulado> getListaSimulado()
        {
            return this.listaSimulado;
        }

        public void setListaSimulado(List<Simulado> Simulado)
        {
            this.listaSimulado = listaSimulado;
        }
    }
}
