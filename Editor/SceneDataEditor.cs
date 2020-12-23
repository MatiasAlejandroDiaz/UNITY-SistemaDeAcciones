using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(SceneData))]
public class SceneDataEditor : Editor
{
    SceneData data;

    //Serializable Propertys
    //Fondos
    SerializedProperty nameFondoSerialized;
    SerializedProperty spriteFondoSerialized;
    //Characters
    SerializedProperty nameCharacterSerialized;
    SerializedProperty prefabCharacterSerialized;
    //Dialogo
    SerializedProperty intIdDialogSerialized;
    SerializedProperty stringDialogSerialized;

    private void OnEnable()
    {
        data = (SceneData)target;

        //set Serializable Property

    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        EditorGUI.BeginChangeCheck();

        EditorGUILayout.BeginVertical("box");

        EditorGUILayout.LabelField("Fondos");

        if (serializedObject.FindProperty("countFondos").intValue > 0)
        {
            for(int i = 0; i < serializedObject.FindProperty("countFondos").intValue; i++)
            {
                EditorGUILayout.BeginVertical("box");
                EditorGUILayout.LabelField("Elemento " + i);
                EditorGUILayout.PropertyField(serializedObject.FindProperty("listaNombresSprites").GetArrayElementAtIndex(i),new GUIContent("Clave","No puede Haber un nombre igual."));
                EditorGUILayout.PropertyField(serializedObject.FindProperty("listaSprites").GetArrayElementAtIndex(i), new GUIContent("Imagen"));
                EditorGUILayout.EndVertical();
            }
        }

        EditorGUILayout.BeginHorizontal("WhiteMiniLabel");
        if (GUILayout.Button("Añadir Nuevo Fondo",GUILayout.ExpandWidth(false)))
        {
            serializedObject.FindProperty("listaNombresSprites").InsertArrayElementAtIndex(serializedObject.FindProperty("listaNombresSprites").arraySize);
            serializedObject.FindProperty("listaSprites").InsertArrayElementAtIndex(serializedObject.FindProperty("listaSprites").arraySize);
            serializedObject.FindProperty("countFondos").intValue++;
        }
        if (GUILayout.Button("Eliminar Ultimo Fondo", GUILayout.ExpandWidth(false)) && serializedObject.FindProperty("countFondos").intValue > 0)
        {
            serializedObject.FindProperty("listaNombresSprites").DeleteArrayElementAtIndex(serializedObject.FindProperty("listaNombresSprites").arraySize - 1);
            serializedObject.FindProperty("listaSprites").DeleteArrayElementAtIndex(serializedObject.FindProperty("listaSprites").arraySize - 1);
            serializedObject.FindProperty("countFondos").intValue--;
        }
        EditorGUILayout.EndHorizontal();


        //Character
        EditorGUILayout.LabelField("Characters");
        if (serializedObject.FindProperty("countCharacters").intValue > 0)
        {
            for (int i = 0; i < serializedObject.FindProperty("countCharacters").intValue; i++)
            {
                EditorGUILayout.BeginVertical("box");
                EditorGUILayout.LabelField("Elemento " + i);
                EditorGUILayout.PropertyField(serializedObject.FindProperty("listaNombresCharacters").GetArrayElementAtIndex(i), new GUIContent("Clave", "No puede Haber un nombre igual."));
                EditorGUILayout.PropertyField(serializedObject.FindProperty("listaCharacters").GetArrayElementAtIndex(i), new GUIContent("Prefab"));
                EditorGUILayout.EndVertical();
            }
        }

        EditorGUILayout.BeginHorizontal("WhiteMiniLabel");
        if (GUILayout.Button("Añadir Nuevo Personaje", GUILayout.ExpandWidth(false)))
        {
            serializedObject.FindProperty("listaNombresCharacters").InsertArrayElementAtIndex(serializedObject.FindProperty("listaNombresCharacters").arraySize);
            serializedObject.FindProperty("listaCharacters").InsertArrayElementAtIndex(serializedObject.FindProperty("listaCharacters").arraySize);
            serializedObject.FindProperty("countCharacters").intValue++;
        }
        if (GUILayout.Button("Eliminar Ultimo Personaje", GUILayout.ExpandWidth(false)) && serializedObject.FindProperty("countFondos").intValue > 0)
        {
            serializedObject.FindProperty("listaNombresCharacters").DeleteArrayElementAtIndex(serializedObject.FindProperty("listaNombresCharacters").arraySize - 1);
            serializedObject.FindProperty("listaCharacters").DeleteArrayElementAtIndex(serializedObject.FindProperty("listaCharacters").arraySize - 1);
            serializedObject.FindProperty("countCharacters").intValue--;
        }
        EditorGUILayout.EndHorizontal();

        //Dialogo
        EditorGUILayout.LabelField("Dialogos");
        if (serializedObject.FindProperty("countDialogos").intValue > 0)
        {
            for (int i = 0; i < serializedObject.FindProperty("countDialogos").intValue; i++)
            {
                EditorGUILayout.BeginVertical("box");
                EditorGUILayout.LabelField("Elemento " + i);
                EditorGUILayout.PropertyField(serializedObject.FindProperty("listaIdDialogos").GetArrayElementAtIndex(i), new GUIContent("Clave", "No puede Haber un nombre igual."));
                EditorGUILayout.PropertyField(serializedObject.FindProperty("listaDialogos").GetArrayElementAtIndex(i), new GUIContent("Dialogo"));
                EditorGUILayout.EndVertical();
            }
        }

        EditorGUILayout.BeginHorizontal("WhiteMiniLabel");
        if (GUILayout.Button("Añadir Nuevo Dialogo", GUILayout.ExpandWidth(false)))
        {
            serializedObject.FindProperty("listaIdDialogos").InsertArrayElementAtIndex(serializedObject.FindProperty("listaIdDialogos").arraySize);
            serializedObject.FindProperty("listaDialogos").InsertArrayElementAtIndex(serializedObject.FindProperty("listaDialogos").arraySize);
            serializedObject.FindProperty("countDialogos").intValue++;
        }
        if (GUILayout.Button("Eliminar Ultimo Dialogo", GUILayout.ExpandWidth(false)) && serializedObject.FindProperty("countFondos").intValue > 0)
        {
            serializedObject.FindProperty("listaIdDialogos").DeleteArrayElementAtIndex(serializedObject.FindProperty("listaIdDialogos").arraySize - 1);
            serializedObject.FindProperty("listaDialogos").DeleteArrayElementAtIndex(serializedObject.FindProperty("listaDialogos").arraySize - 1);
            serializedObject.FindProperty("countDialogos").intValue--;
        }
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.EndVertical();

        if(EditorGUI.EndChangeCheck())
        {
            Undo.RecordObject(target, "Modificar Scene Manager");
            EditorUtility.SetDirty(target);
            AssetDatabase.SaveAssets();            
        }
        serializedObject.ApplyModifiedProperties();
    }
}
