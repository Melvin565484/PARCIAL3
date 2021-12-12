using System.ComponentModel.DataAnnotations;
namespace webAPI.Models
{
    public class Bibliotec
    {
        [Key]
        public int BibliotecID {get; set;}
        public string title {get; set;}
        public string publishing {get; set;}
        public int ISBN {get; set;}
        public string publisheddate {get; set;}
        public string description {get; set;}
    }
}