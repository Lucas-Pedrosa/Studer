using MySql.Data.MySqlClient;
using Studer.Database;
using Studer.Models.Interfaces;
using System;
using System.Collections.Generic;

namespace Studer.Models.DAO
{
    public class DisciplinaDAO : IDisciplinaDAO
    {
        private MySqlDatabase mySqlDatabase { get; set; }

        public DisciplinaDAO(MySqlDatabase mySqlDatabase)
        {
            this.mySqlDatabase = mySqlDatabase;
        }

        public List<Disciplina> getDisciplinas()
        {
            Disciplina disciplina;
            List<Disciplina> disciplinas = new List<Disciplina>();

            var cmd = this.mySqlDatabase.Connection.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM disciplina";

            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    disciplina = new Disciplina();
                    disciplina.SetId(Convert.ToInt32(reader["id"]));
                    disciplina.SetNome(reader["nome"].ToString());
                    disciplinas.Add(disciplina);
                }
            }

            return disciplinas;
        }
    }
}
