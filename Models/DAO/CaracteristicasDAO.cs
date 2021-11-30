using MySql.Data.MySqlClient;
using Studer.Database;
using Studer.Models.Interfaces;
using System;
using System.Collections.Generic;

namespace Studer.Models.DAO
{
    public class CaracteristicasDAO : ICaracteristicasDAO
    {
        private MySqlDatabase mySqlDatabase { get; set; }

        public CaracteristicasDAO(MySqlDatabase mySqlDatabase)
        {
            this.mySqlDatabase = mySqlDatabase;
        }

        public List<Caracteristica> getCaracteristicas(string vestibular)
        {
            Caracteristica caracteristica;
            List<Caracteristica> caracteristicas = new List<Caracteristica>();

            var cmd = this.mySqlDatabase.Connection.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"select caracteristicas.* from caracteristicas
                                inner join vestibular on vestibular.id = caracteristicas.id_vestibular
                                where vestibular.nome = @vestibular;";

            cmd.Parameters.AddWithValue("@vestibular", vestibular);

            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    caracteristica = new Caracteristica();
                    caracteristica.SetId(Convert.ToInt32(reader["id"]));
                    caracteristica.SetIdDisciplina(Convert.ToInt32(reader["id_disciplina"]));
                    caracteristica.SetIdVestibular(Convert.ToInt32(reader["id_vestibular"]));
                    caracteristica.SetQuantidade(Convert.ToInt32(reader["quantidade"]));
                    caracteristicas.Add(caracteristica);
                }
            }

            return caracteristicas;
        }


    }
}
