using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Vidrean_Andreea_Lab2.Models;

namespace Vidrean_Andreea_Lab2.Data
{
    public class Vidrean_Andreea_Lab2Context : DbContext
    {
        public Vidrean_Andreea_Lab2Context (DbContextOptions<Vidrean_Andreea_Lab2Context> options)
            : base(options)
        {
        }

        public DbSet<Vidrean_Andreea_Lab2.Models.Book> Book { get; set; } = default!;
        public DbSet<Vidrean_Andreea_Lab2.Models.Publisher> Publisher { get; set; } = default!;
        public DbSet<Vidrean_Andreea_Lab2.Models.Author> Author { get; set; } = default!;
    }
}
