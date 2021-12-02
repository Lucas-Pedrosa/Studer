using Studer.Models;
using Studer.Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Studer.Controllers.Strategy
{
    public class LoginContext
    {
        LoginStrategy loginStrategy;

        public LoginContext(LoginStrategy loginStrategy)
        {
            this.loginStrategy = loginStrategy;
        }

        public Usuario RealizarLogin(string email, string senha, Manager manager)
        {
            return loginStrategy.Login(email, senha, manager);
        }
    }
}
