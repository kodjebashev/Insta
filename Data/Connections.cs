using System.ComponentModel.DataAnnotations;

namespace Insta.Data
{
    public class Connections
    {
        [Key]
        public string Id { get; set; }
        public List<string> FollowersId { get; set; }
        public List<string> FollowingId { get; set; }
    }
}
