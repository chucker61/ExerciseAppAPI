using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.EFCore.Config
{
    public class ExerciseConfig : IEntityTypeConfiguration<Exercise>
    {
        public void Configure(EntityTypeBuilder<Exercise> builder)
        {
            builder.HasData(
                new Exercise() { Id = 1, Name = "Biceps Curl", Diff = 75 },
                new Exercise() { Id = 2, Name = "Push Up", Diff = 45 },
                new Exercise() { Id = 3, Name = "Squat", Diff = 85 },
                new Exercise() { Id = 4, Name = "Pull Up", Diff = 67 },
                new Exercise() { Id = 5, Name = "Bench Press", Diff = 22 },
                new Exercise() { Id = 6, Name = "Triceps Curl", Diff = 42 },
                new Exercise() { Id = 7, Name = "Shoulder Press", Diff = 53 });
        }
    }
}
