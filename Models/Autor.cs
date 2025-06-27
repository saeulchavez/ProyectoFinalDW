// Models/Autor.cs
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoFinalDW.Models
{
    public class Autor
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(100, ErrorMessage = "Máximo 100 caracteres")]
        public string Nombre { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Debe ser un email válido")]
        public string Email { get; set; }

        [Display(Name = "Especialización")]
        public string? Especializacion { get; set; }  // Opcional (el ? indica nullable)

        // Relación uno-a-muchos con Pelicula
        public ICollection<Pese>? Peses { get; set; }
    }
}
