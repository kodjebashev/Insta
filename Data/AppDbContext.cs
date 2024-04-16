
using Insta.Data.Identity;
using Microsoft.EntityFrameworkCore;

namespace Insta.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        {
            
        }
        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }

        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<AppUser>()
                .HasMany(u => u.Posts)
                .WithOne(p => p.User);

            builder.Entity<Post>()
                .HasMany(p => p.Likes);

            builder.Entity<Post>()
                .HasMany(p => p.Comments)
                .WithOne(c => c.Post);

            builder.Entity<Comment>()
                .HasMany(p => p.Comments);
            base.OnModelCreating(builder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-OA9GBEF\SQLEXPRESS;Database=Insta;Integrated Security=true;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=true");
        }
    }
}