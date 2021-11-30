using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Studer.Models;
using Studer.Database;
using MySql.Data.MySqlClient;
using Studer.Models.Interfaces;

namespace Studer.Models.DAO
{
    public class SimuladoDAO : ISimuladoDAO
    {
        private MySqlDatabase mySqlDatabase { get; set; }

        public SimuladoDAO(MySqlDatabase mySqlDatabase)
        {
            this.mySqlDatabase = mySqlDatabase;
        }
        
        public Simulado getSimulado(int idSimulado)
        {
            var simulado = new Simulado();

            var cmd = mySqlDatabase.Connection.CreateCommand();
            cmd.CommandText = "select questao.* from questao " +
                              "inner join simulado_realizado on questao.id = simulado_realizado.id_questao " +
                              "inner join simulado on simulado.id = simulado_realizado.id_simulado " +
                              "inner join estudante on estudante.id = simulado.id_estudante " +
                              "where simulado.id = @idSimulado;";
            cmd.Parameters.AddWithValue("@idSimulado", idSimulado);

            simulado.SetListaQuestoes(new List<Questao>());
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    Questao questao = new Questao();
                    questao.SetId(Convert.ToInt32(reader["id"]));
                    questao.SetEnunciado(reader["enunciado"].ToString());
                    questao.SetA(reader["A"].ToString());
                    questao.SetB(reader["B"].ToString());
                    questao.SetC(reader["C"].ToString());
                    questao.SetD(reader["D"].ToString());
                    questao.SetE(reader["E"].ToString());
                    questao.SetAlternativaCorreta(reader["alternativa_correta"].ToString());
                    questao.SetIdProfessor(Convert.ToInt32(reader["id_professor"]));
                    questao.SetIdDisciplina(Convert.ToInt32(reader["id_disciplina"]));
                    simulado.GetListaQuestoes().Add(questao);
                }
                simulado.SetId(idSimulado);
                return simulado;
            }
        }

        public void criaSimulado()
        {

        }
    }
}
