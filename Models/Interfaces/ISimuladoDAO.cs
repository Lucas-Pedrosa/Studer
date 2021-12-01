using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Studer.Models.Interfaces
{
    interface ISimuladoDAO
    {
        public Simulado getSimulado(int idSimulado);

        public int criaSimulado(int idEstudante);
    }
}
