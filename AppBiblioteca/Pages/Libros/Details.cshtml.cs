using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AppBiblioteca.Data;
using AppBiblioteca.Models;

namespace AppBiblioteca.Pages.Libros
{
    public class DetailsModel : PageModel
    {
        private readonly AppBiblioteca.Data.BibliotecaContext _context;

        public DetailsModel(AppBiblioteca.Data.BibliotecaContext context)
        {
            _context = context;
        }

        public Libro Libro { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var libro = await _context.Libros.Include(u=>u.Autor).Include(u=>u.Genero).FirstOrDefaultAsync(m => m.Id == id);
            if (libro == null)
            {
                return NotFound();
            }
            else
            {
                Libro = libro;
            }
            return Page();
        }
    }
}
