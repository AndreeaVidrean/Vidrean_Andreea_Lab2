using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Vidrean_Andreea_Lab2.Data;
using Vidrean_Andreea_Lab2.Models;
using Vidrean_Andreea_Lab2.Models.ViewModels;

namespace Vidrean_Andreea_Lab2.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly Vidrean_Andreea_Lab2.Data.Vidrean_Andreea_Lab2Context _context;

        public IndexModel(Vidrean_Andreea_Lab2.Data.Vidrean_Andreea_Lab2Context context)
        {
            _context = context;
        }

        public IList<Category> Category { get; set; } = default!;
        public CategoryIndexData CategoryData { get; set; } = new CategoryIndexData();

        public int CategoryID { get; set; }

        public async Task OnGetAsync(int? id)
        {
            Category = await _context.Category.ToListAsync();
            CategoryData = new CategoryIndexData();

            // Încărcăm categoriile și includem cărțile asociate
            CategoryData.Categories = await _context.Category
                .Include(c => c.BookCategories)
                    .ThenInclude(bc => bc.Book)
                        .ThenInclude(b => b.Author)
                .OrderBy(c => c.CategoryName)
                .ToListAsync();

            if (id != null)
            {
                CategoryID = id.Value;
                Category category = CategoryData.Categories
                    .Where(c => c.ID == id.Value).Single();

                // Extragem cărțile din categoria selectată
                CategoryData.Books = category.BookCategories.Select(bc => bc.Book);
            }
        }
    }
}
