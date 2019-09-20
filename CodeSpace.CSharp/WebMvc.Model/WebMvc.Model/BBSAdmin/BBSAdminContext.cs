using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Debug;

namespace WebMvc.Model.BBSAdmin
{
    public partial class BBSAdminContext : DbContext
    {
        [Obsolete]
        public static readonly LoggerFactory LoggerFactory = new LoggerFactory(new[] { new DebugLoggerProvider((_, __) => true) });
        //public static readonly LoggerFactory LoggerFactory = new LoggerFactory(new[] { new ConsoleLoggerProvider((_, __) => true, true) });
        public BBSAdminContext()
        {
        }

        public BBSAdminContext(DbContextOptions<BBSAdminContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Keywords> Keywords { get; set; }
        public virtual DbSet<TestTable> TestTable { get; set; }
        public virtual DbSet<UserTable> UserTable { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseLoggerFactory(LoggerFactory);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Keywords>(entity =>
            {
                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Content).HasColumnType("varchar(200)");

                entity.Property(e => e.KeyType).HasColumnType("varchar(50)");

                entity.Property(e => e.KeyWord).HasColumnType("varchar(50)");

                entity.Property(e => e.Memo)
                    .HasColumnName("memo")
                    .HasColumnType("varchar(500)");

                entity.Property(e => e.Sort).HasColumnType("int(11)");
            });

            modelBuilder.Entity<TestTable>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("varchar(255)");
            });

            modelBuilder.Entity<UserTable>(entity =>
            {
                entity.HasKey(e => e.Uuid)
                    .HasName("PRIMARY");

                entity.Property(e => e.Uuid)
                    .HasColumnName("UUID")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.Email).HasColumnType("varchar(100)");

                entity.Property(e => e.HomePage).HasColumnType("varchar(500)");

                entity.Property(e => e.Introduction).HasColumnType("varchar(500)");

                entity.Property(e => e.NickName).HasColumnType("varchar(50)");

                entity.Property(e => e.Pwd)
                    .HasColumnName("PWD")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.RoleFlag).HasColumnType("varchar(50)");

                entity.Property(e => e.Tel).HasColumnType("varchar(50)");

                entity.Property(e => e.UserName).HasColumnType("varchar(50)");
            });
        }
    }
}
