# Sample Mobile App (.NET MAUI)

A simple to-do app: add tasks, tick them off, delete them. It uses MVVM with CommunityToolkit.Mvvm.

## Prerequisites (need admin / IT)

- .NET SDK 10 (already installed)
- MAUI workload: `dotnet workload install maui` (run as administrator)
- Microsoft OpenJDK 17
- Android SDK + emulator (Visual Studio installs these, or see below)

## Build and run

```powershell
cd E:\AurSil\SampleMobileApp

# one-time: download the Android SDK and accept its licenses
dotnet build -t:InstallAndroidDependencies -f net10.0-android "-p:AndroidSdkDirectory=$env:LOCALAPPDATA\Android\Sdk" "-p:AcceptAndroidSDKLicenses=True"

# run on Android (emulator or USB-connected phone)
dotnet build -t:Run -f net10.0-android

# run as a Windows desktop app
dotnet build -t:Run -f net10.0-windows10.0.19041.0
```

iOS builds require a Mac.

## Layout

- `Models/TodoItem.cs` is the data for one task.
- `ViewModels/MainViewModel.cs` holds the list and the Add/Delete commands.
- `Views/MainPage.xaml` is the UI.
- `MauiProgram.cs` handles app startup and dependency injection.
- `Platforms/` has the Android, iOS and Windows entry points.
