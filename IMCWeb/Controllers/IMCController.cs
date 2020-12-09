using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IMCWeb.Database;
using IMCWeb.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace IMCWeb.Controllers
{
    public class IMCController : Controller
    {

        private ILiteDBContext _dBContext;

        public IMCController(ILiteDBContext liteDBContext)
        {
            _dBContext = liteDBContext;
        }

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
