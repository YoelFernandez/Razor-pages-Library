    namespace AppBiblioteca.Models;

public class Autor
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public DateOnly FechaNacimiento { get; set; }
    public virtual ICollection<Libro> Libro { get; set; }
}
