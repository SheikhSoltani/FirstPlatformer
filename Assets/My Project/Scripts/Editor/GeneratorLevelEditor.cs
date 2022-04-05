using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(GenerateLevelView))]

public class GeneratorLevelEditor : Editor
{

    private GeneratorLevelController _generateLevelController;

    private void OnEnable()
    {
        var generateLevelView = (GenerateLevelView)target;
        _generateLevelController = new GeneratorLevelController(generateLevelView);
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        var tileMap = serializedObject.FindProperty("_tileMapGround");
        EditorGUILayout.PropertyField(tileMap);

        if (GUI.Button(new Rect(10, 0, 60, 50), "Generate"))
        {
            _generateLevelController.GenerateLevel();
        }

        if (GUI.Button(new Rect(10, 55, 60, 50), "Clear"))
        {
            _generateLevelController.ClearTileMap();
        }

        GUILayout.Space(100);

        serializedObject.ApplyModifiedProperties();
    }

}

