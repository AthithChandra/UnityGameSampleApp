# UnityGameSampleApp
Sample C-sharp Unity application.

The Project contains a JENKINSFILE for automating the build process. The different process part of this jenkins file are:
1. Source Code Checkout
2. Generate Xcode project from Unity Project
3. Archiving the iOS Project with Signing Entitlements.
4. Exporting the .xcarchive to IPA file
5. Xcode Tests execution (Currently this project supports only device sdk not simulator sdk)
6. Zipping all the build results right from Logs to the IPA file.
