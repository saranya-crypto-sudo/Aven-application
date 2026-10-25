# Database Guide for Aven App

## Overview

The Aven app uses **SQLite** for session history and **MAUI Preferences API** for user settings. All data is stored **locally on the device** - no cloud database required.

---

## 1. Database Location

### Where is the Database File Created?

The database file `aven.db` is automatically created in the app's data directory:

```csharp
var databasePath = Path.Combine(FileSystem.AppDataDirectory, DatabaseName);
```

### Actual File Locations by Platform:

#### Android
```
/data/data/com.companyname.aven/files/aven.db
```
**To view on Android:**
- Use Android Studio's Device File Explorer
- Navigate to: `data/data/com.companyname.aven/files/`
- Pull the file to your computer

#### iOS
```
/var/mobile/Containers/Data/Application/[GUID]/Documents/aven.db
```
**To view on iOS:**
- Use Xcode → Window → Devices and Simulators
- Select your device/app
- Download container
- Navigate to Documents folder

#### Windows
```
C:\Users\[Username]\AppData\Local\Aven\aven.db
```
**To view on Windows:**
- Navigate to: `C:\Users\[Username]\AppData\Local\Aven\`
- Open `aven.db` with any SQLite viewer

---

## 2. Database Schema

### Session Table (SQLite)

| Column | Type | Description |
|--------|------|-------------|
| Id | INTEGER (Primary Key, AutoIncrement) | Unique session ID |
| StartTime | DATETIME | When exercise started |
| EndTime | DATETIME (nullable) | When exercise ended |
| ExerciseType | TEXT | Exercise name (e.g., "Grounding") |
| IsCompleted | INTEGER (0/1) | Was exercise completed? |
| Feedback | TEXT (nullable) | User feedback ("Better", "About the same", "Worse") |
| Reflection | TEXT (nullable) | User's text reflection |
| Situation | TEXT (nullable) | Situation that led to session |

### Example Session Record:
```json
{
  "Id": 1,
  "StartTime": "2026-10-17T10:30:00",
  "EndTime": "2026-10-17T10:35:00",
  "ExerciseType": "Grounding",
  "IsCompleted": true,
  "Feedback": "Better",
  "Reflection": "I feel calmer now",
  "Situation": "test_stress"
}
```

---

## 3. How Data is Saved

### When a Session is Created:

The app saves a session when:
1. User starts an exercise
2. User completes or quits an exercise
3. User provides feedback

**Example from Grounding Exercise:**
```csharp
_currentSession = new Session
{
    StartTime = DateTime.Now,
    ExerciseType = "Grounding",
    IsCompleted = false
};
await _storageService.SaveSessionAsync(_currentSession);
```

**When Completed:**
```csharp
_currentSession.EndTime = DateTime.Now;
_currentSession.IsCompleted = true;
_currentSession.Feedback = "Better";
await _storageService.SaveSessionAsync(_currentSession);
```

---

## 4. How to Fetch Data

### Fetch All Sessions:
```csharp
var sessions = await _storageService.GetSessionsAsync();
// Returns: List<Session> ordered by StartTime (newest first)
```

### Fetch Single Session by ID:
```csharp
var session = await _storageService.GetSessionAsync(sessionId);
// Returns: Session? (nullable)
```

### Fetch User Favorites:
```csharp
var favorites = await _storageService.GetFavoritesAsync();
// Returns: List<string> of exercise type names
```

### Fetch User Preferences:
```csharp
var preferences = await _storageService.GetPreferencesAsync();
// Returns: UserPreferences object
```

---

## 5. Database Operations

### Saving a Session:
```csharp
var session = new Session
{
    StartTime = DateTime.Now,
    ExerciseType = "GentleBreathing",
    IsCompleted = true,
    Feedback = "Better"
};
await _storageService.SaveSessionAsync(session);
```

### Updating a Session:
```csharp
session.EndTime = DateTime.Now;
session.IsCompleted = true;
await _storageService.SaveSessionAsync(session);
// SQLite-net-pcl automatically updates if Id exists
```

### Deleting a Session:
```csharp
await _storageService.DeleteSessionAsync(sessionId);
```

### Deleting All Sessions:
```csharp
await _storageService.DeleteAllSessionsAsync();
```

---

## 6. Where to View Database During Development

### Option 1: Using SQLite Browser (Recommended)

**For Windows:**
1. Download **DB Browser for SQLite**: https://sqlitebrowser.org/
2. Navigate to the database file location
3. Open `aven.db`
4. Browse data, run queries, export data

**For Android Development:**
1. Run the app in Android Emulator
2. Open Android Studio
3. Go to: View → Tool Windows → Device File Explorer
4. Navigate to: `data/data/com.companyname.aven/files/`
5. Right-click `aven.db` → Save As
6. Open with DB Browser for SQLite

**For iOS Development (Mac):**
1. Run the app in iOS Simulator
2. Open Xcode
3. Go to: Window → Devices and Simulators
4. Select your app
5. Click "Gear" icon → Download Container
6. Extract the `.xcappdata` file
7. Navigate to: `Documents/aven.db`
8. Open with DB Browser for SQLite

### Option 2: Using Visual Studio Debugger

Add breakpoints in `StorageService.cs`:
```csharp
public async Task<List<Session>> GetSessionsAsync()
{
    await InitializeAsync();
    var sessions = await _database!.Table<Session>()
        .OrderByDescending(s => s.StartTime)
        .ToListAsync();
    
    // Set breakpoint here to inspect sessions
    return sessions;
}
```

### Option 3: Add Logging to View Data

Add this to any ViewModel to log data:
```csharp
public async Task LoadSessionsAsync()
{
    var sessions = await _storageService.GetSessionsAsync();
    
    foreach (var session in sessions)
    {
        System.Diagnostics.Debug.WriteLine($"Session: {session.ExerciseType}, Completed: {session.IsCompleted}");
    }
}
```

View output in Visual Studio's Output window.

---

## 7. Database Initialization

The database is initialized automatically when first accessed:

```csharp
public async Task InitializeAsync()
{
    if (_database != null)
        return; // Already initialized
    
    var databasePath = Path.Combine(FileSystem.AppDataDirectory, DatabaseName);
    _database = new SQLiteAsyncConnection(databasePath);
    
    // Creates the Session table if it doesn't exist
    await _database.CreateTableAsync<Session>();
}
```

**This is called automatically** whenever you use any storage method.

---

## 8. User Preferences (Not in SQLite)

User preferences are stored using MAUI's **Preferences API**, not SQLite:

### Location:
- **Android**: Shared Preferences
- **iOS**: UserDefaults
- **Windows**: Registry

### Why Preferences API?
- Simple key-value storage
- Perfect for app settings
- No database overhead
- Platform-native storage

### Preferences Stored:
```json
{
  "user_preferences": {
    "FavoriteExerciseTypes": ["Grounding", "GentleBreathing"],
    "FocusSessionDurationMinutes": 25,
    "EnableAnimations": true,
    "EnableReducedMotion": false
  }
}
```

---

## 9. Adding New Database Fields

If you need to add new fields to the Session table:

### Step 1: Update the Model
```csharp
public class Session
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    
    public DateTime StartTime { get; set; }
    
    // Add new field
    public string? MoodBefore { get; set; }
}
```

### Step 2: Update All Session Creations
```csharp
_currentSession = new Session
{
    StartTime = DateTime.Now,
    ExerciseType = "Grounding",
    IsCompleted = false,
    MoodBefore = "Anxious" // New field
};
```

### Step 3: Handle Existing Data
SQLite-net-pcl will automatically add the new column when the table is created. For existing databases, you may need to:
- Delete the app and reinstall, OR
- Add migration logic

---

## 10. Querying the Database

### Using LINQ:

```csharp
// Get all completed sessions
var completedSessions = await _database.Table<Session>()
    .Where(s => s.IsCompleted == true)
    .ToListAsync();

// Get sessions from last 7 days
var recentSessions = await _database.Table<Session>()
    .Where(s => s.StartTime >= DateTime.Now.AddDays(-7))
    .ToListAsync();

// Get count of sessions by exercise type
var groundingCount = await _database.Table<Session>()
    .CountAsync(s => s.ExerciseType == "Grounding");
```

### Using Raw SQL:
```csharp
var sessions = await _database.QueryAsync<Session>(
    "SELECT * FROM Session WHERE IsCompleted = ? ORDER BY StartTime DESC",
    true
);
```

---

## 11. Database Backup and Export

### Export All Sessions to JSON:
```csharp
public async Task<string> ExportSessionsToJsonAsync()
{
    var sessions = await _storageService.GetSessionsAsync();
    var json = System.Text.Json.JsonSerializer.Serialize(sessions, new JsonSerializerOptions
    {
        WriteIndented = true
    });
    return json;
}
```

### Export to CSV:
```csharp
public async Task<string> ExportSessionsToCsvAsync()
{
    var sessions = await _storageService.GetSessionsAsync();
    var csv = "Id,StartTime,EndTime,ExerciseType,IsCompleted,Feedback\n";
    
    foreach (var session in sessions)
    {
        csv += $"{session.Id},{session.StartTime},{session.EndTime}," +
               $"{session.ExerciseType},{session.IsCompleted},{session.Feedback}\n";
    }
    
    return csv;
}
```

---

## 12. Database Reset (Clear All Data)

The app already has a method to delete all data:

```csharp
await _storageService.DeleteAllSessionsAsync();
```

This is called from Settings → "Delete All Data" button.

To completely reset the database (including schema):
1. Uninstall the app from the device
2. Reinstall the app
3. Database will be recreated fresh

---

## 13. Monitoring Database Performance

### Add Timing to Operations:
```csharp
public async Task<int> SaveSessionAsync(Session session)
{
    var stopwatch = System.Diagnostics.Stopwatch.StartNew();
    
    await InitializeAsync();
    var result = await _database!.InsertAsync(session);
    
    stopwatch.Stop();
    System.Diagnostics.Debug.WriteLine($"SaveSession took {stopwatch.ElapsedMilliseconds}ms");
    
    return result;
}
```

---

## 14. Common Database Issues

### Issue: Database Locked
**Cause:** Multiple concurrent operations
**Solution:** SQLite-net-pcl handles this automatically, but ensure you use `await` properly

### Issue: Table Not Found
**Cause:** Database not initialized
**Solution:** Ensure `InitializeAsync()` is called before operations

### Issue: Data Not Persisting
**Cause:** Not awaiting async methods
**Solution:** Always use `await` when calling storage methods

---

## 15. Summary

### What's Stored Where:

| Data Type | Storage | Location |
|-----------|---------|----------|
| Session History | SQLite | Device app data directory |
| User Favorites | Preferences API | Platform-native storage |
| User Settings | Preferences API | Platform-native storage |

### Key Files:
- **StorageService.cs** - Database operations
- **Session.cs** - Session model
- **UserPreferences.cs** - Preferences model

### Quick Reference:
```csharp
// Save
await _storageService.SaveSessionAsync(session);

// Fetch all
var sessions = await _storageService.GetSessionsAsync();

// Delete
await _storageService.DeleteSessionAsync(id);

// Preferences
await _storageService.SavePreferencesAsync(preferences);
var prefs = await _storageService.GetPreferencesAsync();
```

---

## 16. Testing Database Operations

### Unit Tests:
The project includes unit tests in `Aven.Tests/`:
- `SituationMappingServiceTests.cs` - Tests exercise recommendations
- `SessionTests.cs` - Tests session model

### Integration Tests:
Add tests to verify database operations:
```csharp
[Fact]
public async Task SaveAndRetrieveSession()
{
    var service = new StorageService();
    await service.InitializeAsync();
    
    var session = new Session
    {
        StartTime = DateTime.Now,
        ExerciseType = "Grounding",
        IsCompleted = true
    };
    
    var id = await service.SaveSessionAsync(session);
    var retrieved = await service.GetSessionAsync(id);
    
    Assert.NotNull(retrieved);
    Assert.Equal("Grounding", retrieved.ExerciseType);
}
```

---

This guide covers everything you need to know about the database implementation in the Aven app. The database is simple, local-only, and designed for privacy.
