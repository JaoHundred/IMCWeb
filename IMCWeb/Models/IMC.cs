using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMCWeb.Models
{
    public class IMC
    {
        public IMC()
        {

        }

        public int Id { get; set; }
        public double Height { get; set; }
        public double Weight { get; set; }
    }
}
