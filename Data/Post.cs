using Insta.Data.Identity;
using System.ComponentModel.DataAnnotations;

namespace Insta.Data
{
    public class Post
    {

        [Key]
        public Guid Id { get; set; }
        [Required]
       public byte[] Photo { get; set; }
        public string Description { get; set; } = null!;
        public AppUser User { get; set; } = null!;
        public List<AppUser> Likes { get; set; } = null!;
        public List<Comment> Comments { get; set; } = null!;
        public List<string> TagedPeople { get; set; }
    }
}