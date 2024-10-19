using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Vidrean_Andreea_Lab2.Data;
using Vidrean_Andreea_Lab2.Models;
using Microsoft.EntityFrameworkCore;
namespace Vidrean_Andreea_Lab2.Pages.Books
{
    public class DetailsModel : PageModel
    {
        private readonly Vidrean_Andreea_Lab2.Data.Vidrean_Andreea_Lab2Context _context;

        public DetailsModel(Vidrean_Andreea_Lab2.Data.Vidrean_Andreea_Lab2Context context)
        {
            _context = context;
        }

        public Book Book { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Book
                .Include(b => b.Author)  // Include autorul
                .Include(b => b.Publisher) // Include publisherul
                .FirstOrDefaultAsync(m => m.ID == id); // Aici se face evaluarea

            if (book == null)
            {
                return NotFound();
            }
            else
            {
                Book = book;
            }
            return Page();
        } 
    } 
}
