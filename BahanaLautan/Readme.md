Bahana Lautan Mobile Android 
.NET MAUI v8 

Requirement:
-> Windows 10 Upgrade or more 
-> .NET v8
-> Android SDK (for ADB Interface)
-> Visual Studio 2022
-> Memu Player Emulator (for dev)

How open project ?
-> if requirement already , double clicked file sln 
-> Open memu player emulator 
-> If using debug mode : choose for Release or Debug, click play button 
-> please notice for debugging is install app to android as long as test application and 
    if debug is stoped application will be back to last installed.
-> please notice for Release mode install, will be permanently to memu player emulator and will be long waiting time emulator or real device.

How compile application to default folder outputs for apk?
-> click Tools menu, 
-> click Command Line 
-> click PowerShell 
-> please make sure for default project is folder without any file extention sln. 
-> moving to project with this script: cd name_of_project
-> type this script: dotnet publish -c Release -f net8.0-android -o ./output -p:TargetFramework=net8.0-android
-> if any error please make sure for env dotnet is already install. 
-> waiting till folder output is created successfully.
-> you can trying install realesing to emulator after double click apk.
-> or you can trying install to real device.


Developer v0.1
by Nur Chamdani