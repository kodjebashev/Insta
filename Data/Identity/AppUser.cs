using System.ComponentModel.DataAnnotations;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Insta.Data.Identity
{

    public class AppUser 
    {
        public AppUser()
        {
            PostCount = 0;
        }
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public bool EmailComfirmed { get; set; }
        public string Password { get; set; }
        public Connections Connections { get; set; }
        public string Bio { get; set; } = null!;
        public bool Profesional { get; set; } = false;
        public int PostCount { get; set; }
        public List<Post> Posts { get; set; } = null!;
        public byte[] Photo { get ; set; } 
       
    }
}