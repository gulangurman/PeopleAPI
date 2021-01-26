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
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Order> Order { get; set; }

          protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
         {
             optionsBuilder.UseMySQL("server=localhost;database=peopledb;user=peopledb_user;password=123456");
         } 
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
            
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(c => c.Id);               
            }
           );

            modelBuilder.Entity<Order>(entity => {
                entity.HasKey(o => o.Id);
                entity.HasOne(o => o.Customer).WithMany(c => c.Orders).HasForeignKey(k => k.CustomerId);
                entity.Property(o => o.DateCreated).HasDefaultValueSql("NOW()");
            });

            //custom extension method for seeding data
            modelBuilder.Seed(); 
        }
    }
}
