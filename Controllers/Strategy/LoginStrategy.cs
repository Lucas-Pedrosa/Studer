using Studer.Database;
using Studer.Models;
using Studer.Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Studer.Controllers
{
    public abstract class LoginStrategy
    {
        public abstract Usuario Login(string email, string senha, Manager manager);
    }
}
