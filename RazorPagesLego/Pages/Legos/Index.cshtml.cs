using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
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

        public async Task OnGetAsync()
        {
            if (_context.Lego != null)
            {
                Lego = await _context.Lego.ToListAsync();
            }
        }
    }
}
