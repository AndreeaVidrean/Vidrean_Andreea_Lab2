using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Vidrean_Andreea_Lab2.Data;
using Vidrean_Andreea_Lab2.Models;

namespace Vidrean_Andreea_Lab2.Pages.Authors
{
    public class IndexModel : PageModel
    {
        private readonly Vidrean_Andreea_Lab2.Data.Vidrean_Andreea_Lab2Context _context;

        public IndexModel(Vidrean_Andreea_Lab2.Data.Vidrean_Andreea_Lab2Context context)
        {
            _context = context;
        }

        public IList<Author> Author { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Author = await _context.Author.ToListAsync();
        }
    }
}
