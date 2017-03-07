using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Level))]
public class levelInspector : Editor {

    Level _myLevel;

    private int _width;
    private int _height;

    bool _objectToggle = false;

    private SerializedObject _mySerialObject;
    private SerializedProperty _mySerialProperty;

	private void OnEnable()
    {
        _myLevel = (Level)target;
        _mySerialObject = new SerializedObject(_myLevel);
        _mySerialProperty = _mySerialObject.FindProperty("timeAllowed");
        Debug.Log(_mySerialProperty.name);
        GetSizeValues();
    }

    public override void OnInspectorGUI()
    {
        DrawLevelData();
        DrawSizeData();
        DrawGameObjectFields();
        //base.OnInspectorGUI();
    }

    private void DrawLevelData()
    {
        EditorGUILayout.LabelField("Data", EditorStyles.boldLabel);
        EditorGUILayout.BeginVertical("box");
        //_myLevel.timeAllowed = EditorGUILayout.IntField("Time Allowed", Mathf.Max(1, _myLevel.timeAllowed));
        EditorGUILayout.PropertyField(_mySerialProperty);
        _myLevel.gravity = EditorGUILayout.FloatField("Gravity", _myLevel.gravity);
        EditorGUILayout.EndVertical();
    }

    private void DrawSizeData()
    {
        EditorGUILayout.LabelField("Size", EditorStyles.boldLabel);
        EditorGUILayout.BeginVertical("box");

            EditorGUILayout.BeginHorizontal();

                EditorGUILayout.BeginVertical("box");
                    _width = EditorGUILayout.IntField("Width", Mathf.Max(1, _width));
                    _height = EditorGUILayout.IntField("Height", Mathf.Max(1, _height));
                EditorGUILayout.EndVertical();

                EditorGUILayout.BeginVertical();
                    GUI.enabled = (_width != _myLevel.width || _height != _myLevel.height);
                    bool resize = GUILayout.Button("Resize", GUILayout.Height(EditorGUIUtility.singleLineHeight * 2 + 8));
                    if(resize)
                    {
                        HandleDialog();
                    }
                    bool resetButton = GUILayout.Button("Reset");
                    if (resetButton)
                    {
                        GetSizeValues();
                    }
                    GUI.enabled = true;
                EditorGUILayout.EndVertical();

            EditorGUILayout.EndHorizontal();

        EditorGUILayout.EndVertical();
    }

    private void DrawGameObjectFields()
    {
        _objectToggle = EditorGUILayout.Foldout(_objectToggle, "GameObjects");
        if(_objectToggle)
        {
            EditorGUILayout.BeginVertical("box");
            _myLevel.top = (GameObject)EditorGUILayout.ObjectField("Top", _myLevel.top, typeof(GameObject), true);
            _myLevel.bottom = (GameObject)EditorGUILayout.ObjectField("Bottom", _myLevel.bottom, typeof(GameObject), true);
            _myLevel.left = (GameObject)EditorGUILayout.ObjectField("Left", _myLevel.left, typeof(GameObject), true);
            _myLevel.right = (GameObject)EditorGUILayout.ObjectField("Right", _myLevel.right, typeof(GameObject), true);
            EditorGUILayout.EndVertical();
        }
    }

    private void HandleDialog()
    {
        if(EditorUtility.DisplayDialog("Level Resize", "Are you sure that you want to resize? \n This action can not be undone.", "Yes", "No"))
        {
            CallResize();
        }
    }

    private void CallResize()
    {
        _myLevel.width = _width;
        _myLevel.height = _height;
        _myLevel.ResizeLevel();
    }

    private void GetSizeValues()
    {
        _width = _myLevel.width;
        _height = _myLevel.height;
    }
}
