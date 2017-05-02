using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

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
        [Display(Name = "Dirección")]
        public string Direccion { get; set; }

        public string Logo { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [Display(Name = "E-mail")]
        [DataType(DataType.EmailAddress)]
        public string  Email { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [DataType(DataType.PhoneNumber)]
        public string Telefono { get; set; }

        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }

        [Display(Name = "Dueño")]
        public int UserId { get; set; }

        [Display(Name = "Esta Abierto?")]
        public bool IsActive { get; set; }

        [Display(Name = "Orden")]
        public int Order { get; set; }

        [JsonIgnore]
        public virtual User User { get; set; }


    }
}
