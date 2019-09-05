using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebMvc.Model.BBSAdmin
{
    public partial class BBSAdminContext : DbContext
    {
        public BBSAdminContext()
        {
        }

        public BBSAdminContext(DbContextOptions<BBSAdminContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Article> Article { get; set; }
        public virtual DbSet<UserTable> UserTable { get; set; }

        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Article>(entity =>
            {
                entity.Property(e => e.Title).HasMaxLength(200);
            });

            modelBuilder.Entity<UserTable>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Sex)
                    .HasMaxLength(1)
                    .IsUnicode(false);
            });
        }
    }
}
