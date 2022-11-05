using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;

namespace ExamenVuelos.Entities
{
    public class Voleto
    {
        [Key]
        public int IdVoleto { get; set; }

        [Required]
        [StringLength(50)]
        public string? NombrePasajero { get; set; }

        [Required]
        public DateTime? Fecha { get; set; }

        [Required]
        public double? Tarifa { get; set; }

        public int DestinoId { get; set; }

        public Destino? Destino { get; set; }
    }
}
