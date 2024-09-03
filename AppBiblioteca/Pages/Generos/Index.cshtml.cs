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

namespace AppBiblioteca.Pages.Generos
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
        [BindProperty(SupportsGet = true)]
        public int? Pagina { get; set; }
        [BindProperty(SupportsGet = true)]
        public string buscarNombre { get; set; }
        public int TotalRegistros { get; set; }


        public IPagedList<Genero> Genero { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Generos != null)
            {
                var registrosPorPagina = _configuration.GetValue("RegistrosPorPagina", 10);
                var consulta = _context.Generos.Select(u => u);
                if (!string.IsNullOrEmpty(buscarNombre))
                {
                    consulta = consulta.Where(u => u.Nombre.Contains(buscarNombre));
                }
                TotalRegistros = consulta.Count();
                var numeroPagina = Pagina ?? 1;
                Genero = await consulta.ToPagedListAsync(numeroPagina, registrosPorPagina);
            }
        }
    }
}
