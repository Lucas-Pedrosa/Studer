using MySql.Data.MySqlClient;
using Studer.Database;
using Studer.Models.Interfaces;
using System;

namespace Studer.Models.DAO
{
    public class EstudanteDAO : IEstudanteDAO
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
            cmd.CommandText = @"SELECT *, nome, email, senha, nascimento FROM estudante WHERE id = @id;";
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
            cmd.CommandText = @"SELECT * FROM estudante WHERE email = @email AND senha = @senha;";
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

                    return estudante;
                }
                else
                {
                    return null;
                }
            }
        }

        public bool cadastro(string nome, string email, string senha, string nascimento)
        {
            var cmd = this.mySqlDatabase.Connection.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"INSERT INTO estudante(nome, email, senha, nascimento) VALUES (@nome, @email, @senha, @nascimento);";
            cmd.Parameters.AddWithValue("@nome", nome);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@senha", senha);
            cmd.Parameters.AddWithValue("@nascimento", nascimento);

            var recs = cmd.ExecuteNonQuery();

            if (recs == 1)
            {
                return true;
            } 
            else
            {
                return false;
            }
        }
    }
}
