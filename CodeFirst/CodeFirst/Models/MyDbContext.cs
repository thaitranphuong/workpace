using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeFirst.Models
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<ClassRoom> ClassRooms { get; set; }
        public DbSet<ClassRoomStudent> lassRoomStudents { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClassRoomStudent>()
                .HasKey(cs => new { cs.ClassRoomId, cs.StudentId });

            modelBuilder.Entity<ClassRoomStudent>()
                .HasOne(cs => cs.ClassRoom)
                .WithMany(c => c.ClassRoomStudents)
                .HasForeignKey(cs => cs.ClassRoomId);

            modelBuilder.Entity<ClassRoomStudent>()
                .HasOne(cs => cs.Student)
                .WithMany(s => s.ClassRoomStudents)
                .HasForeignKey(cs => cs.StudentId);

            modelBuilder.Entity<ClassRoom>()
                .HasOne(c => c.student)
                .WithMany(s => s.classRooms)
                .HasForeignKey(c => c.studentId);

            modelBuilder.Entity<Student>()
                .HasOne(s => s.classRoom)
                .WithMany(c => c.students)
                .HasForeignKey(s => s.classroomId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
