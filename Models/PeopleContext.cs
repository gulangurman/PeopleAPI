using System;
using Microsoft.EntityFrameworkCore;
namespace PeopleAPI.Models
{
    public class PeopleContext : DbContext
    {
        public PeopleContext(DbContextOptions opts) : base(opts)
        {

        }
        public DbSet<Blog> Blog { get; set; }
        public DbSet<Post> Post { get; set; }
        public DbSet<Book> Book { get; set; }
        public DbSet<Author> Author { get; set; }
        /*  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
         {
             optionsBuilder.UseMySQL("server=localhost;database=peopledb;user=peopledb_user;password=123456");
         } */
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Blog>(entity => entity.HasKey(e => e.BlogId));

            modelBuilder.Entity<Post>(x => x.HasKey(k => k.PostId));

            modelBuilder.Entity<Author>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired();
            });

            modelBuilder.Entity<Book>(entity =>
            {
                entity.HasKey(e => e.ISBN);
                entity.Property(e => e.Title).IsRequired();
                entity.HasOne(d => d.Author).WithMany(p => p.Books);
            });
        }
    }
}
