using AppBiblioteca.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using X.PagedList;

namespace AppBiblioteca.Pages.Libros
{
    public class IndexModel : PageModel
    {
        private readonly Data.BibliotecaContext _context;
        private readonly IConfiguration _configuration;

        public IndexModel(Data.BibliotecaContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }
        [BindProperty(SupportsGet = true)]
        public int? Pagina { get; set; }
        public int totalRegistros { get; set; }
        [BindProperty(SupportsGet = true)]
        public Libro.EstadoLibro? buscarEstado { get; set; }

        public IPagedList<Libro> Libro { get;set; } = default!;
        [BindProperty(SupportsGet = true)]
        public string? ordenar { get; set; }

        public async Task OnGetAsync()
        {
            if (_context.Libros != null)
            {
                var registrosPorPagina = _configuration.GetValue("RegistrosPorPagina", 10);
                var consulta = _context.Libros.Select(u=>u);
                if (buscarEstado.HasValue)
                {
                    consulta = consulta.Where(u=>u.Estado== buscarEstado.Value);
                }

                if (ordenar == "fechaAsc")
                {
                    consulta = consulta.OrderBy(u => u.FechaPublicacion);
                }
                else
                {
                    consulta = consulta.OrderByDescending(u => u.FechaPublicacion);

                }


                totalRegistros = consulta.Count();
                var numeroPagina = Pagina ?? 1;
                Libro = await consulta.Include(u=>u.Autor).Include(u=>u.Genero).ToPagedListAsync(numeroPagina, registrosPorPagina);
            }
            

        }
    }
}
