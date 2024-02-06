using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.EFCore.Config
{
    public class WorkoutConfig : IEntityTypeConfiguration<Workout>
    {
        public void Configure(EntityTypeBuilder<Workout> builder)
        {
            builder.HasData(
                new Workout() { Id = 1, Name = "Chess Workout"},
                new Workout() { Id = 2, Name = "Arm Workout"});
        }
    }
}
