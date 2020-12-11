using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMCWeb.Controllers
{
    public class UserController : Controller
    {

        //TODO: criar css para a view deste controller

        public IActionResult UserIndex()
        {
            return View();
        }

        public IActionResult IMC()
        {
            //TODO:passar como parâmetro para o redirect o id do usuário
            return Redirect("/IMC/IMCIndex");
        }

        public IActionResult LogOut()
        {
            return View();
        }
        
    }
}
