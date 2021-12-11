using System.ComponentModel.DataAnnotations;
namespace webAPI.Models
{
    public class Author
    {
        [Key]
        public int authorID {get; set;}
        public int name {get; set;}
        public int lastname {get; set;}

        public Bibliotec Bibliotec {get; set;}
    }
}