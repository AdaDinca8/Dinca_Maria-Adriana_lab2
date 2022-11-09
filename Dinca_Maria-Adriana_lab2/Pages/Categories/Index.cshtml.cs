using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Dinca_Maria_Adriana_lab2.Data;
using Dinca_Maria_Adriana_lab2.Models;
using Dinca_Maria_Adriana_lab2.Models.ViewModels;

namespace Dinca_Maria_Adriana_lab2.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly Dinca_Maria_Adriana_lab2.Data.Dinca_Maria_Adriana_lab2Context _context;

        public IndexModel(Dinca_Maria_Adriana_lab2.Data.Dinca_Maria_Adriana_lab2Context context)
        {
            _context = context;
        }

        public IList<Category> Category { get; set; } = default!;

        public CategoryIndexData CategoryData { get; set; }
        public int CategoryID { get; set; }
        public int BookID { get; set; }
        public async Task OnGetAsync(int? id, int? bookID)
        {
            CategoryData = new CategoryIndexData();
            CategoryData.Categories = await _context.Category
            .Include(i => i.BookCategories)
            .ThenInclude(c => c.Book)
            .ThenInclude(c => c.Author)
            .OrderBy(i => i.CategoryName)
            .ToListAsync();
            if (id != null)
            {
                CategoryID = id.Value;
                Category category = CategoryData.Categories
                .Where(i => i.ID == id.Value).Single();
                CategoryData.BookCategories = category.BookCategories;
            }

            
        }
    }
}
