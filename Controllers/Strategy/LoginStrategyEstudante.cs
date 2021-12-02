using Studer.Database;
using Studer.Models;
using Studer.Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Studer.Controllers.Strategy
{
    public class LoginStrategyEstudante : LoginStrategy
    {
        public override Usuario Login(string email, string senha, Manager manager)
        {
            return manager.GetEstudanteDAO().login(email, senha);
        }
    }
}
