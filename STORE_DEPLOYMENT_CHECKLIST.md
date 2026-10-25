# Store Deployment Verification Checklist

## Google Play Store Deployment Checklist

### Pre-Submission Requirements

#### 1. Technical Requirements
- [ ] Minimum SDK: API 21 (Android 5.0) configured
- [ ] Target SDK: Latest stable (API 34+)
- [ ] App bundle (.aab) generated successfully
- [ ] App size under 150MB (Google Play limit)
- [ ] 64-bit architecture support (arm64-v8a)
- [ ] No restricted permissions
- [ ] ProGuard/R8 obfuscation configured (optional)

#### 2. App Content
- [ ] App title: "Aven"
- [ ] Short description (80 chars max)
- [ ] Full description (4000 chars max)
- [ ] Screenshots (at least 2, max 8):
  - [ ] Phone screenshots
  - [ ] 7-inch tablet screenshots (if applicable)
  - [ ] 10-inch tablet screenshots (if applicable)
- [ ] App icon (512x512px)
- [ ] Feature graphic (1024x500px)
- [ ] Privacy policy URL

#### 3. Store Listing
- [ ] Category: Health & Fitness
- [ ] Content rating: Everyone
- [ ] Contact email
- [ ] Privacy policy link
- [ ] Website URL (optional)

#### 4. Privacy & Security
- [ ] No unnecessary permissions requested
- [ ] Data disclosure form completed
- [ ] Privacy policy available
- [ ] No analytics or tracking
- [ ] No third-party SDKs that collect data
- [ ] Local storage only (no cloud sync)

#### 5. Testing
- [ ] Tested on Android 5.0 (API 21)
- [ ] Tested on Android 6.0 (API 23)
- [ ] Tested on Android 7.0 (API 24)
- [ ] Tested on Android 8.0 (API 26)
- [ ] Tested on Android 9.0 (API 28)
- [ ] Tested on Android 10 (API 29)
- [ ] Tested on Android 11 (API 30)
- [ ] Tested on Android 12 (API 31)
- [ ] Tested on Android 13 (API 33)
- [ ] Tested on Android 14 (API 34)
- [ ] Tested on multiple screen sizes
- [ ] Tested on different device manufacturers
- [ ] Accessibility features tested (TalkBack)
- [ ] Reduced motion tested
- [ ] Dynamic text scaling tested

#### 6. Compliance
- [ ] Material Design guidelines followed
- [ ] No system overlays
- [ ] No persistent notifications (none required)
- [ ] No foreground services (none required)
- [ ] No malware or suspicious code
- [ ] No copyright infringement
- [ ] No trademark violations

### Submission Process
1. [ ] Create Google Play Console account
2. [ ] Pay registration fee ($25 one-time)
3. [ ] Create app listing
4. [ ] Upload app bundle (.aab)
5. [ ] Complete content rating questionnaire
6. [ ] Submit for review
7. [ ] Wait for approval (typically 1-3 days)

---

## Apple App Store Deployment Checklist

### Pre-Submission Requirements

#### 1. Technical Requirements
- [ ] Minimum iOS: 13.0 configured
- [ ] Target iOS: Latest stable (iOS 17+)
- [ ] App bundle (.ipa) generated successfully
- [ ] App size under 4GB (App Store limit)
- [ ] 64-bit only (arm64)
- [ ] No restricted APIs
- [ ] Code signed with valid certificate
- [ ] Provisioning profile configured

#### 2. App Content
- [ ] App name: "Aven"
- [ ] Subtitle (30 chars max)
- [ ] Description (4000 chars max)
- [ ] Screenshots (required for each device size):
  - [ ] 6.7" Display (iPhone 14 Pro Max)
  - [ ] 6.5" Display (iPhone 8 Plus)
  - [ ] 5.5" Display (iPhone 8)
  - [ ] iPad Pro (12.9")
  - [ ] iPad Pro (11")
- [ ] App icon (1024x1024px)
- [ ] Privacy policy URL

#### 3. Store Listing
- [ ] Category: Health & Fitness
- [ ] Age rating: 4+ (Made for Ages 9-11)
- [ ] Contact email
- [ ] Support URL
- [ ] Privacy policy URL
- [ ] Marketing URL (optional)

#### 4. Privacy & Security
- [ ] App Privacy Details completed
- [ ] Data types disclosed (if any)
- [ ] Data usage explained
- [ ] No unnecessary permissions
- [ ] No analytics or tracking
- [ ] Local storage only
- [ ] No third-party SDKs that collect data

#### 5. Testing
- [ ] Tested on iPhone 8 (iOS 13)
- [ ] Tested on iPhone 11 (iOS 14)
- [ ] Tested on iPhone 12 (iOS 15)
- [ ] Tested on iPhone 13 (iOS 16)
- [ ] Tested on iPhone 14 (iOS 17)
- [ ] Tested on iPad (iOS 13+)
- [ ] Tested on different screen sizes
- [ ] VoiceOver tested
- [ ] Dynamic Type tested
- [ ] Reduce Motion tested
- [ ] Dark mode tested (if supported)

#### 6. Compliance
- [ ] Human Interface Guidelines followed
- [ ] App Store Review Guidelines followed
- [ ] No prohibited content
- [ ] No trademark violations
- [ ] No copyright infringement
- [ ] No misleading information
- [ ] Not a medical device (properly disclosed)

### Submission Process
1. [ ] Enroll in Apple Developer Program ($99/year)
2. [ ] Create App ID in Developer Portal
3. [ ] Configure signing certificates
4. [ ] Create provisioning profile
5. [ ] Create app listing in App Store Connect
6. [ ] Upload app via Xcode or Transporter
7. [ ] Complete App Privacy Details
8. [ ] Submit for review
9. [ ] Wait for approval (typically 1-2 days)

---

## Common Issues to Avoid

### Android
- ❌ Don't request permissions not needed (microphone, camera, location)
- ❌ Don't use deprecated APIs
- ❌ Don't include hardcoded API keys
- ❌ Don't target SDK below 21
- ❌ Don't violate Material Design guidelines

### iOS
- ❌ Don't claim medical benefits without approval
- ❌ Don't use private APIs
- ❌ Don't violate Human Interface Guidelines
- ❌ Don't include features that don't work
- ❌ Don't use inappropriate content

---

## Post-Deployment Monitoring

### Both Platforms
- [ ] Monitor crash reports
- [ ] Monitor user reviews
- [ ] Monitor performance metrics
- [ ] Respond to user feedback
- [ ] Plan for updates based on feedback

### Android Specific
- [ ] Monitor ANR (Application Not Responding) reports
- [ ] Monitor Play Console vitals
- [ ] Update app regularly

### iOS Specific
- [ ] Monitor App Analytics
- [ ] Monitor crash reports in Xcode
- [ ] Update app regularly
- [ ] Respond to App Store reviews

---

## Notes

- This app is a wellness tool, not a medical device
- No clinical claims are made
- Local-first storage only
- No accounts, analytics, or cloud sync
- Designed to be calm, supportive, and non-judgmental
- Accessibility features are prioritized
- Privacy-first approach with minimal data collection
