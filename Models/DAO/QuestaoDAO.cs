using MySql.Data.MySqlClient;
using Studer.Database;
using Studer.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Studer.Models.DAO
{
    public class QuestaoDAO : IQuestaoDAO
    {
        private MySqlDatabase mySqlDatabase { get; set; }

        public QuestaoDAO(MySqlDatabase mySqlDatabase)
        {
            this.mySqlDatabase = mySqlDatabase;
        }

        public Questao getQuestao(int id)
        {
            var questao = new Questao();

            var cmd = this.mySqlDatabase.Connection.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM questao where id = @id;";
            cmd.Parameters.AddWithValue("@id", id);

            using (var reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
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
                }
                else
                {
                    return null;
                }
            }

            return questao;
        }

        public Boolean adicionaQuestao(string enunciado, string a, string b, string c, string d, string e, string alternativaCorreta, int idProfessor, int idDisciplina)
        {
            var cmd = this.mySqlDatabase.Connection.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"insert into questao(enunciado, a, b, c, d, e, alternativa_correta, id_professor, id_disciplina) values(@enunciado, @a, @b, @c, @d, @e, @alternaticaCorreta, @idProfessor, @idDisciplina);";
            cmd.Parameters.AddWithValue("@enunciado", enunciado);
            cmd.Parameters.AddWithValue("@a", a);
            cmd.Parameters.AddWithValue("@b", b);
            cmd.Parameters.AddWithValue("@c", c);
            cmd.Parameters.AddWithValue("@d", d);
            cmd.Parameters.AddWithValue("@e", e);
            cmd.Parameters.AddWithValue("@alternativaCorreta", alternativaCorreta);
            cmd.Parameters.AddWithValue("@idProfessor", idProfessor);
            cmd.Parameters.AddWithValue("@idDisciplina", idDisciplina);

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
