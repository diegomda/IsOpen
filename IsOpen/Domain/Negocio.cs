using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;

namespace Domain
{
    public class Negocio
    {
        [Key]

        public int NegocioId { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [Display(Name = "Nombre")]
        public string Name { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Direccion { get; set; }

        public string Logo { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string  Email { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Telefono { get; set; }

        public string Descripcion { get; set; }

        [Display(Name = "Dueño")]
        public int UserId { get; set; }

        [Display(Name = "Esta Abierto?")]
        public bool IsActive { get; set; }

        [Display(Name = "Orden")]
        public int Order { get; set; }

        public virtual User User { get; set; }


    }
}
