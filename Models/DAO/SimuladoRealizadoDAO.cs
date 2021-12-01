using MySql.Data.MySqlClient;
using Studer.Database;
using Studer.Models.Interfaces;
using System;
using System.Collections.Generic;

namespace Studer.Models.DAO
{
    public class SimuladoRealizadoDAO : ISimuladoRealizadoDAO
    {
        private MySqlDatabase mySqlDatabase { get; set; }

        public SimuladoRealizadoDAO(MySqlDatabase mySqlDatabase)
        {
            this.mySqlDatabase = mySqlDatabase;
        }

        public void insereSimuladoRealizado(List<SimuladoRealizado> simuladoRealizado)
        {

            foreach (SimuladoRealizado simulado in simuladoRealizado)
            {
                try
                {
                    if (!(simulado.getAlternativa().Equals(null)))
                    {
                        try
                        {
                            var cmd = this.mySqlDatabase.Connection.CreateCommand() as MySqlCommand;
                            cmd.CommandText = @"INSERT INTO simulado_realizado(id_simulado, id_questao, alternativa) VALUES (@id_simulado, @id_questao, @alternativa);";
                            cmd.Parameters.AddWithValue("@id_simulado", simulado.GetIdSimulado());
                            cmd.Parameters.AddWithValue("@id_questao", simulado.getIdQuestao());
                            cmd.Parameters.AddWithValue("@alternativa", simulado.getAlternativa());

                            var recs = cmd.ExecuteNonQuery();
                        }
                        catch (MySqlException e)
                        {
                        }
                    }
                    else
                    {
                        try
                        {
                            var cmd = this.mySqlDatabase.Connection.CreateCommand() as MySqlCommand;
                            cmd.CommandText = @"INSERT INTO simulado_realizado(id_simulado, id_questao) VALUES (@id_simulado, @id_questao);";
                            cmd.Parameters.AddWithValue("@id_simulado", simulado.GetIdSimulado());
                            cmd.Parameters.AddWithValue("@id_questao", simulado.getIdQuestao());

                            var recs = cmd.ExecuteNonQuery();
                        }
                        catch (MySqlException e)
                        {
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
