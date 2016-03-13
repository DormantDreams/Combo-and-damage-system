using UnityEngine;
using UnityEditor;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEditorInternal;

[CustomEditor(typeof(BasicStatistics), true)]
[CanEditMultipleObjects]
public class BasicStatisticsEditor : Editor
{
    //private BasicStatistics _target;

    public SerializedProperty HPprop;
    public SerializedProperty maxHPprop;
    public SerializedProperty ATTprop;
    public SerializedProperty DEFprop;
    public SerializedProperty comboRatioProp;

    public SerializedProperty resistanceProp;
    public SerializedProperty dataProp;
    private ReorderableList listUI;
    private bool isListOpen = true;

    private readonly GUIContent plusContent = new GUIContent("+");
    private readonly GUIContent minusContent = new GUIContent("-");
    private static GUILayoutOption miniButtonWidth = GUILayout.Width(20f);
    private static GUILayoutOption fieldSize = GUILayout.Width(150f);

    private void OnEnable()
    {
        HPprop = serializedObject.FindProperty("hp");
        maxHPprop = serializedObject.FindProperty("maxHp");
        ATTprop = serializedObject.FindProperty("ATT");
        DEFprop = serializedObject.FindProperty("DEF");
        comboRatioProp = serializedObject.FindProperty("ComboRatio");

        resistanceProp = serializedObject.FindProperty("DamageResistance");
        dataProp = resistanceProp.FindPropertyRelative("data");
    }

    private void OnDisable()
    {
        //Debug.Log("OnDisable was called...");
    }
    private void OnDestroy()
    {
        //Debug.Log("OnDestroy was called...");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.PrefixLabel("HP / Max HP");
        var hpRect = GUILayoutUtility.GetRect(50, 20, EditorStyles.numberField);
        EditorGUI.DelayedFloatField(hpRect, HPprop, GUIContent.none);
        EditorGUILayout.LabelField("/", EditorStyles.miniLabel, miniButtonWidth);
        hpRect = GUILayoutUtility.GetRect(50, 20, "TextField");
        EditorGUI.DelayedFloatField(hpRect, maxHPprop.floatValue);
        EditorGUILayout.EndHorizontal();
        if (!HPprop.hasMultipleDifferentValues || !maxHPprop.hasMultipleDifferentValues)
            ProgressBar(HPprop.floatValue / maxHPprop.floatValue, "HP");

        RenderFieldWithButtons(ATTprop, "ATT");
        RenderFieldWithButtons(DEFprop, "DEF");

        //EditorGUILayout.PropertyField(dataProp, new GUIContent("Resistance"), true);

        RenderListUI(dataProp, "Resistance");

        serializedObject.ApplyModifiedProperties();
        //EditorGUILayout.LabelField("The HP is" + _target.HP);
        //DrawDefaultInspector();   
    }

    private void RenderListUI(SerializedProperty listProperty, string label)
    {
        GUILayout.BeginHorizontal();
        isListOpen = EditorGUI.Foldout(GUILayoutUtility.GetRect(50, 20), isListOpen, label, true);
        if (isListOpen)
        {
            if (GUILayout.Button(plusContent, EditorStyles.miniButton, miniButtonWidth))
                listProperty.arraySize++;
            GUILayout.EndHorizontal();

            EditorGUI.indentLevel++;
            for (var index = 0; index < listProperty.arraySize; index++)
            {
                GUILayout.BeginHorizontal();
                EditorGUILayout.PropertyField(listProperty.GetArrayElementAtIndex(index), new GUIContent(index.ToString()) ,true);
                if (GUILayout.Button(minusContent, EditorStyles.miniButton, miniButtonWidth))
                    listProperty.DeleteArrayElementAtIndex(index);
                GUILayout.EndHorizontal();
            }
            EditorGUI.indentLevel--;
        }
        else
            GUILayout.EndHorizontal();

    }

    private void RenderFieldWithButtons(SerializedProperty property, string label)
    {
        if (!property.hasMultipleDifferentValues)
        {
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.DelayedFloatField(property, new GUIContent(label));
            if (GUILayout.Button(plusContent, EditorStyles.miniButton, miniButtonWidth))
                ATTprop.floatValue++;
            if (GUILayout.Button(minusContent, EditorStyles.miniButton, miniButtonWidth))
                DEFprop.floatValue--;
            EditorGUILayout.EndHorizontal();
        }
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
