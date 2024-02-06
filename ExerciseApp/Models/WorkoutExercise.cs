namespace ExerciseApp.Models
{
    public class WorkoutExercise
    {
        public int Id { get; set; }
        public int WorkoutId { get; set; }
        public int ExerciseId { get; set; }


        //relations
        public Workout Workout { get; set; }
        public Exercise Exercise { get; set; }
    }
}
