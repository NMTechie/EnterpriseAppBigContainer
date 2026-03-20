- [MAUI Guidence](#maui-guidence)
- [MAUI Implementation](#maui-implementation)
  - [First Install the Workloads](#first-install-the-workloads)
    - [How to install workloads - with specific dotnet SDK version](#how-to-install-workloads---with-specific-dotnet-sdk-version)
    - [Verify the workload installtion](#verify-the-workload-installtion)
  - [Setup the MAUI Projects](#setup-the-maui-projects)
    - [Create a Blank Solution](#create-a-blank-solution)
    - [Create a MAUI Project](#create-a-maui-project)
    - [Add MAUI Project to the Sln](#add-maui-project-to-the-sln)
    - [Install the Andriod SDK](#install-the-andriod-sdk)
    - [Check the build using dotnet CLI](#check-the-build-using-dotnet-cli)
    - [Running the MAUI Application](#running-the-maui-application)


# MAUI Guidence
- What it is: A framework for building native cross-platform desktop and mobile apps (Windows, macOS, Android, iOS) using C# and XAML.
- Key Features:
  - Native UI: Renders native controls on each platform for optimal performance and platform consistency.
  - Single Codebase: Write C#/XAML code once and run on all platforms.
  - Access to Device APIs: Directly access platform features (camera, sensors, file system).
  - App Types: Best for distributable desktop/mobile client apps.
- Best for:
  - Apps that need native performance/resources
  - Apps that should be installed and work offline
  - Applications requiring tight integration with device hardware or OS
  - Output: Native cross-platform EXEs/APKs/IPAs.

# MAUI Implementation

## First Install the Workloads
The .NET MAUI workload does depend on the .NET version.
The MAUI workload is version‑specific, meaning each .NET SDK version has its own compatible MAUI workload packs.

This is confirmed in the [official MAUI CLI documentation](https://mauiman.dev/maui_cli_commandlineinterface.html), where the steps explicitly require installing the workload for the active SDK version. The CLI example shows workload installation being done after installing a specific .NET SDK version, indicating the dependency between the installed SDK and workload.

### How to install workloads - with specific dotnet SDK version
- ✅ Option A — Use global.json to lock the SDK version
  ```pwsh
  # create a global.json file
  dotnet new globaljson --sdk-version 10.0.100
  # Then install the workload
  dotnet workload install maui ## (It only install maui support for windows)
  #for Android and iOS
  dotnet workload install android
  dotnet workload install ios
  ```
- ✅ Use environment PATH to pin to a specific SDK
  ```pwsh
  # If multiple SDK is installed then go to the required dotnet version folder path and run the command
  <path-to-dotnet-version>/ dotnet workload install maui
  ```
- ✅ Option C — Use a specific SDK directory directly
  ```pwsh
  "C:\Program Files\dotnet\10.0.100\dotnet.exe" workload install maui
  ```

  > Note : The install requires the admin rights to carry ahead the installation 

### Verify the workload installtion
```pwsh
dotnet workload list
This command validates which workloads are installed under the currently active SDK.
```

## Setup the MAUI Projects 

### Create a Blank Solution
```pwsh
dotnet new sln -n IMEventHUBClient -f sln
```

### Create a MAUI Project
```pwsh
dotnet new maui -n EventHubClient.UI -lang C# --framework net10.0 --sample-content true
```

### Add MAUI Project to the Sln
```pwsh
dotnet sln IM-EventHUB-Client.sln add .\EventHubClient.UI\EventHubClient.UI.csproj
```

### Install the Andriod SDK 
If you haven’t installed it, download and install via Android Studio:
https://developer.android.com/studio

When done, the SDK path will typically be (on Windows):
> C:\Users\<yourname>\AppData\Local\Android\Sdk

### Check the build using dotnet CLI
```pwsh
dotnet build -t:InstallAndroidDependencies -f:net10.0-android -p:AcceptAndroidSDKLicenses=True
```

### Running the MAUI Application
1. Running for Windows desktop App : 
   > m.m.m.m.m.m
2. Running for Android App : 
   > Need to ensure that a virtual device enulator is running. For that use Android studio. Then run 
   ```pwsh
   dotnet build -t:Run -f net10.0-android
   ```
   > Could not be possible Run and Debug in VS code through launch.json however VS2026 gives much integrated seamless debugging experience 