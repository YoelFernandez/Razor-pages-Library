using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AppBiblioteca.Data;
using AppBiblioteca.Models;

namespace AppBiblioteca.Pages.Libros
{
    public class EditModel : PageModel
    {
        private readonly AppBiblioteca.Data.BibliotecaContext _context;

        public EditModel(AppBiblioteca.Data.BibliotecaContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Libro Libro { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var libro =  await _context.Libros.FirstOrDefaultAsync(m => m.Id == id);
            if (libro == null)
            {
                return NotFound();
            }
            Libro = libro;
           ViewData["AutorId"] = new SelectList(_context.Autores, "Id", "Nombre");
           ViewData["GeneroId"] = new SelectList(_context.Generos, "Id", "Nombre");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Libro).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LibroExists(Libro.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool LibroExists(int id)
        {
            return _context.Libros.Any(e => e.Id == id);
        }
    }
}
