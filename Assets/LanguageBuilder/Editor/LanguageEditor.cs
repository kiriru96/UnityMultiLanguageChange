using UnityEngine;
using UnityEditor;
public class LanguageEditor : EditorWindow {
    [MenuItem("Window/Language Editor")]
    static void openWindow()
    {
        var window = (LanguageEditor)GetWindow(typeof(LanguageEditor));
        window.maxSize = new Vector2(500, 800);
        window.Show();
    }

    void OnGUI()
    {
        GUILayout.Label("Language Editor", EditorStyles.boldLabel);
    }

    void generateLanguage()
    {

    }

    void createEnumScript()
    {

    }

    void createJsonSerialize()
    {
           
    }
}
