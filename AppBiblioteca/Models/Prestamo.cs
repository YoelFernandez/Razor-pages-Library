namespace AppBiblioteca.Models;

public class Prestamo
{
    public int Id { get; set; }
    public int LibroId { get; set; }
    public virtual Libro Libro { get; set; }
    public DateOnly FechaPrestamo { get; set; }
    public DateOnly? FechaDevolucion { get; set; }
}
