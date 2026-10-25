# Build and Test Aven App as APK/AAB - Android Guide

## Table of Contents
1. [Build for Android](#build-for-android)
2. [Test on Android Emulator](#test-on-android-emulator)
3. [Test on Physical Android Device](#test-on-physical-android-device)
4. [Troubleshooting](#troubleshooting)

---

## Build for Android

### Step 1: Open the Project in Visual Studio 2022

1. Navigate to: `C:\Users\DivakarSakthivel\Documents\Aven\Aven_Mobile_Application`
2. Double-click `Aven.sln` to open in Visual Studio 2022
3. Wait for the solution to load

### Step 2: Select Android as Target Platform

In the Visual Studio toolbar (top center):
- Click the platform dropdown (should show "Windows Machine" by default)
- Select **"Android"**
- Click the device dropdown next to it
- Select an Android Emulator (e.g., "Pixel 5 - API 33")

⚠️ **No emulator?** See section below on setting up emulator

### Step 3: Build Debug APK (for Testing)

#### Option A: Build and Run (Automatic)
- Press **F5** or click the **Green Play button**
- Visual Studio will build and deploy to the emulator
- The app will launch automatically

#### Option B: Build APK File (Manual)
1. In Visual Studio, go to **Build** → **Build Solution** (Ctrl+Shift+B)
2. Wait for build to complete (should say "Build succeeded")
3. Go to **Build** → **Publish Aven**
4. In the publish dialog:
   - Target Framework: **net10.0-android**
   - Configuration: **Release** (for testing, Debug also works)
   - Click **Publish**
5. The APK will be created in: `Aven\bin\Release\net10.0-android\publish\`

### Step 4: Build AAB for Google Play (Optional)

For Google Play Store submission, you need an AAB (Android App Bundle):

1. In Visual Studio, right-click the `Aven` project
2. Select **Properties**
3. Go to **Android** → **Package**
4. Change **Package Format** to **Android App Bundle (.aab)**
5. Build the project: **Build** → **Build Solution**
6. The AAB will be in: `Aven\bin\Release\net10.0-android\publish\`

---

## Test on Android Emulator

### Step 1: Set Up Android Emulator (if not already done)

#### Using Visual Studio Emulator Manager:

1. In Visual Studio, go to **Tools** → **Android** → **Android Device Manager**
2. Click **"Create Device"** (or similar button)
3. Choose a device:
   - **Base Device**: Pixel 5
   - **OS**: Android 13.0 (API 33) or higher
   - **Processor**: x86_64 (for Windows) or ARM64 (for Mac/Linux)
4. Click **"Next"** → **"Finish"**
5. Wait for the emulator to download and install (may take 5-10 minutes first time)

#### Using Android Studio Emulator (Alternative):

1. Download Android Studio: https://developer.android.com/studio
2. Install and open Android Studio
3. Go to **Tools** → **Device Manager**
4. Click **"Create Virtual Device"**
5. Follow the wizard to create a device
6. Start the emulator from there

### Step 2: Select Emulator in Visual Studio

1. In Visual Studio toolbar, click the device dropdown
2. Select your created emulator (e.g., "Pixel 5 - API 33")
3. The dropdown should show the emulator name

### Step 3: Build and Run

1. Press **F5** or click the **Green Play button**
2. Wait for build to complete (first build: 2-5 minutes)
3. The app will automatically launch in the emulator
4. Test all features

### Step 4: Navigate the App

Once the app is running, test these features:

#### Home Screen
- ✅ "Help Me Reset" button
- ✅ Navigate to Situations, Favorites, Progress
- ✅ Tap Learn section

#### Help Me Reset
- ✅ Select "Grounding"
- ✅ Select "Gentle Breathing"
- ✅ Test the breathing animation

#### Situations
- ✅ Select "Test Stress"
- ✅ See recommended exercises
- ✅ Choose an exercise
- ✅ Try "Not sure what's bothering you?"

#### Exercises

**Grounding:**
- ✅ Go through 3-2-1 technique
- ✅ Click "Next" through steps
- ✅ Test "Continue" at the end
- ✅ Test "Quit" button

**Gentle Breathing:**
- ✅ Click "Start Breathing"
- ✅ Watch the circle animate
- ✅ Test "Stop" button
- ✅ Test "Try Grounding" button
- ✅ Test "Quit" button

**Balanced Thinking:**
- ✅ Enter thoughts in text fields
- ✅ Navigate through all steps
- ✅ Test "Complete" at the end

**Task Breakdown:**
- ✅ Select difficulty option
- ✅ Enter task and first step
- ✅ Test the actions

**Focus on Controllable Actions:**
- ✅ Enter outcome and action
- ✅ Complete the exercise

#### Favorites
- ✅ View favorites list
- ✅ Test empty state (no favorites yet)
- ✅ Add/remove favorites (future enhancement)

#### Progress
- ✅ View session history
- ✅ See completion status
- ✅ Delete individual sessions
- ✅ Test "Delete All History"
- ✅ Test empty state

#### Settings
- ✅ Change focus session duration
- ✅ View privacy information
- ✅ Test "Delete All Data" (with confirmation)

#### Learn
- ✅ Browse video placeholders
- ✅ Tap "Watch" (shows coming soon message)

---

## Test on Physical Android Device

### Step 1: Enable USB Debugging on Your Device

1. On your Android device, go to **Settings**
2. Scroll down and tap **About Phone** (or "About Device")
3. Tap **Build Number** 7 times quickly
4. Go back to **Settings** → **System** → **Developer Options**
5. Enable **USB Debugging**
6. Go back to **Settings** → **Connected Devices**
7. Enable **USB Debugging** (might need to accept prompt)

### Step 2: Connect Device to Computer

1. Connect your Android device to your computer via USB cable
2. Allow USB debugging if prompted on the device
3. The device should now appear in Visual Studio's device dropdown

### Step 3: Select Device in Visual Studio

1. In Visual Studio toolbar, click the device dropdown
2. Select your physical device (it will show the device name)
3. Example: "Samsung Galaxy S21"

### Step 4: Build and Run

1. Press **F5** or click the **Green Play button**
2. Wait for build to complete
3. The app will install and launch on your device
4. Test all features as described above

### Step 5: Test on Different Devices

For thorough testing, try on:
- **Small phone** (e.g., Samsung Galaxy S)
- **Large phone** (e.g., Pixel 7 Pro)
- **Tablet** (if applicable)
- **Different Android versions** (Android 10, 11, 12, 13, 14)

---

## Build APK/AAB via Command Line

### Method 1: Build Debug APK (Testing)

```bash
cd C:\Users\DivakarSakthivel\Documents\Aven\Aven_Mobile_Application\Aven
dotnet build -c Debug -f net10.0-android
```

The APK will be in: `bin\Debug\net10.0-android\`

### Method 2: Build Release APK (Production)

```bash
cd C:\Users\DivakarSakthivel\Documents\Aven\Aven_Mobile_Application\Aven
dotnet build -c Release -f net10.0-android
```

The APK will be in: `bin\Release\net10.0-android\`

### Method 3: Build AAB (for Play Store)

```bash
cd C:\Users\DivakarSakthivel\Documents\Aven\Aven_Mobile_Application\Aven
dotnet publish -c Release -f net10.0-android /p:AndroidPackageFormat=bundle
```

The AAB will be in: `bin\Release\net10.0-android\publish\`

### Method 4: Build and Run Directly

```bash
cd C:\Users\DivakarSakthivel\Documents\Aven\Aven_Mobile_Application\Aven
dotnet build -t:Run -f net10.0-android
```

---

## Troubleshooting

### Issue: "No Android emulators found"

**Solution:**
1. Go to **Tools** → **Android** → **Android Device Manager**
2. Click **"Create Device"**
3. Follow the wizard to create a Pixel 5 emulator
4. Wait for it to download and install

### Issue: Emulator won't start

**Solution:**
1. Make sure Hyper-V is enabled on Windows
2. Open Windows Features: Turn Windows features on or off
3. Enable:
   - Hyper-V
   - Virtual Machine Platform
   - Windows Subsystem for Linux
4. Restart computer
5. Try starting emulator again

### Issue: Build fails with errors

**Solution:**
1. Run **Build** → **Clean Solution**
2. Run **Build** → **Build Solution** again
3. Check for missing NuGet packages
4. Ensure .NET MAUI workloads are installed:
   ```bash
   dotnet workload list
   ```
5. If workloads missing, install:
   ```bash
   dotnet workload install maui
   dotnet workload install android
   ```

### Issue: App crashes on startup

**Solution:**
1. Check the Output window in Visual Studio for error messages
2. Ensure database initialization is working
3. Check if navigation parameters are correct
4. Try running in Debug mode to see detailed error info

### Issue: Device not detected

**Solution:**
1. Ensure USB debugging is enabled on device
2. Try a different USB cable
3. Try a different USB port
4. Reinstall device drivers
5. On device: Revoke USB debugging authorization, then re-enable

### Issue: APK won't install on device

**Solution:**
1. Enable "Install from unknown sources" in device settings
2. Uninstall any previous version of the app
3. Try installing again
4. Check Android version compatibility (min API 21)

### Issue: AAB won't upload to Play Console

**Solution:**
1. Ensure the bundle is signed with a release keystore
2. Check if target SDK is correct (should be API 34+)
3. Verify app icon and screenshots meet Play Store requirements
4. Check for any manifest errors

---

## Quick Reference Commands

### Build Commands

```bash
# Navigate to project
cd C:\Users\DivakarSakthivel\Documents\Aven\Aven_Mobile_Application\Aven

# Clean build
dotnet clean

# Restore packages
dotnet restore

# Build for Android (Debug)
dotnet build -c Debug -f net10.0-android

# Build for Android (Release)
dotnet build -c Release -f net10.0-android

# Run on Android
dotnet build -t:Run -f net10.0-android

# Build APK
dotnet build -c Release -f net10.0-android

# Build AAB
dotnet publish -c Release -f net10.0-android /p:AndroidPackageFormat=bundle
```

### Output Locations

| Build Type | Configuration | Output Location |
|------------|---------------|----------------|
| Debug APK | Debug | `Aven\bin\Debug\net10.0-android\` |
| Release APK | Release | `Aven\bin\Release\net10.0-android\` |
| AAB | Release | `Aven\bin\Release\net10.0-android\publish\` |

---

## Testing Checklist

### Before Building
- [ ] .NET 10.0 SDK installed
- [ ] MAUI workloads installed
- [ ] Visual Studio 2022 opened
- [ ] Solution loaded successfully

### After Building
- [ ] Build completes without errors
- [ ] APK/AAB file created
- [ ] File size is reasonable (< 150MB)

### Testing on Emulator
- [ ] Emulator starts successfully
- [ ] App installs and launches
- [ ] Home screen loads correctly
- [ ] All navigation works
- [ ] All exercises work
- [ ] Data persists between launches
- [ ] Settings work correctly

### Testing on Physical Device
- [ ] Device connected and detected
- [ ] App installs successfully
- [ ] App launches correctly
- [ ] Touch and gestures work
- [ ] Performance is acceptable
- [ ] App doesn't crash
- [ ] Data persists correctly

---

## Performance Testing

### Check App Startup Time
- App should launch within 3 seconds
- Initial screen should load quickly
- No lag on navigation

### Check Memory Usage
- Monitor memory usage in Android Studio's Profiler
- Should stay under 150MB
- No memory leaks

### Check Battery Usage
- App should not drain battery excessively
- Breathing animation should be optimized
- No background processes running

---

## Debugging Tips

### Enable Logging

Add logging to ViewModels to track issues:

```csharp
// In any ViewModel
private void Log(string message)
{
    System.Diagnostics.Debug.WriteLine($"[Aven] {message}");
}

// Example
[RelayCommand]
private async Task NextStepAsync()
{
    Log("NextStep called");
    _currentStep++;
    Log($"Current step: {_currentStep}");
    OnPropertyChanged(nameof(StepTitle));
}
```

View logs in Visual Studio's **Output** window.

### Use Android Studio Logcat

1. Open Android Studio
2. Go to **View** → **Tool Windows** → **Logcat**
3. Filter by "Aven" to see app logs
4. Monitor errors and warnings

---

## Signing the APK for Production

### Current State (Debug Signing)

The app currently uses debug signing, which is fine for testing but not for Play Store.

### For Production (Optional):

1. Generate a keystore:
```bash
keytool -genkey -v -keystore aven-release.keystore -alias aven -keyalg RSA -keysize 2048 -validity 10000
```

2. Update `Aven.csproj` to use the keystore:
```xml
<PropertyGroup Condition="'$(Configuration)|$(TargetFramework)|$(Platform)'=='Release|net10.0-android|AnyCPU'">
  <AndroidKeyStore>True</AndroidKeyStore>
  <AndroidSigningKeyStore>aven-release.keystore</AndroidSigningKeyStore>
  <AndroidSigningStorePass>YOUR_PASSWORD</AndroidSigningStorePass>
  <AndroidSigningKeyAlias>aven</AndroidSigningKeyAlias>
  <AndroidSigningKeyPass>YOUR_PASSWORD</AndroidSigningKeyPass>
</PropertyGroup>
```

3. Build Release APK/AAB with signing

---

## Quick Start Summary

### Fastest Way to Test:

1. Open `Aven.sln` in Visual Studio 2022
2. Select "Android" as platform
3. Select an emulator or connect a device
4. Press **F5**
5. App builds and runs!

### Build APK for Distribution:

```bash
cd Aven
dotnet build -c Release -f net10.0-android
```

APK will be in: `bin\Release\net10.0-android\`

---

## Common Issues and Solutions

### Issue: "No matching function found"

**Solution:** Ensure you're in the `Aven` directory, not the solution directory.

### Issue: "Target framework not installed"

**Solution:** Install MAUI workloads:
```bash
dotnet workload install maui
dotnet workload install android
```

### Issue: "Emulator is slow"

**Solution:**
- Increase emulator RAM in AVD Manager
- Use x86_64 on Windows for better performance
- Close other apps to free up resources

### Issue: "App icon not showing"

**Solution:**
- Rebuild the project
- Clear app data in emulator/device
- Reinstall the app

---

## Final Tips

### For Best Testing Experience:
1. Use a device with Android 10+ for best results
2. Test on both emulator and physical device
3. Test in both portrait and landscape orientations
4. Test with and without internet connection
5. Test all user flows end-to-end

### Performance Optimization:
- Use Release build for performance testing
- Disable animations in device settings to test reduced motion
- Test on lower-end devices to ensure compatibility

### Documentation:
- Refer to `BUILD_AND_DEPLOY_GUIDE.md` for deployment steps
- Refer to `STORE_DEPLOYMENT_CHECKLIST.md` for Play Store requirements
- Refer to `DATABASE_GUIDE.md` for database operations

---

**You're ready to build and test!** Open the solution in Visual Studio and press F5 to get started. 🚀
