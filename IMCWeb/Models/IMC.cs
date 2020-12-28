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
        public double IMCResult { get; set; }


        public string IMCStatus()
        {
            string status = string.Empty ;

            if (IMCResult > 30)
                status = "Obesidade";
            else if (IMCResult >= 24.9 && IMCResult < 30)
                status = "Sobrepeso";
            else if (IMCResult >= 18.5 && IMCResult < 24.9)
                status = "Normal";
            else if (IMCResult < 18.5)
                status = "Magreza";

            return status;
        }
    }
}
