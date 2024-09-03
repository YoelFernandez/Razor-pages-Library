using System.ComponentModel.DataAnnotations;

namespace AppBiblioteca.Models;

public class Libro
{
    public int Id { get; set; }
    public string Titulo { get; set; }
    public DateOnly FechaPublicacion { get; set; }
    public int AutorId { get; set; }
    public virtual Autor Autor { get; set; }
    public int GeneroId { get; set; }
    public virtual Genero Genero { get; set; }
    [Required]
    [Display(Name = "Estado del libro")]
    //Poner aca los valores que estan permitidos
    //public EstadoLibro Estado { get; set; }
    public EstadoLibro Estado { get; set; }
    public bool Disponible { get; set; }
    public enum EstadoLibro
    {
        Disponible,
        Prestado,
        Reservado,
        Mantenimiento
    }   
}
