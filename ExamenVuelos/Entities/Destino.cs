using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;

namespace ExamenVuelos.Entities
{
    public class Destino
    {
        [Key]
        public int IdDestino { get; set; }

        [Required]
        [StringLength(50)]

        public string? NombreDestino { get; set; }

        public ICollection<Voleto> Voletos { get; set; }

        public Destino()
        {
            Voletos = new HashSet<Voleto>();
        }

        public Vuelo? Vuelo { get; set; }
    }
}
