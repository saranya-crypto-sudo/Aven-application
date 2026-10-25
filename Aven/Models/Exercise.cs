namespace Aven.Models;

public enum ExerciseType
{
    Grounding,
    GentleBreathing,
    BalancedThinking,
    TaskBreakdown,
    FocusControllableActions,
    FiveSenses,
    BoxBreathing,
    FourSevenEight,
    PhysiologicalSigh,
    BodyScan,
    ProgressiveMuscle,
    Visualization,
    MindfulStretch,
    Orientation
}

public class Exercise
{
    public ExerciseType Type { get; set; }

    public string Title { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public string Icon { get; set; } = string.Empty;

    public int DurationMinutes { get; set; }

    public bool IsReset { get; set; }

    public string Accent { get; set; } = "#5A8A7A";
}
