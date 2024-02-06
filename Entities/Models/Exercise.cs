namespace Entities.Models
{
    public class Exercise
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Diff { get; set; } // zorluk derecesi
        

        //relations
        public ICollection<WorkoutExercise> WorkoutExercises { get; set; }
    }
}
