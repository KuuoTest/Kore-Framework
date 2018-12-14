using System;
using UnityEditor;
using UnityEngine;
using Kore.Stats;

namespace KoreEditor.Stats
{
    [CustomEditor(typeof(StatTypeList))]
    public class StatTypeListEditor : Editor
    {
        private string newTypeName = "New StatType";
        private StatTypeList Target
        {
            get { return target as StatTypeList; }
        }

        private const float removeButtonWidth = 30f;

        private void OnEnable()
        {
            if (Target.data == null)
            {
                Target.data = new StatType[0];
            }
        }

        public override void OnInspectorGUI()
        {
            Array.ForEach(Target.data, d => DoTypeDraw(d));
            DoAddAreaDraw();
        }

        private void DoTypeDraw(StatType type)
        {
            EditorGUILayout.BeginHorizontal(GUI.skin.box);
            EditorGUI.indentLevel++;

            EditorGUILayout.LabelField(type.typeName);

            if (GUILayout.Button("-", GUILayout.Width(removeButtonWidth)))
            {
                RemoveStatType(type);
            }

            EditorGUI.indentLevel--;
            EditorGUILayout.EndHorizontal();
        }

        private void RemoveStatType(StatType typeToRemove)
        {
            ArrayUtility.Remove(ref Target.data, typeToRemove);
            DestroyImmediate(typeToRemove, true);

            AssetDatabase.SaveAssets();
            EditorUtility.SetDirty(Target);
        }

        private void DoAddAreaDraw()
        {
            EditorGUILayout.Space();
            EditorGUILayout.Space();

            EditorGUILayout.BeginVertical(GUI.skin.box);
            EditorGUILayout.LabelField("New Stat Type", EditorStyles.boldLabel);
            newTypeName = EditorGUILayout.TextField("Name", newTypeName);
            GUILayout.Space(6f);
            if (GUILayout.Button("Add New Type"))
            {
                if (Array.Exists(Target.data, t => t.typeName == newTypeName))
                {
                    EditorUtility.DisplayDialog("Can not add",
                        $"There's already a StatType named {newTypeName}", "OK");
                }
                else
                {
                    AddStatType(newTypeName);
                }
            }
            EditorGUILayout.EndVertical();
        }

        private void AddStatType(string newTypeName)
        {
            var newType = CreateInstance<StatType>();
            newType.name = newTypeName;
            newType.typeName = newTypeName;

            ArrayUtility.Add(ref Target.data, newType);

            AssetDatabase.AddObjectToAsset(newType, Target);
            AssetDatabase.ImportAsset(AssetDatabase.GetAssetPath(newType));
            AssetDatabase.SaveAssets();
            EditorUtility.SetDirty(Target);
        }
    }
}