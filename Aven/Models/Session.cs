using SQLite;

namespace Aven.Models;

public class Session
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    
    public DateTime StartTime { get; set; }
    
    public DateTime? EndTime { get; set; }
    
    public string ExerciseType { get; set; } = string.Empty;
    
    public bool IsCompleted { get; set; }
    
    public string? Feedback { get; set; } // Better, About the same, Worse
    
    public string? Reflection { get; set; } // Optional free-text reflection
    
    public string? Situation { get; set; } // The situation that led to this session
}
