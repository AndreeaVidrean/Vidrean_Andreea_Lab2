using System.ComponentModel.DataAnnotations;

namespace Vidrean_Andreea_Lab2.Models
{
    public class Author
    {
        public int ID { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
       // public string FullName => $"{FirstName} {LastName}";
        [Display(Name = "FullName")]
        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }
        public ICollection<Book> Books { get; set; } = new List<Book>();
    }


    }

