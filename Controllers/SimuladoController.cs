using Microsoft.AspNetCore.Mvc;
using Studer.Models;
using System.Linq;
using System.Security.Claims;

namespace Studer.Controllers
{
    public class SimuladoController : Controller
    {
        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                Estudante estudante = new Estudante();
                estudante.SetNome(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name).Value);
                estudante.SetEmail(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email).Value);
                estudante.SetId(int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value));
                return View(estudante);
            }

            return View();
        }
    }
}
