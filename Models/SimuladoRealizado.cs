namespace Studer.Models
{
    public class SimuladoRealizado
    {
        public int idSimulado;
        public int idQuestao;
        public string alternativa;

        public int GetIdSimulado()
        {
            return idSimulado;
        }

        public void setIdSimulado(int idSimulado)
        {
            this.idSimulado = idSimulado;
        }

        public int getIdQuestao()
        {
            return idQuestao;
        }

        public void setIdQuestao(int idQuestao)
        {
            this.idQuestao = idQuestao;
        }

        public string getAlternativa()
        {
            return alternativa;
        }

        public void setAlternativa(string alternativa)
        {
            this.alternativa = alternativa;
        }
    }
}
