using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training_Center.data.Models.StudentModels;

namespace TrainingSystem.Persistance.Configrations
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
  
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasMany(s => s.StudentCourses)
              .WithOne(sc => sc.Student)
              .HasForeignKey(sc => sc.StudentId)
              .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(s => s.InstructorStudents)
                   .WithOne(p => p.Student)
                   .HasForeignKey(p => p.StudentId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
