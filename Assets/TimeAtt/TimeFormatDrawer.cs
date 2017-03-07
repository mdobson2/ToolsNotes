using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomPropertyDrawer(typeof(TimeFormatAttribute))]
public class TimeFormatDrawer : PropertyDrawer
{
    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        return base.GetPropertyHeight(property, label) * 2;
    }

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        if(property.propertyType == SerializedPropertyType.Integer)
        {
            EditorGUIUtility.labelWidth = 8 * label.text.Length;

            Rect drawingRect = position;
            drawingRect.height = drawingRect.height / 2;

            //draw the int field here
            property.intValue = EditorGUI.IntField(drawingRect, label, Mathf.Max(1, property.intValue));
            //draw the hours minutes seconds here
            drawingRect.y += drawingRect.height;
            EditorGUI.LabelField(drawingRect," ", ConvertTime(property.intValue));
        }
        else
        {
            EditorGUI.HelpBox(position, "To use the TimeFormat attribute " + label.text + " must be an int.", MessageType.Error);
        }
        //base.OnGUI(position, property, label);
    }

    private string ConvertTime(int totalSeconds)
    {
        TimeFormatAttribute timeAtt = attribute as TimeFormatAttribute;

        if(timeAtt.DisplayHours)
        {
            int hours = totalSeconds / (60 * 60);
            int minutes = (((totalSeconds % 3600)) / 60);
            int seconds = (totalSeconds % 60);

            return string.Format("{0}:{1}:{2} (h:mm:ss)", hours, minutes.ToString().PadLeft(2,'0'), seconds.ToString().PadLeft(2, '0'));
        }
        else
        {
            int minutes = (totalSeconds / 60);
            int seconds = (totalSeconds % 60);

            return string.Format("{0}:{1} (mm:ss)", minutes.ToString().PadLeft(2, '0'), seconds.ToString().PadLeft(2, '0'));
        }
    }
}
