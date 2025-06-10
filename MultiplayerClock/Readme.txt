How to deploy the project to Android:
 - open a terminal in the project directory and run the following command:
 - dotnet publish -c Release -r android-arm64 -p:PackageFormat=Apk -f net8.0-android --sc true
 - this will create an APK file in the bin/Release/net8.0-android/android-arm64/publish directory
 - copy the APK file to your Android device
 - install the APK file on your Android device
 // Note: Make sure you have the Android SDK and .NET MAUI installed on your machine.

