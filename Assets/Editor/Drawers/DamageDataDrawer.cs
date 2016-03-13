using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomPropertyDrawer(typeof(DamageData))]
public class DamageDataDrawer : PropertyDrawer {
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.BeginProperty(position, label, property);

        // Draw label
        position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);

        // Don't make child fields be indented
        var indent = EditorGUI.indentLevel;
        EditorGUI.indentLevel = 0;

        // Calculate rects
        var typeRect = new Rect(position.x, position.y, 150, position.height);
        var valueRect = new Rect(position.x + 160, position.y, 50, position.height);
        
        // Draw fields - passs GUIContent.none to each so they are drawn without labels
        EditorGUI.PropertyField(typeRect, property.FindPropertyRelative("Type"), GUIContent.none);
        EditorGUI.PropertyField(valueRect, property.FindPropertyRelative("Value"), GUIContent.none);
        
        // Set indent back to what it was
        EditorGUI.indentLevel = indent;

        EditorGUI.EndProperty();
    }

}
