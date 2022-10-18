using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Dinca_Maria_Adriana_lab2.Data;
using Dinca_Maria_Adriana_lab2.Models;

namespace Dinca_Maria_Adriana_lab2.Pages.Publishers
{
    public class DetailsModel : PageModel
    {
        private readonly Dinca_Maria_Adriana_lab2.Data.Dinca_Maria_Adriana_lab2Context _context;

        public DetailsModel(Dinca_Maria_Adriana_lab2.Data.Dinca_Maria_Adriana_lab2Context context)
        {
            _context = context;
        }

      public Publisher Publisher { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Publisher == null)
            {
                return NotFound();
            }

            var publisher = await _context.Publisher.FirstOrDefaultAsync(m => m.ID == id);
            if (publisher == null)
            {
                return NotFound();
            }
            else 
            {
                Publisher = publisher;
            }
            return Page();
        }
    }
}
