using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMCWeb.Models
{
    public class UserViewState
    {
        private bool _showIMC = false;
        public bool ShowIMC
        {
            get => _showIMC;
            set
            {
                _showIMCAll = !value;
                _showIMC = value;
            }
        }

        private bool _showIMCAll = false;
        public bool ShowIMCAll
        {
            get => _showIMCAll;
            set
            {
                ShowIMC = !value;   
                _showIMCAll = value;
            }
        }
    }
}
