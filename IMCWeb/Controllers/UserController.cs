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

        public UserController(IBaseRepository<PersonLogin> personBaseRepository, IBaseRepository<IMC> imcBaseRepository)
        {
            _personBaseRepository = personBaseRepository;
            _imcBaseRepository = imcBaseRepository;
        }

        private readonly IBaseRepository<PersonLogin> _personBaseRepository;
        private readonly IBaseRepository<IMC> _imcBaseRepository;

        public IActionResult UserIndex()
        {
            var personLogin = _personBaseRepository.FindData(TempData.Peek<PersonLogin>(nameof(PersonLogin)).Id);
            return View(personLogin);
        }

        public IActionResult IMC()
        {
            //TODO: aparentemente não tem como fazer isso, estudar mais e ver se o uso pelo tempdata é o mais correto
            var personLogin = _personBaseRepository.FindData(TempData.Peek<PersonLogin>(nameof(PersonLogin)).Id);
            return Redirect($"/IMC/IMCIndex/{personLogin.Id}");
        }

        public IActionResult AllIMC()
        {
            return Redirect("/IMC/IMCAll");
        }

        public IActionResult LogOut()
        {
            _ = TempData.Get<PersonLogin>(nameof(PersonLogin));
            return Redirect("/Login/LoginIndex");
        }

    }
}
