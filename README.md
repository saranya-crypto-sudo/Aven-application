# Aven - Stress Support Mobile App

A calm, supportive stress-support mobile application for Android and iOS. Aven helps users navigate stressful moments through short guided exercises including grounding, breathing, balanced thinking, task breakdown, and focus on controllable actions.

## Features

- **Help Me Reset**: Quick access to grounding and gentle breathing exercises
- **Situation-Based Recommendations**: Select your current situation and get personalized exercise recommendations
- **Five Guided Exercises**:
  - Grounding (3-2-1 technique)
  - Gentle Breathing (animated breathing circle)
  - Balanced Thinking (distinguish facts from worries)
  - Task Breakdown (break overwhelming tasks into steps)
  - Focus on Controllable Actions (focus on what you can influence)
- **Favorites**: Save your favorite exercises for quick access
- **Progress Tracking**: View your session history and feedback
- **Learn Section**: Short animated videos about stress and coping skills (placeholder for future content)
- **Privacy-First**: Local storage only, no accounts, no cloud sync, no analytics
- **Accessibility**: Screen reader support, dynamic text scaling, reduced motion options

## Technology Stack

- **Framework**: .NET MAUI with C#
- **Database**: SQLite (sqlite-net-pcl)
- **MVVM**: CommunityToolkit.Mvvm
- **Target Platforms**: Android (API 21+) and iOS (13.0+)

## Prerequisites

### For Windows Development
- Windows 10 or later
- Visual Studio 2022 Community or higher
- .NET 10.0 SDK

### For Mac Development (iOS builds require macOS)
- macOS 12 (Monterey) or later
- Xcode 14 or later
- Visual Studio 2022 for Mac

## Setup Instructions

### 1. Install Visual Studio 2022

If you haven't already installed Visual Studio 2022, follow these steps:

1. Download Visual Studio 2022 Community from [visualstudio.microsoft.com](https://visualstudio.microsoft.com/downloads/)
2. Run the installer
3. Select the following workloads:
   - **.NET Multi-platform App UI development** (includes Android, iOS, and MAUI)
   - **.NET desktop development** (for Windows builds)
4. Click "Install" and wait for the installation to complete

### 2. Verify .NET MAUI Workload

Open a command prompt/terminal and run:

```bash
dotnet workload list
```

You should see the following workloads installed:
- `android`
- `ios` (on macOS only)
- `maccatalyst` (on macOS only)
- `maui-windows`

If any are missing, install them with:

```bash
dotnet workload install android
dotnet workload install maui-windows
```

On macOS:
```bash
dotnet workload install ios
dotnet workload install maccatalyst
```

### 3. Clone and Open the Project

```bash
cd Aven_Mobile_Application
```

Open the solution in Visual Studio 2022:
- Double-click `Aven.sln` or
- Open Visual Studio → File → Open → Project/Solution → Select `Aven.sln`

### 4. Restore NuGet Packages

Visual Studio should automatically restore packages. If not:

```bash
dotnet restore
```

Or in Visual Studio:
- Right-click the solution in Solution Explorer
- Select "Restore NuGet Packages"

## Building and Running

### Android

#### In Visual Studio
1. Set the target device to "Android Emulator" or "Android Device"
2. Press F5 or click the "Run" button
3. The app will build and deploy to the selected device/emulator

#### Command Line
```bash
cd Aven
dotnet build -t:Run -f net10.0-android
```

#### Prerequisites for Android
- Android SDK installed (comes with Visual Studio MAUI workload)
- Android Emulator configured or physical device with USB debugging enabled

### iOS (macOS only)

#### In Visual Studio for Mac
1. Set the target device to "iOS Simulator" or "iOS Device"
2. Press F5 or click the "Run" button
3. The app will build and deploy to the selected device/simulator

#### Command Line
```bash
cd Aven
dotnet build -t:Run -f net10.0-ios
```

#### Prerequisites for iOS
- Xcode 14 or later installed
- Apple Developer account (for device deployment)
- Provisioning profile configured (for App Store deployment)

### Windows

#### In Visual Studio
1. Set the target device to "Windows Machine"
2. Press F5 or click the "Run" button
3. The app will build and run as a Windows application

#### Command Line
```bash
cd Aven
dotnet build -t:Run -f net10.0-windows10.0.19041.0
```

## Running Tests

The project includes unit tests for critical services and models.

```bash
cd Aven.Tests
dotnet test
```

Or in Visual Studio:
- Open Test Explorer (Test → Test Explorer)
- Click "Run All" to execute all tests

## Project Structure

```
Aven/
├── Aven/                          # Main application project
│   ├── Models/                    # Data models
│   │   ├── Session.cs
│   │   ├── Exercise.cs
│   │   ├── Situation.cs
│   │   └── UserPreferences.cs
│   ├── ViewModels/               # MVVM view models
│   │   ├── BaseViewModel.cs
│   │   ├── HomeViewModel.cs
│   │   ├── Exercises/           # Exercise-specific view models
│   │   └── ...
│   ├── Views/                    # UI views
│   │   ├── HomeView.xaml
│   │   ├── Exercises/           # Exercise-specific views
│   │   └── ...
│   ├── Services/                 # Business logic services
│   │   ├── IStorageService.cs
│   │   ├── StorageService.cs
│   │   ├── IExerciseService.cs
│   │   ├── ExerciseService.cs
│   │   ├── ISituationMappingService.cs
│   │   └── SituationMappingService.cs
│   ├── Resources/                # Resources (styles, fonts, images)
│   │   └── Styles/
│   ├── Converters/               # Value converters
│   ├── Platforms/                # Platform-specific code
│   │   ├── Android/
│   │   ├── iOS/
│   │   ├── MacCatalyst/
│   │   └── Windows/
│   └── Data/                     # Data files
├── Aven.Tests/                   # Unit test project
│   ├── Services/
│   └── Models/
└── README.md
```

## Architecture

The app follows the MVVM (Model-View-ViewModel) pattern:

- **Models**: Data structures (Session, Exercise, Situation, UserPreferences)
- **Views**: XAML UI files
- **ViewModels**: Business logic and state management
- **Services**: Reusable business logic (storage, exercise management, situation mapping)

### Key Services

- **StorageService**: Handles SQLite database for sessions and Preferences API for settings
- **ExerciseService**: Provides exercise definitions and metadata
- **SituationMappingService**: Maps situations to recommended exercises

## Situation-to-Exercise Mappings

The app uses the following situation-to-exercise mappings:

| Situation | Recommended Exercises |
|-----------|---------------------|
| Test Stress | Balanced Thinking, Gentle Breathing, Task Breakdown |
| Presentation | Gentle Breathing, Grounding |
| Homework Overload | Task Breakdown |
| Social Overthinking | Focus on Controllable Actions |
| Sports Pressure | Focus on Controllable Actions |
| College/Future Uncertainty | Balanced Thinking |
| Unknown/General | Grounding, Gentle Breathing |

## Accessibility Features

- Screen reader support (TalkBack on Android, VoiceOver on iOS)
- Dynamic text scaling
- Reduced motion support
- Large touch targets (minimum 48x48dp)
- High contrast ratio (WCAG AA compliant)
- Semantic labels for UI elements
- Keyboard navigation support

## Privacy and Data

- **Local Storage Only**: All data is stored locally on the device
- **No Accounts**: No sign-in or authentication required
- **No Cloud Sync**: No data is transmitted to servers
- **No Analytics**: No tracking or analytics
- **Data Deletion**: Users can delete all data from Settings
- **Reflections**: User reflections are private and stored locally

## Deployment

### Android (Google Play Store)

See [STORE_DEPLOYMENT_CHECKLIST.md](STORE_DEPLOYMENT_CHECKLIST.md) for detailed deployment instructions.

1. Build release APK/AAB:
   ```bash
   dotnet publish -c Release -f net10.0-android
   ```

2. Upload to Google Play Console
3. Complete store listing
4. Submit for review

### iOS (App Store)

See [STORE_DEPLOYMENT_CHECKLIST.md](STORE_DEPLOYMENT_CHECKLIST.md) for detailed deployment instructions.

1. Build release IPA:
   ```bash
   dotnet publish -c Release -f net10.0-ios
   ```

2. Upload to App Store Connect via Xcode or Transporter
3. Complete store listing
4. Submit for review

## Troubleshooting

### Build Errors

**Issue**: "The workload 'maui' is not installed"
- **Solution**: Run `dotnet workload install maui` or install via Visual Studio Installer

**Issue**: Android emulator not starting
- **Solution**: Ensure Hyper-V is enabled on Windows and Android SDK is properly installed

**Issue**: iOS build fails on Windows
- **Solution**: iOS builds require macOS. Use a Mac or remote build service

### Runtime Errors

**Issue**: Database initialization fails
- **Solution**: Ensure the app has file system permissions (automatically granted in .NET MAUI)

**Issue**: Animations not working
- **Solution**: Check if reduced motion is enabled in device settings

## Contributing

This is a wellness application designed to be calm and supportive. When contributing:

1. Maintain the calm, non-judgmental tone
2. Follow the existing code style and architecture
3. Add unit tests for new features
4. Ensure accessibility features are maintained
5. Test on both Android and iOS if possible

## License

This project is proprietary. All rights reserved.

## Support

For issues or questions, please contact the development team.

## Acknowledgments

- .NET MAUI team for the cross-platform framework
- CommunityToolkit.Mvvm for excellent MVVM support
- SQLite-net-pcl for lightweight database functionality

## Version History

- **1.0.0** - Initial release
  - Five guided exercises
  - Situation-based recommendations
  - Favorites and progress tracking
  - Privacy-first design
  - Accessibility features
