using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;

namespace ExamenVuelos.Entities
{
    public class Vuelo
    {
        [Key]
        public int IdVuelo { get; set; }

        [Required]
        public DateTime? horaFechaSalida { get; set; }

        [Required]
        public DateTime? horaFechaLlegada { get; set; }

        public int DestinoId { get; set; }

        public Destino? Destino { get; set; }

        public int PilotoId { get; set; }

        public Piloto? Piloto { get; set; }

        public int AvionId { get; set; }

        public Avion? Avion { get; set; }
    }
}
