using System.Linq;
using UnityEngine;
using UnityEditor;
using UnityEditorInternal;
using Kore.Stats;

namespace KoreEditor.Stats
{
    [CustomEditor(typeof(CharacterStatsConfig))]
    public class CharacterStatsConfigEditor : Editor
    {
        private SerializedProperty statConfigsProp;
        private ReorderableList reorderableList;
        private StatTypeList typeList;

        private CharacterStatsConfig config => target as CharacterStatsConfig;

        private readonly string statConfigsPropName = nameof(CharacterStatsConfig.statConfigs);
        private readonly string statConfigTypePropName = nameof(StatConfig.type);
        private readonly string statConfigValuePropName = nameof(StatConfig.value);

        private const float margin = 6f;
        private const float spaceWidth = 12f;
        private const float singleLineHeight = 16f;
        private const float valueFieldWidth = 60f;

        private void OnEnable()
        {
            statConfigsProp = serializedObject.FindProperty(statConfigsPropName);

            reorderableList = new ReorderableList(serializedObject, statConfigsProp, true, true, true, true)
            {
                drawHeaderCallback = DrawHeaderCallback,
                drawElementCallback = DrawElementCallback
            };
        }

        private void DrawHeaderCallback(Rect headerRect)
        {
            var rect = new Rect
            {
                x = headerRect.x + spaceWidth,
                y = headerRect.y,
                height = headerRect.height,
                width = headerRect.width - valueFieldWidth - spaceWidth
            };
            GUI.Label(rect, "Stat Type");
            rect.x += rect.width;
            rect.width = valueFieldWidth + spaceWidth;
            GUI.Label(rect, "Value");
        }

        private void DrawElementCallback(Rect eRect, int index, bool isActive, bool isFocused)
        {
            var element = statConfigsProp.GetArrayElementAtIndex(index);
            var typeProp = element.FindPropertyRelative(statConfigTypePropName);
            var valueProp = element.FindPropertyRelative(statConfigValuePropName);

            eRect.y += 2;
            var rect = new Rect(eRect.x, eRect.y, eRect.width - valueFieldWidth - margin, singleLineHeight);
            EditorGUI.PropertyField(rect, typeProp, GUIContent.none);
            rect.x += rect.width + margin;
            rect.width = valueFieldWidth;
            EditorGUI.PropertyField(rect, valueProp, GUIContent.none);
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            reorderableList.DoLayoutList();
            DoGenerateArea();
            serializedObject.ApplyModifiedProperties();
        }

        private void DoGenerateArea()
        {
            EditorGUILayout.Space();
            EditorGUILayout.Space();

            EditorGUILayout.BeginVertical(GUI.skin.box);
            EditorGUILayout.LabelField("Generate stats", EditorStyles.boldLabel);

            typeList = EditorGUILayout.ObjectField("Type List", typeList, typeof(StatTypeList), false) as StatTypeList;

            GUILayout.Space(6f);
            if (GUILayout.Button("Generate"))
            {
                if (typeList != null)
                {
                    GenerateStat();
                    return;
                }
                EditorUtility.DisplayDialog("Error", "The Type List cannot be null", "OK");
            }
            EditorGUILayout.EndVertical();
        }

        private void GenerateStat()
        {
            config.statConfigs.AddRange(typeList.data.Select(t => new StatConfig { type = t }));
            serializedObject.ApplyModifiedProperties();
        }
    }
}