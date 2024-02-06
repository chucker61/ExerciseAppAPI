namespace ExerciseApp.Models
{
    public class Exercise
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Diff { get; set; } // zorluk derecesi
        public double Correction { get; set; }
        public int WorkoutId { get; set; }

        //relations
        public Workout Workout { get; set; }
    }
}
