using UnityEditor;
using UnityEngine;
public class TwineEditor : EditorWindow {

    //Path to twine saves
    string twineSource;
    //Path to settings
    //Path to save twine files
    string twineOutput;

    [MenuItem ("Window/TwineEditor")]
    public static void ShowWindow () {
        EditorWindow.GetWindow (typeof (TwineEditor));
    }
    private void OnGUI () {
        GUILayout.Label ("Twine Source", EditorStyles.boldLabel);
        twineSource = EditorGUILayout.TextField ("Twine Source", twineSource);
        if (GUILayout.Button ("Browse")) {
            string newLocation = EditorUtility.OpenFolderPanel ("Browse", "", "");
            if (newLocation != "") {
                twineSource = newLocation;
            }

        }

        GUILayout.Label ("Output", EditorStyles.boldLabel);
        twineOutput = EditorGUILayout.TextField ("Output", twineOutput);
        if (GUILayout.Button ("Browse")) {
            string newLocation = EditorUtility.OpenFolderPanel ("Browse", "", "");
            if (newLocation != "") {
                twineOutput = newLocation;
            }
        }

        if (GUILayout.Button ("Import")) {
            Import ();
        }
    }

    void Import () {
        //AssetDatabase.StopAssetEditing();
        string[] files = System.IO.Directory.GetFiles (twineSource);
        foreach (string file in files) {
            if (file.EndsWith (".html")) {
                string newFile = twineOutput + "/" + System.IO.Path.GetFileNameWithoutExtension (file) + ".twine";
                //Debug.Log (newFile);
                System.IO.File.Copy (file, newFile, true);
            }
        }

        AssetDatabase.Refresh ();
        //AssetDatabase.StartAssetEditing();
    }
}