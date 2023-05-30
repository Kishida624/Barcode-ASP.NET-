
using Microsoft.EntityFrameworkCore;
using MemberLog.Models;

namespace MemberLog.Models
{
    public class MemberLogDBContext:DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Member>().ToTable("member");
        }
        
        public MemberLogDBContext(DbContextOptions<MemberLogDBContext> options)
            : base(options)
        {
        }

        public DbSet<Member> Members { get; set; }
    }
}
