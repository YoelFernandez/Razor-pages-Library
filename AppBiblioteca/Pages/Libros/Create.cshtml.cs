using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using AppBiblioteca.Data;
using AppBiblioteca.Models;

namespace AppBiblioteca.Pages.Libros
{
    public class CreateModel : PageModel
    {
        private readonly AppBiblioteca.Data.BibliotecaContext _context;

        public CreateModel(AppBiblioteca.Data.BibliotecaContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["AutorId"] = new SelectList(_context.Autores, "Id", "Nombre");
        ViewData["GeneroId"] = new SelectList(_context.Generos, "Id", "Nombre");
            return Page();
        }

        [BindProperty]
        public Libro Libro { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Libros.Add(Libro);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
