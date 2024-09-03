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
    public class DetailsModel : PageModel
    {
        private readonly AppBiblioteca.Data.BibliotecaContext _context;

        public DetailsModel(AppBiblioteca.Data.BibliotecaContext context)
        {
            _context = context;
        }

        public Prestamo Prestamo { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prestamo = await _context.Prestamos.Include(u=>u.Libro).FirstOrDefaultAsync(m => m.Id == id);
            if (prestamo == null)
            {
                return NotFound();
            }
            else
            {
                Prestamo = prestamo;
            }
            return Page();
        }
    }
}
