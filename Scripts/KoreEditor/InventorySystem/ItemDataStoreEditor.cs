using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using Kore.InventorySystem;

namespace KoreEditor.InventorySystem
{
    [CustomEditor(typeof(ItemDataStore))]
    public class ItemDataStoreEditor : Editor
    {
        private string newItemName = "New Item";
        private Type newItemType;
        private int typeSelectIndex;

        private List<Type> allTypes = new List<Type>();
        private string[] allTypesName = new string[0];

        private ItemDataStore dataStore
        {
            get { return target as ItemDataStore; }
        }

        private readonly Type itemType = typeof(Item);

        private void OnEnable()
        {
            if (dataStore.data == null)
            {
                dataStore.data = new Item[0];
            }
            allTypes = TypeUtils.GetInstantiatableSubClassOf(itemType);
            allTypesName = allTypes.Select(t => t.Name).ToArray();
        }

        public override void OnInspectorGUI()
        {
            Array.ForEach(dataStore.data, item => DoItemDraw(item));
            DoAddAreaDraw();
        }

        private void DoItemDraw(Item item)
        {
            EditorGUILayout.BeginHorizontal(GUI.skin.box);
            EditorGUI.indentLevel++;

            EditorGUILayout.LabelField(item.name);

            if (GUILayout.Button("-", GUILayout.Width(30f)))
            {
                RemoveItem(item);
            }

            EditorGUI.indentLevel--;
            EditorGUILayout.EndHorizontal();
        }

        private void DoAddAreaDraw()
        {
            EditorGUILayout.Space();
            EditorGUILayout.Space();
            EditorGUILayout.BeginVertical(GUI.skin.box);

            EditorGUILayout.LabelField("New Item", EditorStyles.boldLabel);
            typeSelectIndex = EditorGUILayout.Popup("Type", typeSelectIndex, allTypesName);
            newItemName = EditorGUILayout.TextField("Name", newItemName);

            GUILayout.Space(6f);
            if (GUILayout.Button("Add New Item"))
            {
                var newItem = CreateInstance(allTypes[typeSelectIndex]) as Item;
                newItem.itemName = newItemName;
                newItem.name = newItemName;
                AddItem(newItem);
            }

            EditorGUILayout.EndVertical();
        }

        private void AddItem(Item item)
        {
            ArrayUtility.Add(ref dataStore.data, item);
            AssetDatabase.AddObjectToAsset(item, dataStore);
            AssetDatabase.ImportAsset(AssetDatabase.GetAssetPath(item));
            AssetDatabase.SaveAssets();
            EditorUtility.SetDirty(dataStore);
        }

        private void RemoveItem(Item item)
        {
            ArrayUtility.Remove(ref dataStore.data, item);
            DestroyImmediate(item, true);

            AssetDatabase.SaveAssets();
            EditorUtility.SetDirty(dataStore);
        }
    }
}