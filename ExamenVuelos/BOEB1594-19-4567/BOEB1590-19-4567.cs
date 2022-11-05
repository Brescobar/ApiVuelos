using Microsoft.EntityFrameworkCore;
using ExamenVuelos.Entities;
using System.Collections.Generic;

namespace ExamenVuelos.Context

{
    public class BOEB1590194567 : DbContext
    {
        public BOEB1590194567(DbContextOptions<BOEB1590194567> options) : base(options)
        {
        }

        public DbSet<Avion> Avion { get; set; }

        public DbSet<Destino> Destino { get; set; }

        public DbSet<Piloto> Piloto { get; set; }

        public DbSet<Vuelo> Vuelo { get; set; }

        public DbSet<Voleto> Voleto { get; set; }
    }
}
