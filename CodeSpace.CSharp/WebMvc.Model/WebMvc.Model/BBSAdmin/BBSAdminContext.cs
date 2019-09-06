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
        public virtual DbSet<Keywords> Keywords { get; set; }
        public virtual DbSet<UserTable> UserTable { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=BBSAdmin;User ID=sa;Password=Yang123!@#");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Article>(entity =>
            {
                entity.Property(e => e.Title).HasMaxLength(200);
            });

            modelBuilder.Entity<Keywords>(entity =>
            {
                entity.Property(e => e.Content)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.KeyType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.KeyWord)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Memo)
                    .HasColumnName("memo")
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UserTable>(entity =>
            {
                entity.HasKey(e => e.Uuid)
                    .HasName("PK__UserTabl__65A475E703317E3D");

                entity.Property(e => e.Uuid)
                    .HasColumnName("UUID")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.HomePage)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Introduction).HasMaxLength(500);

                entity.Property(e => e.NickName).HasMaxLength(50);

                entity.Property(e => e.Pwd)
                    .HasColumnName("PWD")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RoleFlag)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Tel)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });
        }
    }
}
