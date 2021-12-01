﻿using Studer.Database;
using Studer.Models;
using Studer.Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Studer.Controllers.Strategy
{
    public class LoginStrategyProfessor : LoginStrategy
    {

        public LoginStrategyProfessor(MySqlDatabase mySqlDatabase) : base(mySqlDatabase)
        {
        }

        public override Usuario Login(string email, string senha)
        {
            return manager.GetProfessorDAO().login(email, senha);
        }
    }
}
