using IMCWeb.Database;
using IMCWeb.Service;
using IMCWeb.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMCWeb.Models;
using Microsoft.AspNetCore.Identity;
using IMCWeb.UTIL;
using IMCWeb.Repository;

namespace IMCWeb.Controllers
{
    public class LoginController : Controller
    {
        public LoginController(IBaseRepository<PersonLogin> baseRepository)
        {
            _baseRepository = baseRepository;
        }

        private IBaseRepository<PersonLogin> _baseRepository;

        public IActionResult LoginIndex()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Log([FromForm] PersonViewModel personViewModel)
        {
            try
            {
                PersonLogin personLogin = _baseRepository.GetAllData()
                    .FirstOrDefault(p => p.UserName == personViewModel.UserName);

                if (personLogin != null)
                {
                    byte[] password = Encoding.ASCII.GetBytes(personViewModel.Password);
                    byte[] salt = personLogin.PasswordSalt;
                    byte[] encryptPass = EncryptionService.GenerateHash(password, salt);

                    if (personLogin.PasswordHash.SequenceEqual(encryptPass))
                    {
                        TempData.PutExt(nameof(PersonLogin), personLogin);
                        return Redirect($"/User/UserIndex/{personLogin.Id}");
                    }
                }
            }
            catch (Exception)
            {
                ViewData[ErrorMessageConst.LoginErrorKey] = ErrorMessageConst.LoginError;
                //TODO: criar método de extensão que salva em banco os logs de erro
            }

            ViewData[ErrorMessageConst.LoginErrorKey] = ErrorMessageConst.LoginError;
            return View("LoginIndex");
        }

        public IActionResult Register()
        {
            return Redirect("/Register/RegisterIndex");
        }
    }
}
