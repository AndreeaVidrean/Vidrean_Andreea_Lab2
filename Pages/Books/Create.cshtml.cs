using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Vidrean_Andreea_Lab2.Data;
using Vidrean_Andreea_Lab2.Models;

namespace Vidrean_Andreea_Lab2.Pages.Books
{
    public class CreateModel : PageModel
    {
        private readonly Vidrean_Andreea_Lab2.Data.Vidrean_Andreea_Lab2Context _context;

        public CreateModel(Vidrean_Andreea_Lab2.Data.Vidrean_Andreea_Lab2Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["PublisherID"] = new SelectList(_context.Publisher, "ID", "PublisherName");
            ViewData["AuthorID"] = new SelectList(_context.Author, "ID", "FirstName"); 
            return Page();
        }

        [BindProperty]
        public Book Book { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Book.Add(Book);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
