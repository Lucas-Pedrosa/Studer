﻿using Microsoft.AspNetCore.Mvc;
using Studer.Models;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Studer.Controllers
{
    public class QuestaoController : Controller
    {
        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                dynamic myModel = new ExpandoObject();

                Usuario usuario = new Usuario();
                usuario.nome = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name).Value;
                usuario.email = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email).Value;
                usuario.id = int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value);
                usuario.tipo = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.UserData).Value;
                myModel.usuario = usuario;

                return View(myModel);
            }
            return RedirectToAction("Index", "Login");
        }
    }
}
