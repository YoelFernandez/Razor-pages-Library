using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using AppBiblioteca.Data;
using AppBiblioteca.Models;

namespace AppBiblioteca.Pages.Prestamos
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

            var librosDis = _context.Libros.Select(u=>u).Where(u=>u.Disponible == true);
        ViewData["LibroId"] = new SelectList(librosDis, "Id", "Titulo");
            return Page();
        }

        [BindProperty]
        public Prestamo Prestamo { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Prestamos.Add(Prestamo)    ;
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
