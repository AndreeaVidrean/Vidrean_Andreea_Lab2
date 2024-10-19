using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Vidrean_Andreea_Lab2.Data;
using Vidrean_Andreea_Lab2.Models;

namespace Vidrean_Andreea_Lab2.Pages.Books
{
    public class IndexModel : PageModel
    {
        private readonly Vidrean_Andreea_Lab2.Data.Vidrean_Andreea_Lab2Context _context;

        public IndexModel(Vidrean_Andreea_Lab2.Data.Vidrean_Andreea_Lab2Context context)
        {
            _context = context;
        }

        public IList<Book> Book { get;set; } = default!;
        public SelectList Authors { get; set; } 

        public async Task OnGetAsync()
        {
            Book = await _context.Book
            .Include(b => b.Publisher)
            .ToListAsync();

            Authors = new SelectList(await _context.Author.ToListAsync(), "ID", "FullName");
        }
    }
}
