using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training_Center.data.Models.CourseModel;
using Training_Center.data.Models.InstructorModel;

namespace TrainingSystem.Persistance.Configrations
{
    public class InstructorConfigurations : IEntityTypeConfiguration<Instructor>
    {
        public void Configure(EntityTypeBuilder<Instructor> builder)
        {

            builder.HasMany(i => i.InstructorStudents)
                   .WithOne(p => p.Instructor)
                   .HasForeignKey(p => p.InstructorId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(i => i.Course)
                   .WithMany(c => c.CourseInstructors)
                   .HasForeignKey(i => i.CourseId)
                   .OnDelete(DeleteBehavior.Restrict);
            builder.HasData(
           new Instructor { Id=20,Name = "Mr. Ali", Email = "ali@example.com", PhoneNumber = "0123456789", CourseId =20 },
           new Instructor { Id = 30,Name = "Mrs. Mona", Email = "Mona@example.com", PhoneNumber = "0123456789", CourseId =30 }
           );
        }
    }
}
