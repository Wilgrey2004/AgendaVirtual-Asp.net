using System.ComponentModel.DataAnnotations;

namespace CurdDeYoutube.Models
{
    public class ContactoModel
    {
        public int IDContacto { get; set; }

        [Required (ErrorMessage ="El Campo Nombre es Obligatorio")]
        public string? Nombre { get; set; }

		    [Required(ErrorMessage = "El Campo Telefono es Obligatorio")]
		    public string? Telefono { get; set; }

		    [Required(ErrorMessage = "El Campo Correo es Obligatorio")]
		    public string? Correo { get; set; }
    }
}
