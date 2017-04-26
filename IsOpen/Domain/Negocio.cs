using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        public virtual User User { get; set; }
    }
}
