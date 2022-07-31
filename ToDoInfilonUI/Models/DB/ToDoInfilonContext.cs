using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ToDoInfilonUI.Models.DB
{
    public partial class ToDoInfilonContext : DbContext
    {
        public ToDoInfilonContext(DbContextOptions<ToDoInfilonContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AppUser> AppUser { get; set; }
        public virtual DbSet<ToDo> ToDo { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-VEK4TQG\\SQLEXPRESS;Initial Catalog=ToDoInfilon;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppUser>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(60);

                entity.Property(e => e.Pwd).HasMaxLength(12);
            });

            modelBuilder.Entity<ToDo>(entity =>
            {
                entity.Property(e => e.InsertDate)
                    .HasColumnName("INSERT_DATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.Title).HasMaxLength(150);

                entity.Property(e => e.UpdateDate)
                    .HasColumnName("UPDATE_DATE")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ToDo)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__ToDo__UserId__4BAC3F29");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
