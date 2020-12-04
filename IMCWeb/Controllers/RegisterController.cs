using IMCWeb.Database;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public IActionResult SaveAccount()
        {
            return new BadRequestResult();
        }
    }
}
