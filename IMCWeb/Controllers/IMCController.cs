using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IMCWeb.Database;
using IMCWeb.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using IMCWeb.Repository;

namespace IMCWeb.Controllers
{
    public class IMCController : Controller
    {
        public IMCController(IBaseRepository<IMC> IMCbaseRepository, IBaseRepository<PersonLogin> PersonLoginbaseRepository) 
        {
            _IMCbaseRepository = IMCbaseRepository;
            _PersonLoginbaseRepository = PersonLoginbaseRepository;
        }

        private IBaseRepository<IMC> _IMCbaseRepository;
        private IBaseRepository<PersonLogin> _PersonLoginbaseRepository;

        public IActionResult IMCIndex()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CalculateIMC([FromForm] IMC imc)
        {
            //TODO: ver como pegar o id do usuário logado

            return new BadRequestResult();
        }
    }
}
