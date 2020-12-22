using IMCWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMCWeb.Service
{
    public static class IMCService
    {
        public static double Calculate(double height, double weight)
        {
           return weight / Math.Pow(height,2);
        }
    }
}
