using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EFCore.Config
{
    public class WorkoutExerciseConfig : IEntityTypeConfiguration<WorkoutExercise>
    {
        public void Configure(EntityTypeBuilder<WorkoutExercise> builder)
        {
            builder.HasKey(x => new
            {
                x.Id
            });

            builder.HasOne(we => we.Workout)
            .WithMany(w => w.WorkoutExercises)
            .HasForeignKey(we => we.WorkoutId);

            builder.HasOne(we => we.Exercise)
            .WithMany(w => w.WorkoutExercises)
            .HasForeignKey(we => we.ExerciseId);
        }
    }
}
