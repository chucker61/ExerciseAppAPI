namespace ExerciseApp.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }

        //relations
        public ICollection<Workout> Workouts { get; set; }
    }
}
