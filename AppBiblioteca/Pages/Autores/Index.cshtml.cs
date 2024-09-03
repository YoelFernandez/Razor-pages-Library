using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AppBiblioteca.Data;
using AppBiblioteca.Models;
using X.PagedList;

namespace AppBiblioteca.Pages.Autores
{
    public class IndexModel : PageModel
    {
        private readonly AppBiblioteca.Data.BibliotecaContext _context;
        private readonly IConfiguration _configuration;

        public IndexModel(AppBiblioteca.Data.BibliotecaContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }
        public IPagedList<Autor> Autor { get; set; } = default!;

        [BindProperty(SupportsGet =true)]
        public int? Pagina { get; set; }
        public int TotalRegistros { get; set; }
        [BindProperty(SupportsGet =true)]
        public DateOnly? buscarFecha { get; set; }
        public async Task OnGetAsync()
        {
            if (_context.Autores != null)
            {
                var registrosPorPagina = _configuration.GetValue("RegistrosPorPagina", 10);
                var consulta = _context.Autores.Select(u=>u);
                if (buscarFecha.HasValue)
                {
                    consulta = consulta.Where(u => u.FechaNacimiento == buscarFecha);
                }
                
                TotalRegistros = consulta.Count();
                var numeroPagina = Pagina ?? 1;
                Autor = await consulta.ToPagedListAsync(numeroPagina, registrosPorPagina);
            }
            //Autor = await _context.Autores.ToListAsync();
        }
    }
}
