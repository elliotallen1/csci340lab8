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
    public class DeleteModel : PageModel
    {
        private readonly RazorPagesLego.Data.RazorPagesLegoContext _context;

        public DeleteModel(RazorPagesLego.Data.RazorPagesLegoContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Lego == null)
            {
                return NotFound();
            }
            var lego = await _context.Lego.FindAsync(id);

            if (lego != null)
            {
                Lego = lego;
                _context.Lego.Remove(Lego);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
