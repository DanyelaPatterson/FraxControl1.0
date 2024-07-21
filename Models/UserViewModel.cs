using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FraxControl.Models
{
    public class UserViewModel
    {
        public UserViewModel()
        {
            
        }

        public string Username { get; set; }

        public string Email { get; set;}

        public bool Confirmed { get; set; }

    }
}