// Models/Pelicula.cs
using System.ComponentModel.DataAnnotations;

namespace ProyectoFinalDW.Models
{
    public class Pese
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El título es obligatorio")]
        public string Titulo { get; set; }

        [Required]
        public string Genero { get; set; }

        [Range(1900, 2025, ErrorMessage = "Año no válido")]
        public int Año { get; set; }

       
       

      
       
    }
}
