using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IMCWeb.Database;
using IMCWeb.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using IMCWeb.Repository;
using IMCWeb.Service;
using IMCWeb.UTIL;
using IMCWeb.ViewModel;

namespace IMCWeb.Controllers
{
    public class IMCController : Controller
    {
        public IMCController(IBaseRepository<PersonLogin> PersonLoginbaseRepository)
        {
            _PersonLoginbaseRepository = PersonLoginbaseRepository;
        }

        private IBaseRepository<PersonLogin> _PersonLoginbaseRepository;

        public IActionResult IMCIndex()
        {
            return View();
        }

        public IActionResult IMCAll()
        {
            var people = _PersonLoginbaseRepository.GetAllData().ToList();
            TempData.PutExt(nameof(people), people);

            //TODO:terminar de estilizar a tabela da view abaixo e ver como por essa view dentro de uma parte da IMCIndex(a parte do conteúdo)
            //TODO: ver também como relacionar as duas tabelas do litedb(personlogin e imc)
            return View("~/Views/IMC/IMCAll.cshtml");
        }

        [HttpPost]
        public IActionResult CalculateIMC([FromForm] IMCViewModel imcViewModel)
        {

            try
            {
                var person = TempData.PeekExt<PersonLogin>(nameof(PersonLogin));

                var imc = new IMC
                {
                    Height = imcViewModel.Height,
                    Weight = imcViewModel.Weight,
                };

                imc.IMCResult = IMCService.Calculate(imc.Height, imc.Weight);
                person.IMC = imc;

                _PersonLoginbaseRepository.Upsert(person, person.Id);

            }
            catch (Exception)
            {
            }

            return Redirect("/User/UserIndex");
        }
    }
}
