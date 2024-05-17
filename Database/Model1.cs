using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Practice
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<AVGStudentScores> AVGStudentScores { get; set; }
        public virtual DbSet<Disciplines> Disciplines { get; set; }
        public virtual DbSet<Grades> Grades { get; set; }
        public virtual DbSet<Groups> Groups { get; set; }
        public virtual DbSet<LeaveStudents> LeaveStudents { get; set; }
        public virtual DbSet<RUP> RUP { get; set; }
        public virtual DbSet<Specialities> Specialities { get; set; }
        public virtual DbSet<Students> Students { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Teachers> Teachers { get; set; }
        public virtual DbSet<DvoechinikiVRazrezeGrupIDisciplin> DvoechinikiVRazrezeGrupIDisciplin { get; set; }
        public virtual DbSet<SpisokStudentovVRazrezeGroup> SpisokStudentovVRazrezeGroup { get; set; }
        public virtual DbSet<UchebnayaNagruzka> UchebnayaNagruzka { get; set; }
        public virtual DbSet<VedomostOcenokStudentovVRazrezeGrupIDisciplin> VedomostOcenokStudentovVRazrezeGrupIDisciplin { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AVGStudentScores>()
                .Property(e => e.AVGScore)
                .HasPrecision(5, 2);

            modelBuilder.Entity<Disciplines>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Disciplines>()
                .HasMany(e => e.RUP)
                .WithRequired(e => e.Disciplines)
                .HasForeignKey(e => e.DisciplineID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Groups>()
                .HasMany(e => e.Students)
                .WithRequired(e => e.Groups)
                .HasForeignKey(e => e.GroupID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LeaveStudents>()
                .Property(e => e.FIO)
                .IsUnicode(false);

            modelBuilder.Entity<Specialities>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Specialities>()
                .HasMany(e => e.Groups)
                .WithOptional(e => e.Specialities)
                .HasForeignKey(e => e.SpecialityID);

            modelBuilder.Entity<Students>()
                .HasMany(e => e.AVGStudentScores)
                .WithOptional(e => e.Students)
                .HasForeignKey(e => e.StudentID);

            modelBuilder.Entity<Students>()
                .HasMany(e => e.Grades)
                .WithRequired(e => e.Students)
                .HasForeignKey(e => e.StudentID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Teachers>()
                .HasMany(e => e.RUP)
                .WithRequired(e => e.Teachers)
                .HasForeignKey(e => e.TeacherID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DvoechinikiVRazrezeGrupIDisciplin>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<SpisokStudentovVRazrezeGroup>()
                .Property(e => e.SpecialityName)
                .IsUnicode(false);

            modelBuilder.Entity<UchebnayaNagruzka>()
                .Property(e => e.Имя_дисцплины)
                .IsUnicode(false);

            modelBuilder.Entity<UchebnayaNagruzka>()
                .Property(e => e.Имя_специальности)
                .IsUnicode(false);

            modelBuilder.Entity<VedomostOcenokStudentovVRazrezeGrupIDisciplin>()
                .Property(e => e.DisciplineName)
                .IsUnicode(false);
        }
    }
}
