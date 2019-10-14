using System.ComponentModel.DataAnnotations;

namespace WebAPIStarter.Models
{
    public class Post
    {
        public int Id { get; set; }
        [Required]
        public object Data { get; set; }
    }
}