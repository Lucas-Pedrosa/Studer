using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Studer.Models.Interfaces
{
    public interface IEstudanteDAO
    {
        public Estudante getEstudante(int id);
        public Estudante login(string email, string senha);
        public bool cadastro(string nome, string email, string senha, string nascimento);
    }
}
