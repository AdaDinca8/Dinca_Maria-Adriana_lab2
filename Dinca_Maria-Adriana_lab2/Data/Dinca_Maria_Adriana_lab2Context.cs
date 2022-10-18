using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Dinca_Maria_Adriana_lab2.Models;

namespace Dinca_Maria_Adriana_lab2.Data
{
    public class Dinca_Maria_Adriana_lab2Context : DbContext
    {
        public Dinca_Maria_Adriana_lab2Context (DbContextOptions<Dinca_Maria_Adriana_lab2Context> options)
            : base(options)
        {
        }

        public DbSet<Dinca_Maria_Adriana_lab2.Models.Book> Book { get; set; } = default!;

        public DbSet<Dinca_Maria_Adriana_lab2.Models.Publisher> Publisher { get; set; }
    }
}
