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

namespace IMCWeb.Controllers
{
    public class LoginController : Controller
    {
        private ILiteDBContext _liteDBContext;

        public LoginController(ILiteDBContext liteDBContext)
        {
            _liteDBContext = liteDBContext;
        }

        public IActionResult LoginIndex()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Log([FromForm] PersonViewModel personViewModel)
        {
            PersonLogin personLogin = _liteDBContext.LiteDatabase.GetCollection<PersonLogin>()
                .FindAll().FirstOrDefault(p => p.UserName == personViewModel.UserName );

            if (personLogin != null)
            {
                byte[] password = Encoding.ASCII.GetBytes(personViewModel.Password);
                byte[] salt = personLogin.PasswordSalt;
                byte[] encryptPass = EncryptionService.GenerateHash(password, salt);

                if (personLogin.PasswordHash.SequenceEqual(encryptPass))
                {
                    return Redirect("/IMC/IMCIndex");
                }
            }

            //TODO:modificar o retorno para usuário não cadastrado/errado
            return new BadRequestResult();
        }

        public IActionResult Register()
        {
            return Redirect("/Register/RegisterIndex");
        }
    }
}
