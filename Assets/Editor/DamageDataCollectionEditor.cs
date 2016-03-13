using UnityEngine;
using UnityEditor;

using System.Collections;
using System.Linq;
using UnityEditorInternal;

[CanEditMultipleObjects]
[CustomPropertyDrawer(typeof(DamageDataCollectionAttribute))]
public class DamageDataCollectionEditor : PropertyDrawer
{
    private SerializedProperty listProp;
    private ReorderableList listUI;

    private void OnEnable()
    {
        //listProp = serializedObject.FindProperty("data");
        //listUI = new ReorderableList(serializedObject, listProp, true, true, true, true);
        //listUI.drawHeaderCallback += rect => GUI.Label(rect, new GUIContent("DMG List"));
        //listUI.drawElementCallback += (rect, index, active, focused) =>
        //{
        //    rect.height = 16;
        //    rect.y += 2;
        //    if (index >= listProp.arraySize) return;
        //    EditorGUI.LabelField(rect, GUIContent.none);
        //};
        //Debug.Log(listProp != null ? "Data - OK" : "Data == null");
    }

    private void OnDisable()
    {
        //Debug.Log("OnDisable was called...");
    }

    private void OnDestroy()
    {
        //Debug.Log("OnDestroy was called...");
    }

    public void OnGUI()
    {
        //EditorGUILayout.LabelField("The number " + listProp.arraySize);
        //EditorGUILayout.PropertyField(listProp);
        //listUI.DoLayoutList();       
        //serializedObject.ApplyModifiedProperties();
        //EditorGUILayout.EnumPopup("DamageType", DamageType.Physical);
        //DrawDefaultInspector();
    }

    // Custom GUILayout progress bar.
    void ProgressBar(float value, string label)
    {
        // Get a rect for the progress bar using the same margins as a textfield:
        Rect rect = GUILayoutUtility.GetRect(18, 18, "TextField");
        EditorGUI.ProgressBar(rect, value, label);
        EditorGUILayout.Space();
    }


}

