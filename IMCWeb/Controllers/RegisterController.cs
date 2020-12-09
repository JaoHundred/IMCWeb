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

namespace IMCWeb.Controllers
{
    public class RegisterController : Controller
    {
        private ILiteDBContext _liteDBContext;

        public RegisterController(ILiteDBContext liteDBContext)
        {
            _liteDBContext = liteDBContext;
        }

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
                var collection = _liteDBContext.LiteDatabase.GetCollection<PersonLogin>();

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

                    collection.Insert(personLogin);

                    //TODO: substituir depois para informações visuais mais precisas
                    // retirar os badrequest e por avisos de que determinado campo está errado ou que a conta já existe

                    return Redirect("/Login/LoginIndex");
                }
            }
            return new BadRequestResult();
        }
    }
}
