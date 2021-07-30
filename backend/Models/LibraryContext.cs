using Microsoft.EntityFrameworkCore;

namespace MidAssignment.Models
{
    public class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().Property(u => u.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Book>().Property(b => b.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Category>().Property(c => c.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<BorrowingRequest>().Property(b => b.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<BorrowingRequestDetail>().Property(b => b.Id).ValueGeneratedOnAdd();

            modelBuilder.Entity<Category>().HasMany(c => c.Book).WithOne(b => b.Category).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Book>().HasMany(b => b.BorrowingRequestDetail).WithOne(b => b.Book).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<BorrowingRequest>().HasMany(b => b.BorrowingRequestDetail).WithOne(b => b.BorrowingRequest).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<User>().HasMany(u => u.UserRequest).WithOne(u => u.User).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<User>().HasMany(u => u.LibrarianRequest).WithOne(u => u.Librarian).OnDelete(DeleteBehavior.NoAction);
        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set;}
        public DbSet<User> Users { get; set; }
        public DbSet<BorrowingRequest> BorrowingRequests { get; set; }
        public DbSet<BorrowingRequestDetail> BorrowingRequestDetails { get; set; }
    }
}