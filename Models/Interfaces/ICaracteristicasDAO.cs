using System.Collections.Generic;

namespace Studer.Models.Interfaces
{
    public interface ICaracteristicasDAO
    {
        public List<Caracteristica> getCaracteristicas(string vestibular);
    }
}
