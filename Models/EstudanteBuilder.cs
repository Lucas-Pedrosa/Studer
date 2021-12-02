using Studer.Models.DAO;

namespace Studer.Models
{
    public abstract class EstudanteBuilder
    {
        public Simulado simulado;
        public Estudante estudante;
        public Manager manager;

        public abstract void criaSimulado();

        public abstract void criaCaracteristicas();

        public abstract void criaQuestoes();
    }
}
