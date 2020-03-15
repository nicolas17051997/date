
using Microsoft.EntityFrameworkCore;
using DataRange.DAL.Entities;
using DataRange.DAL.Helper;

namespace DataRange.DAL.DbContex
{
   public class ApplicationContext: DbContext
    {
        public DbSet<Users> Users { get; set; }
        public DbSet<NoteDates> NoteDates { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options): base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            Users newUser = new Users
            {
                UserId = 1,
                UserName = "StarBax",
                Password = CreateHash.GetHashString("123456")
            };
            builder.Entity<Users>().HasData(new Users[] { newUser });

            base.OnModelCreating(builder);
        }
    }
}
