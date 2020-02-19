timestamps{
    properties([
    parameters([choice(choices: ['Release', 'Debug'], description: 'Choose a Configuration', name: 'CONFIG')])
    ])
node('Parallel Node 1'){
//Intial stage we clone our unity c-sharp project
    stage('Checkout') {
        cleanWs()
        // Checkout files from SCM here.
        sh 'git clone https://github.com/AthithChandra/UnityGameSampleApp.git;cd UnityGameSampleApp;git checkout master'
        print "PROJECT CLONED!!!"

    }

//Extracting Xcode Project from the UNity standard C-sharp application, with the script written under ExportTool.ExportXcodeProject
    stage('Generate Xcode Project') {

        // Generating the Xcode iOS Project from the C-sharp Unity Project
        sh '''
        /Applications/Unity/Unity.app/Contents/MacOS/Unity -batchmode -quit -projectPath $WORKSPACE/UnityGameSampleApp/MyFirstUnityGameCSPROJ -executeMethod ExportTool.ExportXcodeProject -logFile $WORKSPACE/Platforms/iOS/export.log
		'''	   
    }
    
 //THe below stage archives the xcodeproject and generates .xcarchive , this involves signing which is handled through xcconfig files, we it under signing folder.
        stage('Archive iOS Project') {

        // Archiving the Xcode Project i.e; Generating .xcarchive file
        sh '''
        cd $WORKSPACE/UnityGameSampleApp/MyFirstUnityGameCSPROJ/Platforms/iOS
        xcrun xcodebuild -project Unity-iPhone.xcodeproj -scheme Unity-iPhone clean -configuration $CONFIG -sdk iphoneos -xcconfig ../../../SigningFiles/Signing.xcconfig -archivePath ../../../output/Unity-iOS -derivedDataPath ../../../output archive
        '''
    }
    
    //The Below method generates IPA file from the .xcarchive file generated from the above stage
        stage('Exporting to iPA') {

        // Exporting the .xcarchive file to IPA file
        sh '''
        cd $WORKSPACE/UnityGameSampleApp/MyFirstUnityGameCSPROJ/Platforms/iOS
        xcrun xcodebuild -exportArchive -archivePath ../../../output/Unity-iOS.xcarchive -exportOptionsPlist ../../../SigningFiles/SigningExportOptions.plist -exportPath ../../../output/
        '''
    }

    //This can be enabled when we have project supporting iphonesimulator SDK & we can run tests using the below set of commands.
    // stage('Executing Xcode Tests') {

    //     // Running Xcode Tests
    //     sh '''
    //     cd $WORKSPACE/MyFirstUnityGame/MyFirstUnityGameCSPROJ/Platforms/iOS
    //     xcrun xcodebuild -project Unity-iPhone.xcodeproj -scheme Unity-iPhone clean -configuration Debug -sdk iphonesimulator build test -destination 'platform=iOS Simulator,name=iPhone Xʀ' -enableCodeCoverage YES
    //     '''
    // }
    
//This method zips all the relevant artifiacts associated with the project, which can be used further.
    stage('Zipping the artifacts') {

        // Running Xcode Tests
        sh '''
        tar -zcvf Build_Artifacts.tar.gz $WORKSPACE/UnityGameSampleApp/output
        '''
    }

}
}
