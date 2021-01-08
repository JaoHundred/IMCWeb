using IMCWeb.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IMCWeb.UTIL;
using IMCWeb.Repository;

namespace IMCWeb.Controllers
{
    public class UserController : Controller
    {

        //TODO: criar css para a view deste controller

        public UserController(IBaseRepository<PersonLogin> personBaseRepository)
        {
            _personBaseRepository = personBaseRepository;
        }

        private readonly IBaseRepository<PersonLogin> _personBaseRepository;

        public IActionResult UserIndex()
        {
            return View();
        }

        public IActionResult IMC()
        {
            return Redirect("/IMC/IMCIndex");
        }

        public IActionResult IMCAll()
        {
            return Redirect("/IMC/IMCAll");
        }

        public IActionResult LogOut()
        {
            _ = TempData.GetExt<PersonLogin>(nameof(PersonLogin));
            return Redirect("/Login/LoginIndex");
        }
    }
}
