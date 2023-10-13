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
    public class EditModel : PageModel
    {
        private readonly RazorPagesLego.Data.RazorPagesLegoContext _context;

        public EditModel(RazorPagesLego.Data.RazorPagesLegoContext context)
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

            var lego =  await _context.Lego.FirstOrDefaultAsync(m => m.Id == id);
            if (lego == null)
            {
                return NotFound();
            }
            Lego = lego;
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

            _context.Attach(Lego).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LegoExists(Lego.Id))
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

        private bool LegoExists(int id)
        {
          return (_context.Lego?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
