namespace TeacherStudent.ModelClasses
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class SchoolContext : DbContext
    {
        public SchoolContext()
            : base("name=School")
        {
        }

        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Teacher> Teachers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Student>()
                .Property(e => e.Class)
                .IsUnicode(false);

            modelBuilder.Entity<Teacher>()
                .Property(e => e.TeacherName)
                .IsUnicode(false);

            modelBuilder.Entity<Teacher>()
                .Property(e => e.Address)
                .IsUnicode(false);

            modelBuilder.Entity<Teacher>()
                .HasMany(e => e.Students)
                .WithOptional(e => e.Teacher)
                .WillCascadeOnDelete();
        }
    }
}
