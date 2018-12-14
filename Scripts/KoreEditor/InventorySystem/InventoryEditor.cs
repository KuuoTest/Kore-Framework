using UnityEngine;
using UnityEditor;
using UnityEditorInternal;
using Kore.InventorySystem;

namespace KoreEditor.InventorySystem
{
    [CustomEditor(typeof(Inventory))]
    public class InventoryEditor : Editor
    {
        private SerializedProperty inventoryItemsProp;

        private ReorderableList reorderableList;
        private GUIContent countLabelContent = new GUIContent("Count");

        private readonly string itemPropName = nameof(Inventory.InventoryItem.item);
        private readonly string countPropName = nameof(Inventory.InventoryItem.count);
        private readonly float singleLineHeight = EditorGUIUtility.singleLineHeight;
        private const float countFieldWidth = 60;

        private void OnEnable()
        {
            inventoryItemsProp = serializedObject.FindProperty(nameof(Inventory.inventoryItems));

            reorderableList = new ReorderableList(
                serializedObject, inventoryItemsProp, true, true, true, true)
            {
                drawHeaderCallback = DrawHeaderCallBack,
                drawElementCallback = DrawElementCallback,
                onAddCallback = OnAddCallback
            };
        }

        private void DrawHeaderCallBack(Rect rect)
        {
            int count = reorderableList.count;
            GUI.Label(rect, $"{count} Item" + (count > 1 ? "s" : ""));

            if (count > 0)
            {
                var countRect = new Rect(rect.x + rect.width - countFieldWidth + 10, rect.y,
                countFieldWidth, singleLineHeight);
                EditorGUI.LabelField(countRect, countLabelContent);
            }
        }

        private void DrawElementCallback(Rect rect, int index, bool isActive, bool isFocused)
        {
            var element = inventoryItemsProp.GetArrayElementAtIndex(index);

            rect.y += 2;
            var itemRect = new Rect(rect.x, rect.y, rect.width - countFieldWidth - 8, singleLineHeight);
            EditorGUI.PropertyField(itemRect, element.FindPropertyRelative(itemPropName), GUIContent.none);

            var countRect = new Rect(rect.x + rect.width - countFieldWidth, rect.y,
                countFieldWidth, singleLineHeight);
            EditorGUI.PropertyField(countRect, element.FindPropertyRelative(countPropName), GUIContent.none);
        }

        private void OnAddCallback(ReorderableList list)
        {
            ReorderableList.defaultBehaviours.DoAddButton(list);
            var prop = list.serializedProperty;
            list.serializedProperty.GetArrayElementAtIndex(prop.arraySize - 1)
                .FindPropertyRelative(countPropName).intValue = 1;
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            EditorGUILayout.Space();
            reorderableList.DoLayoutList();

            serializedObject.ApplyModifiedProperties();
        }
    }
}