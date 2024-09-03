using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AppBiblioteca.Data;
using AppBiblioteca.Models;

namespace AppBiblioteca.Pages.Prestamos
{
    public class IndexModel : PageModel
    {
        private readonly AppBiblioteca.Data.BibliotecaContext _context;

        public IndexModel(AppBiblioteca.Data.BibliotecaContext context)
        {
            _context = context;
        }
        [BindProperty(SupportsGet =true)]
        public DateOnly? buscFechadevolucion { get; set; }

        public IList<Prestamo> Prestamo { get;set; } = default!;

        public async Task OnGetAsync()
        {
            var consulta = _context.Prestamos.Select(u=>u);
            if (buscFechadevolucion.HasValue)
            {
                consulta = consulta.Where(u=>u.FechaDevolucion == buscFechadevolucion);
            }
            Prestamo = await consulta.Include(p => p.Libro).ToListAsync();
        }
    }
}
