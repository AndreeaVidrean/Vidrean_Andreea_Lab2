using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Policy;

namespace Vidrean_Andreea_Lab2.Models
{
    public class Book
    {

        public int ID { get; set; }

        [Display(Name = "Book Title")]
        public string? Title { get; set; }

        public decimal Price { get; set; }

        public DateTime PublishingDate { get; set; }

        public int? PublisherID { get; set; }
        public Publisher? Publisher { get; set; } // Navigation property

        public int? AuthorID { get; set; } // Foreign key for Author
        public Author? Author { get; set; } // Navigation property

        public ICollection<BookCategory>? BookCategories { get; set; }
    }
    
    

}

