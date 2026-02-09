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
        }
    }
}
