using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

//The below code Exports the UNITY project to a iOS project.
class ExportTool
{
    static void ExportXcodeProject () 
    {
//#pragma warning disable CS0618 // Type or member is obsolete
        EditorUserBuildSettings.SwitchActiveBuildTarget (BuildTarget.iOS);
//#pragma warning restore CS0618 // Type or member is obsolete

        EditorUserBuildSettings.symlinkLibraries = false;
        EditorUserBuildSettings.development = false;
        EditorUserBuildSettings.allowDebugging = true;

        List<string> scenes = new List<string>();
        for (int i = 0; i < EditorBuildSettings.scenes.Length; i++) 
        {
            if (EditorBuildSettings.scenes [i].enabled)
            {
                scenes.Add (EditorBuildSettings.scenes [i].path);
            }
        }

        BuildPipeline.BuildPlayer (scenes.ToArray (), "Platforms/iOS", BuildTarget.iOS, BuildOptions.None);
    }
}
