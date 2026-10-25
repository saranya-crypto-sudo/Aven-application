using Microsoft.Extensions.Logging;
using Aven.Services;
using Aven.ViewModels;
using Aven.ViewModels.Exercises;
using Aven.Views;
using Aven.Views.Exercises;

namespace Aven;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			})
			.ConfigureMauiHandlers(handlers =>
			{
#if ANDROID
				handlers.AddHandler(typeof(Shell), typeof(Platforms.Android.LabeledShellRenderer));
#endif
			});

		builder.Services.AddSingleton<IStorageService, StorageService>();
		builder.Services.AddSingleton<IExerciseService, ExerciseService>();
		builder.Services.AddSingleton<ISituationMappingService, SituationMappingService>();

		builder.Services.AddTransient<HomeViewModel>();
		builder.Services.AddTransient<HelpMeResetViewModel>();
		builder.Services.AddTransient<SituationsViewModel>();
		builder.Services.AddTransient<ExerciseSelectionViewModel>();
		builder.Services.AddTransient<FeedbackViewModel>();
		builder.Services.AddTransient<FavoritesViewModel>();
		builder.Services.AddTransient<ProgressViewModel>();
		builder.Services.AddTransient<SettingsViewModel>();
		builder.Services.AddTransient<LearnViewModel>();
		builder.Services.AddTransient<MoreViewModel>();
		builder.Services.AddTransient<GroundingViewModel>();
		builder.Services.AddTransient<GentleBreathingViewModel>();
		builder.Services.AddTransient<BalancedThinkingViewModel>();
		builder.Services.AddTransient<TaskBreakdownViewModel>();
		builder.Services.AddTransient<FocusControllableActionsViewModel>();
		builder.Services.AddTransient<GuidedExerciseViewModel>();
		builder.Services.AddTransient<BreathingCoachViewModel>();

		builder.Services.AddTransient<HomeView>();
		builder.Services.AddTransient<HelpMeResetView>();
		builder.Services.AddTransient<SituationsView>();
		builder.Services.AddTransient<ExerciseSelectionView>();
		builder.Services.AddTransient<FeedbackView>();
		builder.Services.AddTransient<FavoritesView>();
		builder.Services.AddTransient<ProgressView>();
		builder.Services.AddTransient<SettingsView>();
		builder.Services.AddTransient<LearnView>();
		builder.Services.AddTransient<MoreView>();
		builder.Services.AddTransient<GroundingView>();
		builder.Services.AddTransient<GentleBreathingView>();
		builder.Services.AddTransient<BalancedThinkingView>();
		builder.Services.AddTransient<TaskBreakdownView>();
		builder.Services.AddTransient<FocusControllableActionsView>();
		builder.Services.AddTransient<GuidedExerciseView>();
		builder.Services.AddTransient<BreathingCoachView>();

#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
