using Aven.Views;
using Aven.Views.Exercises;

namespace Aven;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
		RegisterRoutes();
	}

	private static void RegisterRoutes()
	{
		Routing.RegisterRoute(nameof(HelpMeResetView), typeof(HelpMeResetView));
		Routing.RegisterRoute(nameof(SettingsView), typeof(SettingsView));
		Routing.RegisterRoute(nameof(LearnView), typeof(LearnView));
		Routing.RegisterRoute(nameof(ExerciseSelectionView), typeof(ExerciseSelectionView));
		Routing.RegisterRoute(nameof(FeedbackView), typeof(FeedbackView));
		Routing.RegisterRoute(nameof(GroundingView), typeof(GroundingView));
		Routing.RegisterRoute(nameof(GentleBreathingView), typeof(GentleBreathingView));
		Routing.RegisterRoute(nameof(BalancedThinkingView), typeof(BalancedThinkingView));
		Routing.RegisterRoute(nameof(TaskBreakdownView), typeof(TaskBreakdownView));
		Routing.RegisterRoute(nameof(FocusControllableActionsView), typeof(FocusControllableActionsView));
		Routing.RegisterRoute(nameof(GuidedExerciseView), typeof(GuidedExerciseView));
		Routing.RegisterRoute(nameof(BreathingCoachView), typeof(BreathingCoachView));
	}
}
