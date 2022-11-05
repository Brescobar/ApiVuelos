using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;

namespace ExamenVuelos.Entities
{
    public class Piloto
    {
        [Key]
        public int IdPiloto { get; set; }

        [Required]
        [StringLength(50)]

        public string? Nombres { get; set; }

        [Required]
        [StringLength(50)]

        public string? Apellidos { get; set; }

        [Required]
        [StringLength(50)]

        public string? Nacionalidad { get; set; }

        public Vuelo? Vuelo { get; set; }
    }
}
