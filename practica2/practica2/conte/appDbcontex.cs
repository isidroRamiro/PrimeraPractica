using Microsoft.EntityFrameworkCore;
using practica2.model;

namespace practica2.conte
{
    public class appDbcontex:DbContext
    {
        public appDbcontex(DbContextOptions<appDbcontex> options)
            : base(options)
        {

        }
        public DbSet<estudiante> estudiantes { get; set; }
        public DbSet<docente> docentes { get; set; }
        public DbSet<universidad> universidad { get; set; }
        public DbSet<Materia> materias { get; set; }
    }
}
