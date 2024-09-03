namespace AppBiblioteca.Models;

public class Genero
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public virtual ICollection<Libro> Libro { get; set; }
}
