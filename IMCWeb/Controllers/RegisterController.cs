using IMCWeb.Database;
using IMCWeb.Models;
using IMCWeb.Service;
using IMCWeb.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMCWeb.Repository;

namespace IMCWeb.Controllers
{
    public class RegisterController : Controller
    {
        public RegisterController(IBaseRepository<PersonLogin> baseRepository)
        {
            _baseRepository = baseRepository;
        }

        private IBaseRepository<PersonLogin> _baseRepository;

        public IActionResult RegisterIndex()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SaveAccount([FromForm] PersonViewModel PersonViewModel)
        {
            byte[] password = Encoding.ASCII.GetBytes(PersonViewModel.Password);
            byte[] repeatPassword = Encoding.ASCII.GetBytes(PersonViewModel.RepeatPassword);

            if (password.SequenceEqual(repeatPassword))
            {
                var collection = _baseRepository.GetAllData().ToList();

                bool newUser = !collection.Exists(p => p.UserName == PersonViewModel.UserName);

                //TODO: https://www.mking.net/blog/password-security-best-practices-with-examples-in-csharp

                if (newUser)
                {
                    byte[] salt = EncryptionService.GenerateSalt(10);
                    byte[] encryptPass = EncryptionService.GenerateHash(password, salt);

                    var personLogin = new PersonLogin
                    {
                        PasswordHash = encryptPass,
                        PasswordSalt = salt,
                        PasswordIterations = 10,
                        UserName = PersonViewModel.UserName,
                    };

                    _baseRepository.Add(personLogin);

                    //TODO: substituir depois para informações visuais mais precisas
                    // retirar os badrequest e por avisos de que determinado campo está errado ou que a conta já existe

                    return Redirect("/Login/LoginIndex");
                }
            }
            return new BadRequestResult();
        }
    }
}
