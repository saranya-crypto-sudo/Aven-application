# APK Build Complete - Testing Instructions

## ✅ Build Status: SUCCESS

**APK Location:** `Aven\bin\Release\net10.0-android\com.companyname.aven-Signed.apk`
**APK Size:** ~32 MB
**Build Time:** ~9 minutes
**Errors:** 0
**Warnings:** 147 (non-critical, mostly binding optimization suggestions)

---

## 📱 How to Test the APK

### Option 1: Test on Android Emulator (Recommended for Quick Testing)

#### Step 1: Start Android Emulator
1. Open Visual Studio 2022
2. Go to **Tools** → **Android** → **Android Device Manager**
3. Select an emulator (e.g., Pixel 5 - API 33)
4. Click **Start**

#### Step 2: Install APK on Emulator
```bash
adb install "C:\Users\DivakarSakthivel\Documents\Aven\Aven_Mobile_Application\Aven\bin\Release\net10.0-android\com.companyname.aven-Signed.apk"
```

Or via Visual Studio:
1. In Visual Studio, select the emulator as target
2. Right-click the Aven project
3. Select **Deploy** (this will install the APK)

#### Step 3: Launch the App
- Find "Aven" in the emulator's app drawer
- Tap to launch
- Test all features

---

### Option 2: Test on Physical Android Device

#### Step 1: Enable USB Debugging on Your Device
1. Go to **Settings** → **About Phone**
2. Tap **Build Number** 7 times to enable Developer Options
3. Go to **Settings** → **System** → **Developer Options**
4. Enable **USB Debugging**

#### Step 2: Connect Device
1. Connect your Android device via USB
2. Allow USB debugging when prompted

#### Step 3: Install APK
```bash
adb install "C:\Users\DivakarSakthivel\Documents\Aven\Aven_Mobile_Application\Aven\bin\Release\net10.0-android\com.companyname.aven-Signed.apk"
```

#### Step 4: Launch and Test
- Find "Aven" in your app drawer
- Tap to launch
- Test all features

---

### Option 3: Sideload APK Without ADB

#### Step 1: Transfer APK to Device
1. Copy the APK file to your phone (via USB, email, cloud storage, etc.)
2. Save it to your Downloads folder

#### Step 2: Enable "Install from Unknown Sources"
1. Go to **Settings** → **Security** (or **Privacy**)
2. Enable **"Install from Unknown Sources"** or **"Allow from this source"**
3. Select your file manager/browser

#### Step 3: Install APK
1. Open your file manager
2. Navigate to Downloads
3. Tap the APK file
4. Tap **Install**
5. Wait for installation to complete

#### Step 4: Launch and Test
- Find "Aven" in your app drawer
- Tap to launch
- Test all features

---

## 🧪 Testing Checklist

### First Launch
- [ ] App installs successfully
- [ ] App launches without crashing
- [ ] Home screen loads
- [ ] Navigation works (tap Help Me Reset, Situations, Favorites, Progress, Settings, Learn)

### Help Me Reset
- [ ] Tap "Help Me Reset" button
- [ ] See Grounding and Gentle Breathing options
- [ ] Tap "Grounding" → exercise opens
- [ ] Tap "Gentle Breathing" → exercise opens

### Situations
- [ ] Navigate to Situations
- [ ] See all 6 situation options
- [ ] Select "Test Stress" → see recommended exercises
- [ ] Tap an exercise → exercise opens
- [ ] Select "Not sure what's bothering me?" → see options

### Exercises

**Grounding:**
- [ ] See "You don't have to solve everything..." message
- [ ] Tap "Next" → see "3 things you can see"
- [ ] Enter something and tap "Next"
- [ ] See "2 things you can feel"
- [ ] Enter something and tap "Next"
- [ ] See "1 thing you can hear"
- [ ] Enter something and tap "Continue"
- [ ] See completion message
- [ ] Test "Quit" button at any point

**Gentle Breathing:**
- [ ] Tap "Start Breathing"
- [ ] See animated breathing circle
- [ ] Circle animates (grows/shrinks)
- [ ] Tap "Stop" → animation stops
- [ ] Tap "Try Grounding" → navigate to Grounding
- [ ] Test "Quit" button

**Balanced Thinking:**
- [ ] Enter stressful thought
- [ ] Tap "Next" → see balanced alternative prompt
- [ ] Enter balanced thought
- [ ] Tap "Complete" → finish exercise
- [ ] Test "Quit" button

**Task Breakdown:**
- [ ] Select difficulty level
- [ ] Enter task description
- [ ] Enter first step
- [ ] Tap "Complete" → finish exercise
- [ ] Test "Quit" button

**Focus on Controllable Actions:**
- [ ] Enter outcome
- [ ] Enter controllable action
- [ ] Tap "Complete" → finish exercise
- [ ] Test "Quit" button

### Favorites
- [ ] Navigate to Favorites
- [ ] See empty state message
- [ ] (Future) Add favorite
- [ ] (Future) Remove favorite

### Progress
- [ ] Navigate to Progress
- [ ] See empty state initially
- [ ] Complete an exercise
- [ ] Return to Progress → see session
- [ ] See session details (type, date, completion status)
- [ ] Delete individual session
- [ ] Test "Delete All History"
- [ ] Confirm deletion

### Settings
- [ ] Navigate to Settings
- [ ] See privacy information
- [ ] Change focus session duration
- [ ] Test "Delete All Data" → confirm dialog
- [ ] Cancel deletion
- [ ] Confirm deletion → data cleared

### Learn
- [ ] Navigate to Learn
- [ ] See video placeholder cards
- [ ] Tap "Watch" → see "Coming soon" message

### General
- [ ] App doesn't crash
- [ ] Navigation is smooth
- [ ] Back button works
- [ ] Screen rotation works (if supported)
- [ ] App works offline
- [ ] Data persists between app launches

---

## 📊 Build Output Files

The following files were created:

| File | Size | Purpose |
|------|------|---------|
| **com.companyname.aven-Signed.apk** | ~32 MB | Debug-signed APK for testing |
| **com.companyname.aven-Signed.aab** | ~31.5 MB | Debug-signed AAB (for Play Store testing) |
| **com.companyname.aven.aab** | ~31.4 MB | Unsigned AAB |

**Note:** These use debug signing. For production, you'll need to create a release keystore and sign the APK/AAB.

---

## 🔧 Common Installation Issues

### Issue: "Install Failed" Error
**Solution:**
- Uninstall any previous version of Aven
- Clear app data: Settings → Apps → Aven → Clear Data
- Try installing again

### Issue: "Package format invalid"
**Solution:**
- Ensure you're using the .apk file, not .aab
- Download the file again if corrupted

### Issue: "Blocked by Play Protect"
**Solution:**
- Tap "Install anyway"
- This is normal for apps not from Play Store

### Issue: "App won't open after install"
**Solution:**
- Check Android version (minimum API 21 / Android 5.0)
- Try restarting the device
- Check for error logs in Android Studio Logcat

---

## 📱 ADB Commands Quick Reference

### Check connected devices
```bash
adb devices
```

### Install APK
```bash
adb install "path\to\com.companyname.aven-Signed.apk"
```

### Reinstall (replace existing)
```bash
adb install -r "path\to\com.companyname.aven-Signed.apk"
```

### Uninstall
```bash
adb uninstall com.companyname.aven
```

### Launch app
```bash
adb shell am start -n com.companyname.aven/.MainActivity
```

### View logs
```bash
adb logcat | grep "Aven"
```

---

## 🎯 Next Steps

### After Testing:
1. **If everything works:**
   - Great! The app is ready for further testing
   - Test on different devices
   - Test on different Android versions

2. **If you find bugs:**
   - Note the issue and reproduction steps
   - Check the logs (adb logcat)
   - Fix the issue in Visual Studio
   - Rebuild and test again

3. **For Play Store submission:**
   - Create a release keystore
   - Sign the APK/AAB with release keystore
   - Update `com.companyname.aven` to your unique package name
   - Follow the guide in `BUILD_AND_DEPLOY_GUIDE.md`

---

## 📝 Summary

✅ **APK built successfully**
✅ **No build errors**
✅ **Ready for testing**
✅ **Location:** `Aven\bin\Release\net10.0-android\com.companyname.aven-Signed.apk`

**You can now:**
1. Install the APK on an Android emulator
2. Install the APK on a physical Android device
3. Test all features
4. Report any issues

**Happy testing!** 🚀
