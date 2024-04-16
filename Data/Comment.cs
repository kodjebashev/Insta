using Insta.Data.Identity;
using System.ComponentModel.DataAnnotations;

namespace Insta.Data
{
    public class Comment
    {
        public Guid Id { get; set; }
        public string Value { get; set; } = null!;
        public AppUser User { get; set; } = null!;
        public List<AppUser> Likes { get; set; } = null!;
        public List<Comment> Comments { get; set; } = null!;
        public Post Post { get; set; } = null!;


    }
}