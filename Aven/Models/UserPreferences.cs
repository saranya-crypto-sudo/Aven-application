namespace Aven.Models;

public class UserPreferences
{
    public List<string> FavoriteExerciseTypes { get; set; } = new();
    
    public int FocusSessionDurationMinutes { get; set; } = 25;
    
    public bool EnableAnimations { get; set; } = true;
    
    public bool EnableReducedMotion { get; set; } = false;
}
