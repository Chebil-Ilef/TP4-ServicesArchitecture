using System.ComponentModel.DataAnnotations.Schema;

namespace TP3.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        [ForeignKey("GenresId")]
        public int? GenresId { get; set; }

        //Navigation Property
        public virtual Genre?  Genres { get; set; }
        public List<Customer>? Customers { get; set; }  
        
        //add attributes

        public DateTime? MovieAdded { get; set; }
        public string? Photo { get; set; }

        [NotMapped]
        public IFormFile? ImageFile { get; set; }

       


    }
}
