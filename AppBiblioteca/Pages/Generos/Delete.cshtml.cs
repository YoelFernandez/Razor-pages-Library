using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AppBiblioteca.Data;
using AppBiblioteca.Models;

namespace AppBiblioteca.Pages.Generos
{
    public class DeleteModel : PageModel
    {
        private readonly AppBiblioteca.Data.BibliotecaContext _context;

        public DeleteModel(AppBiblioteca.Data.BibliotecaContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Genero Genero { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var genero = await _context.Generos.FirstOrDefaultAsync(m => m.Id == id);

            if (genero == null)
            {
                return NotFound();
            }
            else
            {
                Genero = genero;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var genero = await _context.Generos.FindAsync(id);
            if (genero != null)
            {
                Genero = genero;
                _context.Generos.Remove(Genero);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
