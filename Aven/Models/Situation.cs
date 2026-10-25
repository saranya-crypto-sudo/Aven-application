namespace Aven.Models;

public class Situation
{
    public string Id { get; set; } = string.Empty;
    
    public string Title { get; set; } = string.Empty;
    
    public string Description { get; set; } = string.Empty;
    
    public string Icon { get; set; } = string.Empty;
    
    public List<ExerciseType> RecommendedExercises { get; set; } = new();
}
