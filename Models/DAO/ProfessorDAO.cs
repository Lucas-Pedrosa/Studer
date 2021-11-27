using MySql.Data.MySqlClient;
using Studer.Database;
using Studer.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Studer.Models.DAO
{
    public class ProfessorDAO : IProfessorDAO
    {
        private MySqlDatabase mySqlDatabase { get; set; }

        public ProfessorDAO(MySqlDatabase mySqlDatabase)
        {
            this.mySqlDatabase = mySqlDatabase;
        }

        public Professor getProfessor(int id)
        {
            var professor = new Professor();

            var cmd = this.mySqlDatabase.Connection.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT *, nome, email, senha, nascimento FROM professor WHERE id = @id;";
            cmd.Parameters.AddWithValue("@id", id);

            using(var reader = cmd.ExecuteReader())
            {
                if(reader.Read())
                {
                    professor.SetId(Convert.ToInt32(reader["id"]));
                    professor.SetNome(reader["nome"].ToString());
                    professor.SetEmail(reader["email"].ToString());
                }
                else
                {
                    return null;
                }
            }

            return professor;
        }

        public Professor login(string email, string senha)
        {
            var professor = new Professor();

            var cmd = this.mySqlDatabase.Connection.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM professor WHERE email = @email AND senha = @senha;";
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@senha", senha);

            using(var reader = cmd.ExecuteReader())
            {
                if(reader.Read())
                {
                    professor.SetId(Convert.ToInt32(reader["id"]));
                    professor.SetNome(reader["nome"].ToString());
                    professor.SetEmail(reader["email"].ToString());
                    professor.SetSenha(reader["senha"].ToString());
                    //professor.SetNascimento(reader["nascimento"].ToString());

                    return professor;
                }
                else
                {
                    return null;
                }
            }
        }
    }
}
