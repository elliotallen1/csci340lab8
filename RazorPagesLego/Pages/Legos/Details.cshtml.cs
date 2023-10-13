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
    public class DetailsModel : PageModel
    {
        private readonly RazorPagesLego.Data.RazorPagesLegoContext _context;

        public DetailsModel(RazorPagesLego.Data.RazorPagesLegoContext context)
        {
            _context = context;
        }

      public Lego Lego { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Lego == null)
            {
                return NotFound();
            }

            var lego = await _context.Lego.FirstOrDefaultAsync(m => m.Id == id);
            if (lego == null)
            {
                return NotFound();
            }
            else 
            {
                Lego = lego;
            }
            return Page();
        }
    }
}
