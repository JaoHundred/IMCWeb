using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMCWeb.Models
{
    public class PersonLogin
    {
        public PersonLogin()
        {

        }

        public int Id { get; set; }
        public string UserName { get; set; }
        public string ProtectedPassword { get; set; }
        public IMC IMC { get; set; }
    }
}
