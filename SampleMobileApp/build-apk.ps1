# Builds the Android APK using the tools installed in E:\DevTools (no admin needed).
# Usage:  powershell -ExecutionPolicy Bypass -File .\build-apk.ps1

$env:DOTNET_ROOT = 'E:\DevTools\dotnet'
$env:DOTNET_MULTILEVEL_LOOKUP = '0'
$env:JAVA_HOME = 'E:\DevTools\jdk17'
$env:PATH = "E:\DevTools\dotnet;E:\DevTools\jdk17\bin;E:\DevTools\Android\Sdk\platform-tools;$env:PATH"

Set-Location $PSScriptRoot

dotnet publish -f net10.0-android -c Release `
    -p:TargetFrameworks=net10.0-android `
    -p:AndroidPackageFormat=apk `
    -p:AndroidSdkDirectory=E:\DevTools\Android\Sdk `
    -p:JavaSdkDirectory=E:\DevTools\jdk17

$apk = Join-Path $PSScriptRoot 'bin\Release\net10.0-android\publish\com.aursil.samplemobileapp-Signed.apk'
if (Test-Path $apk) {
    Write-Host "`nAPK ready: $apk" -ForegroundColor Green
    # If a phone with USB debugging is connected, install it straight away
    if ((adb devices) -match "`tdevice") {
        adb install -r $apk
    }
}
