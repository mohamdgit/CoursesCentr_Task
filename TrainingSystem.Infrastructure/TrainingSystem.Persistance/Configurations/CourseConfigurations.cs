using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training_Center.data.Models.CourseModel;

namespace TrainingSystem.Persistance.Configurations
{
    public class CourseConfigurations : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.HasKey(c => c.Id);

            builder.HasMany(c => c.StudentCourses)
                   .WithOne(sc => sc.Course)
                   .HasForeignKey(sc => sc.CourseId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(c => c.CourseInstructors)
                   .WithOne(ci => ci.Course)
                   .HasForeignKey(ci => ci.CourseId)
                   .OnDelete(DeleteBehavior.Cascade);
            builder.HasData(
           new Course { Id = 10, Name = "C# Basics", hours=15 },
           new Course { Id = 20, Name = "ASP.NET Core", hours = 15 },
           new Course { Id = 30, Name = "EF Core Advanced", hours = 19 });
        }
    }
}
