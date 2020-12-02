using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IMCWeb.Database;
using IMCWeb.Models;

namespace IMCWeb.Controllers
{
    public class IMCController : Controller
    {

        private ILiteDBContext _liteDBContext;

        public IMCController(ILiteDBContext liteDBContext)
        {
            _liteDBContext = liteDBContext;
        }

        public IActionResult IMCIndex()
        {
            return View();
        }
    }
}
