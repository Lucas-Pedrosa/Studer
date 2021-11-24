using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Studer.Models.Interfaces
{
    interface IProfessorDAO
    {
        public Professor getProfessor(int id);
        public Professor login(string email, string senha);
    }
}
