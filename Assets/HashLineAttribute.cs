using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class HashLineAttribute : PropertyAttribute {

    public readonly int spaceSize;
    public HashLineAttribute(int spaceSize)
    {
        this.spaceSize = spaceSize;
    }
}

[CustomPropertyDrawer(typeof(HashLineAttribute))]
public class HashLineDrawer : DecoratorDrawer
{
    HashLineAttribute HashAtt
    {
        get { return ((HashLineAttribute)attribute); }
    }

    public override float GetHeight()
    {
        return base.GetHeight() * HashAtt.spaceSize;
    }

    public override void OnGUI(Rect position)
    {
        GUIStyle centerStyle = GUI.skin.GetStyle("Label");
        centerStyle.alignment = TextAnchor.MiddleCenter;
        EditorGUI.LabelField(position, "##################", centerStyle);
    }
}
