using Microsoft.EntityFrameworkCore;

namespace Blazor_Detalle{

    public class Contexto : DbContext{

        public DbSet<Moras> Moras { get; set;}
        public DbSet<MorasDetalle> MorasDetalle { get; set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source= Data\Prestamo.db");
        }
    }
}