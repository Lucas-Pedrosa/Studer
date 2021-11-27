using MySql.Data.MySqlClient;
using Studer.Database;
using Studer.Models.Interfaces;
using System;
using System.Collections.Generic;

namespace Studer.Models.DAO
{
    public class VestibularDAO : IVestibularDAO
    {
        private MySqlDatabase mySqlDatabase { get; set; }

        public VestibularDAO(MySqlDatabase mySqlDatabase)
        {
            this.mySqlDatabase = mySqlDatabase;
        }

        public List<Vestibular> getVestibulares()
        {
            Vestibular vestibular;
            List<Vestibular> vestibulares = new List<Vestibular>();

            var cmd = this.mySqlDatabase.Connection.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM vestibular";

            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    vestibular = new Vestibular();
                    vestibular.SetId(Convert.ToInt32(reader["id"]));
                    vestibular.SetNome(reader["nome"].ToString());
                    vestibular.SetAno(reader["ano"].ToString());
                    vestibulares.Add(vestibular);
                }
            }

            return vestibulares;
        }
    }
}
