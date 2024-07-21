using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FraxControl.Models
{
    public class LoginViewModel
        {
            [Required(ErrorMessage = "El campo {0} es requerido")]
            [Display(Name = "Usuario")]
            public string Username { get; set; }

            [Required(ErrorMessage = "El campo {0} es requerido")]
            [DataType(DataType.Password)]
            public string Password { get; set; }

            [Display(Name = "Recuérdame")]
            public bool? Remember { get; set; }
    }
}