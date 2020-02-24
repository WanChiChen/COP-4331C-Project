using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor(typeof(Inventory))]
public class PlayerInventoryEditor : Editor
{
    /*private bool[] showItemSlots = new bool[Inventory.initialSlots];
    private SerializedProperty itemImagesProperty;
    private SerializedProperty itemsProperty;
    private const string ItemImagesName = "itemImages";
    private const string ItemsName = "items";

    private void OnEnable()
    {
        itemImagesProperty = serializedObject.FindProperty(ItemImagesName);
        itemsProperty = serializedObject.FindProperty(ItemsName);
    }
    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        for (int i = 0; i < Inventory.initialSlots; i++)
        {
            ItemSlotGUI(i);
        }
        serializedObject.ApplyModifiedProperties();
    }
    private void ItemSlotGUI(int index)
    {
        EditorGUILayout.BeginVertical(GUI.skin.box);
        EditorGUI.indentLevel++;

        showItemSlots[index] = EditorGUILayout.Foldout(showItemSlots[index], "Item slot " + index);

        if (showItemSlots[index])
        {
            EditorGUILayout.PropertyField(itemImagesProperty.GetArrayElementAtIndex(index));
            EditorGUILayout.PropertyField(itemsProperty.GetArrayElementAtIndex(index));
        }
        EditorGUI.indentLevel--;
        EditorGUILayout.EndVertical();
    }*/
}


