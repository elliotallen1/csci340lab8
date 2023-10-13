using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RazorPagesLego.Data;
using RazorPagesLego.Models;

namespace RazorPagesLego.Pages.Legos
{
    public class CreateModel : PageModel
    {
        private readonly RazorPagesLego.Data.RazorPagesLegoContext _context;

        public CreateModel(RazorPagesLego.Data.RazorPagesLegoContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Lego Lego { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Lego == null || Lego == null)
            {
                return Page();
            }

            _context.Lego.Add(Lego);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
