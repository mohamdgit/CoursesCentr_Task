using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingSystem.data.Models.InstructorStudent;
using TrainingSystem.data.Models.StudentCourse;

namespace TrainingSystem.Persistance.Configurations
{
    public class InstructorStudentConfiguration : IEntityTypeConfiguration<InstructorStudent>
    {
        public void Configure(EntityTypeBuilder<InstructorStudent> builder)
        {
            builder.HasKey(p => new { p.StudentId, p.InstructorId });

            builder.HasKey( p=> new { p.StudentId, p.InstructorId });

            builder.HasOne(p => p.Student)
                   .WithMany(s => s.InstructorStudents)
                   .HasForeignKey(p => p.StudentId)
                   .OnDelete(DeleteBehavior.Cascade); 

            builder.HasOne(p => p.Instructor)
                   .WithMany(i => i.InstructorStudents)
                   .HasForeignKey(p => p.InstructorId)
                   .OnDelete(DeleteBehavior.Cascade);
            builder.HasData(
           new InstructorStudent { StudentId = 50 , InstructorId = 30 },
           new InstructorStudent { StudentId =30, InstructorId = 20 },
           new InstructorStudent { StudentId = 40, InstructorId = 20}
       );
        }
    }
}
