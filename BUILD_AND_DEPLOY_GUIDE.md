# Aven App - Complete Build, Run, and Deployment Guide

## Table of Contents
1. [Environment Setup](#environment-setup)
2. [Building and Running Locally](#building-and-running-locally)
3. [Android Deployment (Google Play Store)](#android-deployment-google-play-store)
4. [iOS Deployment (Apple App Store)](#ios-deployment-apple-app-store)
5. [Troubleshooting](#troubleshooting)

---

## Environment Setup

### Prerequisites
- ✅ .NET 10.0 SDK (already installed)
- ✅ MAUI Workloads (already installed)
- ✅ Visual Studio 2022 Community (already installed)

### Required Additional Tools

#### For Android Development
1. **Android Studio** (recommended for emulator management)
   - Download: https://developer.android.com/studio
   - Install Android SDK and emulator

2. **Physical Device Testing** (optional)
   - Enable USB Debugging on your Android device
   - Install device drivers

#### For iOS Development (Mac only)
1. **Xcode 14+** (required for iOS builds)
   - Install from Mac App Store
   - Command Line Tools must be installed

2. **Apple Developer Account** ($99/year)
   - Required for App Store deployment
   - Required for device testing

---

## Building and Running Locally

### Option 1: Using Visual Studio 2022 (Recommended)

#### Step 1: Open the Solution
1. Navigate to: `C:\Users\DivakarSakthivel\Documents\Aven\Aven_Mobile_Application`
2. Double-click `Aven.sproj` or `Aven.sln`
3. Visual Studio 2022 will open the solution

#### Step 2: Select Target Platform
In the Visual Studio toolbar, you'll see platform options:
- **Android** - For Android Emulator or device
- **Windows Machine** - For Windows desktop
- **iOS Simulator** - Only available on Mac

#### Step 3: Choose Device
**For Android:**
- Click the device dropdown
- Select an Android Emulator (e.g., Pixel 5 - API 33)
- Or connect a physical device via USB

**For Windows:**
- Select "Windows Machine" from the dropdown

#### Step 4: Build and Run
- Press **F5** or click the **Green Play button**
- The app will build and deploy to the selected device
- First build may take 2-5 minutes

#### Step 5: Test the App
Once running, test all features:
- Home screen navigation
- Help Me Reset flow
- Situations selection
- All 5 exercises
- Favorites and Progress
- Settings

### Option 2: Using Command Line

#### Build for Android
```bash
cd C:\Users\DivakarSakthivel\Documents\Aven\Aven_Mobile_Application\Aven
dotnet build -f net10.0-android
```

#### Run on Android Emulator
```bash
dotnet build -t:Run -f net10.0-android
```

#### Build for Windows
```bash
dotnet build -f net10.0-windows10.0.19041.0
```

#### Run on Windows
```bash
dotnet build -t:Run -f net10.0-windows10.0.19041.0
```

---

## Android Deployment (Google Play Store)

### Phase 1: Google Play Console Setup

#### Step 1: Create Google Play Console Account
1. Go to: https://play.google.com/console
2. Sign in with your Google account
3. Pay the one-time registration fee ($25)
4. Complete developer profile setup

#### Step 2: Create App Listing
1. Click "Create App"
2. Fill in app details:
   - **App name**: Aven
   - **App language**: English
   - **Free or Paid**: Free
3. Click "Create App"

### Phase 2: Prepare the App Bundle

#### Step 1: Update App Configuration
Edit `Aven/Aven.csproj`:
```xml
<ApplicationId>com.yourcompany.aven</ApplicationId>  <!-- Change to your unique ID -->
<ApplicationDisplayVersion>1.0.0</ApplicationDisplayVersion>
<ApplicationVersion>1</ApplicationVersion>
```

#### Step 2: Create Release Build
```bash
cd Aven
dotnet publish -c Release -f net10.0-android /p:AndroidPackageFormat=apk
```

This creates:
- APK file in: `bin\Release\net10.0-android\publish\`
- Or use Android Bundle (.aab) for Play Store:
```bash
dotnet publish -c Release -f net10.0-android /p:AndroidPackageFormat=bundle
```

#### Step 3: Sign the APK/AAB
**For testing (debug signing):**
- Use the default debug keystore

**For production (release signing):**
1. Generate a keystore:
```bash
keytool -genkey -v -keystore aven-release.keystore -alias aven -keyalg RSA -keysize 2048 -validity 10000
```

2. Update `Aven/Platforms/Android/AndroidManifest.xml` if needed

3. Configure signing in `Aven.csproj`:
```xml
<PropertyGroup Condition="'$(Configuration)|$(TargetFramework)|$(Platform)'=='Release|net10.0-android|AnyCPU'">
  <AndroidKeyStore>True</AndroidKeyStore>
  <AndroidSigningKeyStore>aven-release.keystore</AndroidSigningKeyStore>
  <AndroidSigningStorePass>YOUR_PASSWORD</AndroidSigningStorePass>
  <AndroidSigningKeyAlias>aven</AndroidSigningKeyAlias>
  <AndroidSigningKeyPass>YOUR_PASSWORD</AndroidSigningKeyPass>
</PropertyGroup>
```

### Phase 3: Upload to Play Console

#### Step 1: Complete Store Listing
In Google Play Console, fill in:
- **App information**:
  - Short description (80 chars max)
  - Full description (4000 chars max)
- **Store listing**:
  - App icon (512x512px PNG)
  - Feature graphic (1024x500px)
  - Screenshots (at least 2, max 8)
    - Phone screenshots required
    - Tablet screenshots recommended
- **Content rating**:
  - Complete content rating questionnaire
  - Select "Health & Fitness" category
- **Privacy policy**:
  - Provide a URL to your privacy policy
  - Or use a free service like TermsFeed

#### Step 2: Upload App Bundle
1. Go to "Release" → "Production" or "Testing"
2. Click "Create new release"
3. Upload your .aab file
4. Add release notes

#### Step 3: Review and Submit
1. Complete all required fields
2. Review store listing
3. Click "Submit for review"
4. Wait for approval (typically 1-3 days)

### Phase 4: Testing Before Release

#### Internal Testing
1. Create internal test track
2. Upload APK/AAB
3. Add tester email addresses
4. Testers install via opt-in URL

#### Closed Testing (Beta)
1. Create closed testing track
2. Upload APK/AAB
3. Add up to 100 testers
4. Get feedback before public release

#### Open Testing (Alpha)
1. Create open testing track
2. Upload APK/AAB
3. Make available to any Google account
4. Wider testing audience

---

## iOS Deployment (Apple App Store)

**⚠️ IMPORTANT**: iOS builds require macOS. You cannot build iOS apps on Windows.

### Phase 1: Apple Developer Setup

#### Step 1: Enroll in Apple Developer Program
1. Go to: https://developer.apple.com/programs/
2. Choose "Enroll" → "Individual" or "Organization"
3. Pay annual fee ($99)
4. Complete enrollment process

#### Step 2: Configure Development Team
1. Open Xcode
2. Go to Xcode → Preferences → Accounts
3. Add your Apple ID
4. Select your development team

### Phase 2: Prepare the iOS App

#### Step 1: Configure App ID
1. Go to: https://developer.apple.com/account
2. Navigate to "Identifiers" → "App IDs"
3. Click "+" to create new App ID
4. Select "App IDs" → "App"
5. Enter:
   - **Description**: Aven
   - **Bundle ID**: com.yourcompany.aven (must be unique)
6. Select capabilities (none needed for this app)
7. Click "Continue" → "Register"

#### Step 2: Create Provisioning Profile
1. In Developer Portal, go to "Profiles"
2. Click "+" → "iOS App Development"
3. Select your App ID
4. Select your development team
5. Select your development certificate
6. Select your test devices
7. Name the profile and generate
8. Download and install in Xcode

#### Step 3: Configure Project for iOS
Update `Aven/Platforms/iOS/Info.plist`:
```xml
<key>CFBundleIdentifier</key>
<string>com.yourcompany.aven</string>
<key>CFBundleDisplayName</key>
<string>Aven</string>
<key>CFBundleVersion</key>
<string>1</string>
<key>CFBundleShortVersionString</key>
<string>1.0.0</string>
```

### Phase 3: Build for iOS

#### Step 1: Open in Visual Studio for Mac
1. Copy the project to a Mac
2. Open `Aven.sln` in Visual Studio for Mac
3. Select "iOS Simulator" or "iOS Device" as target

#### Step 2: Build and Test
1. Press ⌘+B to build
2. Press ⌘+Enter to run on simulator
3. Test all features

#### Step 3: Create Archive for App Store
1. Select "iOS Device" as target
2. Go to Build → Archive
3. Xcode will create an archive
4. Archive organizer will open

#### Step 4: Validate and Upload
1. In Archive Organizer, click "Validate App"
2. Fix any validation errors
3. Click "Distribute App"
4. Select "App Store Connect"
5. Upload the archive

### Phase 4: App Store Connect Setup

#### Step 1: Create App in App Store Connect
1. Go to: https://appstoreconnect.apple.com
2. Sign in with your developer account
3. Click "My Apps" → "+"
4. Create new app:
   - **Platform**: iOS
   - **Name**: Aven
   - **Bundle ID**: com.yourcompany.aven
   - **SKU**: AVEN001
5. Click "Create"

#### Step 2: Complete App Information
Fill in all required fields:
- **App Information**:
  - Name, Bundle ID, SKU
  - Privacy Policy URL
  - Website URL
- **Pricing and Availability**:
  - Price (Free)
  - Availability date
  - Territories (All)

#### Step 3: Upload Build
1. Go to "TestFlight" → "Internal Testing"
2. Click "+" to add build
3. Select the uploaded archive
4. Add internal testers
5. Test thoroughly

#### Step 4: Prepare for App Store Review
1. Go to "App Store" tab
2. Fill in:
  - **App Information**: Category (Health & Fitness), Age Rating (4+)
  - **Privacy**: Complete App Privacy Details
  - **App Privacy Details**: No data collection
  - **Pricing and Availability**: Free in all territories
  - **1.0 Prepare for Submission**:
    - Screenshots (required for each device size)
    - App icon (1024x1024px)
    - Promotional text (170 chars)
    - Description (4000 chars)
    - Keywords (100 chars)
    - Support URL
    - Marketing URL (optional)

#### Step 5: Submit for Review
1. Click "Add for Review"
2. Review all information
3. Click "Submit"
4. Wait for approval (typically 1-2 days)

---

## Troubleshooting

### Common Build Issues

#### Issue: "The workload 'maui' is not installed"
**Solution:**
```bash
dotnet workload install maui
dotnet workload install android
dotnet workload install maui-windows
```

#### Issue: Android emulator not starting
**Solution:**
1. Open Android Studio
2. Go to Tools → AVD Manager
3. Create a new virtual device
4. Start the emulator
5. Return to Visual Studio

#### Issue: iOS build fails on Windows
**Solution:**
- iOS builds require macOS
- Use Visual Studio for Mac on a Mac
- Or use a cloud Mac service (MacStadium, AWS)

#### Issue: Signing errors on Android
**Solution:**
1. Check if keystore file exists
2. Verify keystore password
3. Use debug keystore for testing:
```bash
dotnet build -f net10.0-android
```

#### Issue: App crashes on startup
**Solution:**
1. Check for null reference exceptions
2. Verify SQLite database initialization
3. Check navigation parameters
4. Enable debug logging

### Store Submission Issues

#### Issue: Google Play rejects due to permissions
**Solution:**
- Our app uses minimal permissions (only internet for MAUI)
- Remove any unnecessary permissions from AndroidManifest.xml
- Document why each permission is needed

#### Issue: App Store rejects due to guidelines
**Solution:**
- Ensure app follows Human Interface Guidelines
- Verify app is not a medical device (properly disclosed)
- Test on real devices (not just simulator)
- Ensure accessibility features work

#### Issue: Privacy policy required
**Solution:**
- Create a simple privacy policy using TermsFeed or similar
- Host on your website or GitHub Pages
- Update store listing with URL

---

## Quick Reference Commands

### Build Commands
```bash
# Build for Android
cd Aven
dotnet build -f net10.0-android

# Build for Windows
dotnet build -f net10.0-windows10.0.19041.0

# Build for iOS (Mac only)
dotnet build -f net10.0-ios

# Run on Android
dotnet build -t:Run -f net10.0-android

# Run on Windows
dotnet build -t:Run -f net10.0-windows10.0.19041.0

# Run tests
cd Aven.Tests
dotnet test
```

### Deployment Commands
```bash
# Create Android APK
dotnet publish -c Release -f net10.0-android /p:AndroidPackageFormat=apk

# Create Android Bundle (AAB)
dotnet publish -c Release -f net10.0-android /p:AndroidPackageFormat=bundle

# Create iOS Archive (via Xcode, not command line)
```

---

## Important Notes

### Android Deployment
- **Minimum SDK**: API 21 (Android 5.0)
- **Target SDK**: API 34 (Android 14)
- **Cost**: $25 one-time registration fee
- **Review Time**: 1-3 days
- **Update Time**: Minutes to hours

### iOS Deployment
- **Minimum iOS**: 13.0
- **Target iOS**: Latest (iOS 17+)
- **Cost**: $99/year developer program
- **Review Time**: 1-2 days
- **Update Time**: Minutes to hours
- **Requires**: macOS and Xcode

### Both Platforms
- **App is local-first** - no backend required
- **No analytics** - privacy-focused
- **No accounts** - no sign-in required
- **Accessibility features** - WCAG AA compliant
- **Medical disclaimer** - not a medical device

---

## Support Resources

### Official Documentation
- .NET MAUI Docs: https://learn.microsoft.com/dotnet/maui
- Google Play Console: https://support.google.com/googleplay/android-developer
- App Store Connect: https://help.apple.com/app-store-connect/

### Community Support
- .NET MAUI Discord: https://discord.gg/dotnet
- Stack Overflow: Tag with `dotnet-maui`
- GitHub Issues: https://github.com/dotnet/maui/issues

---

## Checklist Before Deployment

### Android
- [ ] Test on at least 3 different Android devices
- [ ] Test on Android 5.0, 10, and 14
- [ ] Verify all permissions are necessary
- [ ] Complete privacy policy
- [ ] Prepare app icon and screenshots
- [ ] Test with reduced motion enabled
- [ ] Test with screen reader (TalkBack)
- [ ] Verify no crashes or major bugs

### iOS
- [ ] Test on iPhone 8 (iOS 13) and iPhone 14 (iOS 17)
- [ ] Test on iPad if supporting tablets
- [ ] Test with VoiceOver enabled
- [ ] Test with Dynamic Type
- [ ] Test with Reduce Motion
- [ ] Verify App Privacy Details are accurate
- [ ] Prepare app icon and screenshots for all device sizes
- [ ] Test on physical device (not just simulator)

---

## Final Notes

This guide covers the complete process from building the app locally to deploying it to both major app stores. The Aven app is designed to be simple, privacy-focused, and easy to maintain. Follow each step carefully, and don't hesitate to test thoroughly before submitting to the stores.

Good luck with your deployment! 🚀
