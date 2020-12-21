using IMCWeb.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IMCWeb.UTIL;

namespace IMCWeb.Controllers
{
    public class UserController : Controller
    {

        //TODO: criar css para a view deste controller

        public IActionResult UserIndex()
        {
            var personLogin = TempData.Get<PersonLogin>(nameof(PersonLogin));
            return View(personLogin);
        }

        public IActionResult IMC()
        {
            //TODO:passar como parâmetro para o redirect o id do usuário
            //TODO: aparentemente não tem como fazer isso, estudar mais e ver se o uso pelo tempdata é o mais correto
            return Redirect("/IMC/IMCIndex");
        }

        public IActionResult LogOut()
        {
            return Redirect("/Login/LoginIndex");
        }

    }
}
