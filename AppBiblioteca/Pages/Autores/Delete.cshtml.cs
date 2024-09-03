using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AppBiblioteca.Data;
using AppBiblioteca.Models;

namespace AppBiblioteca.Pages.Autores
{
    public class DeleteModel : PageModel
    {
        private readonly AppBiblioteca.Data.BibliotecaContext _context;

        public DeleteModel(AppBiblioteca.Data.BibliotecaContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Autor Autor { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var autor = await _context.Autores.FirstOrDefaultAsync(m => m.Id == id);

            if (autor == null)
            {
                return NotFound();
            }
            else
            {
                Autor = autor;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var autor = await _context.Autores.FindAsync(id);
            if (autor != null)
            {
                Autor = autor;
                _context.Autores.Remove(Autor);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
