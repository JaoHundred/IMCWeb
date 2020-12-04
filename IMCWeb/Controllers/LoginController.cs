﻿using IMCWeb.Database;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        public IActionResult Log()
        {
            return Redirect("/IMC/IMCIndex");
        }

        public IActionResult Register()
        {
            return Redirect("/Register/RegisterIndex");
        }
    }
}
