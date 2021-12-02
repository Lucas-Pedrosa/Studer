namespace Studer.Models
{
    public class Avaliacao
    {
        public Avaliacao(EstudanteBuilder estudanteBuilder)
        {
            estudanteBuilder.criaSimulado();
            estudanteBuilder.criaCaracteristicas();
            estudanteBuilder.criaQuestoes();
        }
    }
}
