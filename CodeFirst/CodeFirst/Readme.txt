Microsoft.EntityFrameworkCore
Microsoft.EntityFrameworkCore.Tools
Pomelo.EntityFrameworkCore.MySql

Tạo Lớp Model
Tạo DbContext
"server=localhost;port=3306;database=TestCodeFirst;user=root;password=12345678x@X"

services.AddDbContext<MyDbContext>(options =>
                options.UseMySql(Configuration.GetConnectionString("DefaultConection"),
                new MySqlServerVersion(new Version(8, 0, 36))));

Add-Migration InitialCreate
Update-Database
Drop-Database

---------------------------
n-1
modelBuilder.Entity<Student>()
            .HasOne(s => s.ClassRoom)
            .WithMany(c => c.Students)
            .HasForeignKey(s => s.ClassRoomId);

1-1
modelBuilder.Entity<ClassRoom>()
            .HasOne(c => c.Student)
            .WithOne(s => s.ClassRoom)
            .HasForeignKey<Student>(s => s.ClassRoomId);

n-n
tạo bảng trung gian:
public class ClassRoomStudent
{
    public int ClassRoomId { get; set; }
    public ClassRoom ClassRoom { get; set; }

    public int StudentId { get; set; }
    public Student Student { get; set; }
}

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