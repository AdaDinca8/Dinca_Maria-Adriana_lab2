using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Dinca_Maria_Adriana_lab2.Data;
using Dinca_Maria_Adriana_lab2.Models;
using Microsoft.EntityFrameworkCore;

namespace Dinca_Maria_Adriana_lab2.Pages.Borrowings
{
    public class CreateModel : PageModel
    {
        private readonly Dinca_Maria_Adriana_lab2.Data.Dinca_Maria_Adriana_lab2Context _context;

        public CreateModel(Dinca_Maria_Adriana_lab2.Data.Dinca_Maria_Adriana_lab2Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            var bookList = _context.Book
            .Include(b => b.Author)
            .Select(x => new
        {
            x.ID,
            BookFullName = x.Title + " - " + x.Author.LastName + " " +
        x.Author.FirstName
                });

            ViewData["BookID"] = new SelectList(bookList, "ID", "BookFullName");
        ViewData["MemberID"] = new SelectList(_context.Member, "ID", "FullName");
            return Page();
        }

        [BindProperty]
        public Borrowing Borrowing { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Borrowing.Add(Borrowing);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
