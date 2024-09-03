using Microsoft.EntityFrameworkCore;
using AppBiblioteca.Models;

namespace AppBiblioteca.Data
{
    public class BibliotecaContext : DbContext
    {
        public BibliotecaContext (DbContextOptions<BibliotecaContext> options)
            : base(options)
        {
        }

        public DbSet<Autor> Autores { get; set; }
        public DbSet<Genero> Generos { get; set; }
        public DbSet<Prestamo> Prestamos { get; set; }
        public DbSet<Libro> Libros { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Autor>().ToTable("Autor");
            modelBuilder.Entity<Genero>().ToTable("Genero");
            modelBuilder.Entity<Prestamo>().ToTable("Prestamo");
            modelBuilder.Entity<Libro>().ToTable("Libro");
            base.OnModelCreating(modelBuilder);
        }
    }
}
