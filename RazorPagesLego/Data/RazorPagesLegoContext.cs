using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RazorPagesLego.Models;

namespace RazorPagesLego.Data
{
    public class RazorPagesLegoContext : DbContext
    {
        public RazorPagesLegoContext (DbContextOptions<RazorPagesLegoContext> options)
            : base(options)
        {
        }

        public DbSet<RazorPagesLego.Models.Lego> Lego { get; set; } = default!;
    }
}
