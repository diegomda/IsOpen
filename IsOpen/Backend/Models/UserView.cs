using Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Backend.Models
{
    [NotMapped]

    public class UserView : User
    {
        [Display(Name= "Foto")]
        public HttpPostedFileBase LogoFile { get; set; }


        [DataType(DataType.Password)]
        [Required(ErrorMessage ="El campo {0} es obligatorio")]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [Compare("Password",ErrorMessage ="las contraseñas no coinciden")]
        [Display(Name = "Confirmar Contraseña   ")]
        public string PasswordConfirm { get; set; }

    }
}