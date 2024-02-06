namespace ExerciseApp.Models
{
    public class Workout
    {
        public int Id { get; set; }

        //relations
        public int UserId { get; set; }

        //relations
        public User User { get; set; }
        public ICollection<Exercise> Exercises { get; set; }
    }
}
