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
            IEnumerable<PersonLogin> people = _PersonLoginbaseRepository.GetAllData();
            TempData.PutExt(nameof(IEnumerable<PersonLogin>), people);

            return View("~/Views/IMC/IMCAll.cshtml");
        }

        [HttpPost]
        public IActionResult CalculateIMC([FromForm] IMCViewModel imcViewModel)
        {
            //TODO: criar tratamento na view, não deixar que seja digitado letras onde deveria ter números
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

            //TODO: modificar o redirect abaixo e retornar apenas uma mensagem de sucesso de dados gravados
            return Redirect("/User/UserIndex");
        }
    }
}
