using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
public class CustomObjectAttribute : PropertyAttribute {

	public CustomObjectAttribute()
    {

    }
}

[CustomPropertyDrawer(typeof(CustomObjectAttribute))]
public class CustomObjectDrawer : PropertyDrawer
{
    int magicNumber = 4;
    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        return base.GetPropertyHeight(property, label) * magicNumber;
    }

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        //base.OnGUI(position, property, label);
        Rect drawerRect = position;
        drawerRect.height = drawerRect.height / magicNumber;

        EditorGUI.PropertyField(drawerRect, property, label);

        drawerRect.y += drawerRect.height;

        GameObject myGameObj = (GameObject)property.objectReferenceValue;
        if(property.objectReferenceValue != null)
        {
            float myFloat = myGameObj.transform.localScale.x;
            myFloat = EditorGUI.Slider(drawerRect,"Scale: ", myFloat, 1, 10);
            myGameObj.transform.localScale = new Vector3(myFloat, myFloat, myFloat);

            drawerRect.y += drawerRect.height;
            myGameObj.transform.position = EditorGUI.Vector3Field(drawerRect, "Position: ", myGameObj.transform.position);
        }
        
    }
}
