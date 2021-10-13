using MySql.Data.MySqlClient;
using Studer.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Studer.Models.DAO
{
    public class EstudanteDAO
    {
        private MySqlDatabase mySqlDatabase { get; set; }

        public EstudanteDAO(MySqlDatabase mySqlDatabase)
        {
            this.mySqlDatabase = mySqlDatabase;
        }

        public Estudante getEstudante(int id)
        {
            var estudante = new Estudante();

            var cmd = this.mySqlDatabase.Connection.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT id, nome, email, senha, nascimento FROM estudante where id = @id;";
            cmd.Parameters.AddWithValue("@id", id);

            using (var reader = cmd.ExecuteReader())
            {
                if(reader.Read())
                {
                    estudante.SetId(Convert.ToInt32(reader["id"]));
                    estudante.SetNome(reader["nome"].ToString());
                    estudante.SetEmail(reader["email"].ToString());
                    estudante.SetSenha(reader["senha"].ToString());
                    estudante.SetNascimento(reader["nascimento"].ToString());
                }
                else
                {
                    return null;
                }
            }

            return estudante;
        }

        public Estudante login(string email, string senha)
        {
            var estudante = new Estudante();

            var cmd = this.mySqlDatabase.Connection.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT id FROM estudante where email = @email and senha = @senha;";
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@senha", senha);

            using (var reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    estudante.SetId(Convert.ToInt32(reader["id"]));
                    estudante.SetNome(reader["nome"].ToString());
                    estudante.SetEmail(reader["email"].ToString());
                    estudante.SetSenha(reader["senha"].ToString());
                    estudante.SetNascimento(reader["nascimento"].ToString());
                }
                else
                {
                    return null;
                }
            }

            return estudante;
        }

        public bool cadastro(string nome, string email, string senha, string nascimento)
        {
            var cmd = this.mySqlDatabase.Connection.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"insert into estudante(nome, email, senha, nascimento) values(@nome, @email, @senha, @nascimento);";
            cmd.Parameters.AddWithValue("@nome", nome);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@senha", senha);
            cmd.Parameters.AddWithValue("@nascimento", nascimento);

            var recs = cmd.ExecuteNonQuery();

            if (recs == 1)
            {
                return true;
            } else
            {
                return false;
            }
        }
    }
}
