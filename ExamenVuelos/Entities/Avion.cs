using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;

namespace ExamenVuelos.Entities
{
    public class Avion
    {
        [Key]
        public int IdAvion { get; set; }

        [Required]
        [StringLength(50)]
       
        public string? Nombre { get; set; }

        [Required]
        [StringLength(50)]

        public string? Serie { get; set; }

        [Required]
        [StringLength(50)]

        public string? Dimension { get; set; }

        public Vuelo? Vuelo { get; set; }
    }
}
