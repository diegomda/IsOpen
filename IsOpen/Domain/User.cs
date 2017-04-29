using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public class User
    {

        [Key]

        public int UserId { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [Display(Name = "Nombre")]
        public string Name { get; set; }

        [Display(Name = "Dirección")]
        public string Direccion { get; set; }

        [Display(Name = "Foto")]
        public string Logo { get; set; }

        public virtual ICollection<Negocio> Negocio { get; set; }
    }
}
