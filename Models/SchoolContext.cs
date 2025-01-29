using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Labb2SchoolDB.Models;

public partial class SchoolContext : DbContext
{
    public SchoolContext()
    {
    }

    public SchoolContext(DbContextOptions<SchoolContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Class> Classes { get; set; }

    public virtual DbSet<ClassSubjectTeacher> ClassSubjectTeachers { get; set; }

    public virtual DbSet<Grade> Grades { get; set; }

    public virtual DbSet<Staff> Staff { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<Subject> Subjects { get; set; }

    public virtual DbSet<SubjectTeacher> SubjectTeachers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost;Database=School;User Id=sa;Password=YourPassword123; Trust Server Certificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Class>(entity =>
        {
            entity.HasKey(e => e.ClassId).HasName("PK__Classes__CB1927A0606AA2BA");

            entity.Property(e => e.ClassId).HasColumnName("ClassID");
            entity.Property(e => e.ClassName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.MentorId).HasColumnName("MentorID");

            entity.HasOne(d => d.Mentor).WithMany(p => p.Classes)
                .HasForeignKey(d => d.MentorId)
                .HasConstraintName("FK__Classes__MentorI__282DF8C2");
        });

        modelBuilder.Entity<ClassSubjectTeacher>(entity =>
        {
            entity.HasKey(e => new { e.ClassId, e.SubjectId }).HasName("PK__ClassSub__51D89D982EBE7D6D");

            entity.ToTable("ClassSubjectTeacher");

            entity.Property(e => e.ClassId).HasColumnName("ClassID");
            entity.Property(e => e.SubjectId).HasColumnName("SubjectID");
            entity.Property(e => e.TeacherId).HasColumnName("TeacherID");

            entity.HasOne(d => d.Class).WithMany(p => p.ClassSubjectTeachers)
                .HasForeignKey(d => d.ClassId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ClassSubj__Class__2B0A656D");

            entity.HasOne(d => d.Subject).WithMany(p => p.ClassSubjectTeachers)
                .HasForeignKey(d => d.SubjectId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ClassSubj__Subje__2BFE89A6");

            entity.HasOne(d => d.Teacher).WithMany(p => p.ClassSubjectTeachers)
                .HasForeignKey(d => d.TeacherId)
                .HasConstraintName("FK__ClassSubj__Teach__2CF2ADDF");
        });

        modelBuilder.Entity<Grade>(entity =>
        {
            entity.HasKey(e => e.GradeId).HasName("PK__Grades__54F87A37D4D95602");

            entity.Property(e => e.GradeId).HasColumnName("GradeID");
            entity.Property(e => e.Grade1)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("Grade");
            entity.Property(e => e.StudentId).HasColumnName("StudentID");
            entity.Property(e => e.SubjectId).HasColumnName("SubjectID");
            entity.Property(e => e.TeacherId).HasColumnName("TeacherID");

            entity.HasOne(d => d.Student).WithMany(p => p.Grades)
                .HasForeignKey(d => d.StudentId)
                .HasConstraintName("FK__Grades__StudentI__32AB8735");

            entity.HasOne(d => d.Subject).WithMany(p => p.Grades)
                .HasForeignKey(d => d.SubjectId)
                .HasConstraintName("FK__Grades__SubjectI__339FAB6E");

            entity.HasOne(d => d.Teacher).WithMany(p => p.Grades)
                .HasForeignKey(d => d.TeacherId)
                .HasConstraintName("FK__Grades__TeacherI__3493CFA7");
        });

        modelBuilder.Entity<Staff>(entity =>
        {
            entity.HasKey(e => e.StaffId).HasName("PK__Staff__96D4AAF7AB41EE76");

            entity.Property(e => e.StaffId).HasColumnName("StaffID");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Position)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Ssn)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("SSN");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.StudentId).HasName("PK__Students__32C52A7985AEDB5A");

            entity.Property(e => e.StudentId).HasColumnName("StudentID");
            entity.Property(e => e.ClassId).HasColumnName("ClassID");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Ssn)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("SSN");

            entity.HasOne(d => d.Class).WithMany(p => p.Students)
                .HasForeignKey(d => d.ClassId)
                .HasConstraintName("FK__Students__ClassI__2FCF1A8A");
        });

        modelBuilder.Entity<Subject>(entity =>
        {
            entity.HasKey(e => e.SubjectId).HasName("PK__Subjects__AC1BA3882835D453");

            entity.Property(e => e.SubjectId).HasColumnName("SubjectID");
            entity.Property(e => e.SubjectName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<SubjectTeacher>(entity =>
        {
            entity.HasKey(e => e.SubjectTeacherId).HasName("PK__SubjectT__B8B924E89948D946");

            entity.ToTable("SubjectTeacher");

            entity.Property(e => e.SubjectTeacherId).HasColumnName("SubjectTeacherID");
            entity.Property(e => e.SubjectId).HasColumnName("SubjectID");
            entity.Property(e => e.TeacherId).HasColumnName("TeacherID");

            entity.HasOne(d => d.Subject).WithMany(p => p.SubjectTeachers)
                .HasForeignKey(d => d.SubjectId)
                .HasConstraintName("FK__SubjectTe__Subje__25518C17");

            entity.HasOne(d => d.Teacher).WithMany(p => p.SubjectTeachers)
                .HasForeignKey(d => d.TeacherId)
                .HasConstraintName("FK__SubjectTe__Teach__245D67DE");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
