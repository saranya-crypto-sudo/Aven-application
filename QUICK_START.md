# Quick Start Guide - Run Aven App Right Now

## Step 1: Open the Project in Visual Studio 2022

1. Navigate to: `C:\Users\DivakarSakthivel\Documents\Aven\Aven_Mobile_Application`
2. Double-click `Aven.sln` (solution file)
3. Visual Studio 2022 will open automatically

## Step 2: Restore NuGet Packages (if needed)

Visual Studio should restore packages automatically. If not:
- Right-click the solution in Solution Explorer
- Select "Restore NuGet Packages"
- Wait for restoration to complete

## Step 3: Select Android as Target Platform

In the Visual Studio toolbar (top center):
- Click the platform dropdown
- Select "Android"
- Click the device dropdown next to it
- Select an Android Emulator (e.g., "Pixel 5 - API 33")

⚠️ **No emulator?** 
- Click the device dropdown → "Create Android Emulator"
- Follow the wizard to create one (choose Pixel 5 or similar)
- Wait for emulator to download and install

## Step 4: Build and Run

- Press **F5** on your keyboard
- OR click the **Green Play button** in the toolbar
- Wait for the build to complete (first build takes 2-5 minutes)
- The app will automatically launch in the Android Emulator

## Step 5: Test the App

Once the app is running, try these features:

### Home Screen
- Tap "Help Me Reset" button
- Navigate to Situations, Favorites, Progress

### Help Me Reset
- Try "Grounding" exercise
- Try "Gentle Breathing" exercise
- Test the breathing animation

### Situations
- Select "Test Stress"
- See recommended exercises
- Choose an exercise

### Exercises
- Complete Grounding (3-2-1 technique)
- Complete Gentle Breathing (watch the circle animate)
- Try Balanced Thinking (enter thoughts)
- Try Task Breakdown (break down a task)
- Try Focus on Controllable Actions

### Favorites
- Complete an exercise
- Add to favorites (future enhancement)
- View favorites list

### Progress
- View session history
- See completion status
- Delete sessions

### Settings
- Change focus session duration
- View privacy information
- Delete all data (with confirmation)

### Learn
- Browse video placeholders
- Tap "Watch" (shows coming soon message)

## Step 6: Stop the App

- Press **Shift+F5** in Visual Studio
- OR click the **Stop button** (red square) in the toolbar

## Alternative: Run on Windows Desktop

If you prefer to run on Windows instead of Android:

1. In Visual Studio toolbar:
   - Change platform from "Android" to "Windows Machine"
2. Press **F5**
3. The app will run as a Windows desktop application

## Build Command Line (Optional)

If you prefer command line:

```bash
cd C:\Users\DivakarSakthivel\Documents\Aven\Aven_Mobile_Application\Aven
dotnet build -t:Run -f net10.0-android
```

## Troubleshooting

### Build fails with errors
- Ensure .NET 10.0 SDK is installed
- Ensure MAUI workloads are installed
- Restart Visual Studio

### Emulator won't start
- Open Android Studio → AVD Manager
- Start emulator from there
- Then return to Visual Studio

### App crashes on startup
- Check the output window in Visual Studio for errors
- Ensure all NuGet packages are restored
- Try Clean Solution → Rebuild

## Next Steps

After successful local testing:
1. Read `BUILD_AND_DEPLOY_GUIDE.md` for store deployment
2. Read `STORE_DEPLOYMENT_CHECKLIST.md` for store requirements
3. Prepare app icons and screenshots
4. Create developer accounts (Google Play and/or Apple)

## Need Help?

- Check the full README.md for detailed information
- Review BUILD_AND_DEPLOY_GUIDE.md for deployment steps
- Check Microsoft MAUI documentation: https://learn.microsoft.com/dotnet/maui

---

**You're ready to go!** The app should build and run successfully on your machine. 🎉
