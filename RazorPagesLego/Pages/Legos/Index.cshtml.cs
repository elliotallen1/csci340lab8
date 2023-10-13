using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorPagesLego.Data;
using RazorPagesLego.Models;

namespace RazorPagesLego.Pages.Legos
{
    public class IndexModel : PageModel
    {
        private readonly RazorPagesLego.Data.RazorPagesLegoContext _context;

        public IndexModel(RazorPagesLego.Data.RazorPagesLegoContext context)
        {
            _context = context;
        }

        public IList<Lego> Lego { get;set; } = default!;

        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }

        public SelectList? Titles { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? LegoTitle { get; set; }


        public async Task OnGetAsync()
    {
        var legos = from l in _context.Lego
                     select l;
        if (!string.IsNullOrEmpty(SearchString))
        {
            legos = legos.Where(s => s.Title.Contains(SearchString));
        }

        Lego = await legos.ToListAsync();
    }
    }
}
