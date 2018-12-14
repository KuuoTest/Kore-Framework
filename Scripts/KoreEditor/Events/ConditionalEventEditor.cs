using UnityEngine;
using UnityEditor;
using Kore.Events;

namespace KoreEditor.Events
{
    [CustomEditor(typeof(ConditionalEvent))]
    public class ConditionalEventEditor : Editor
    {
        private SerializedProperty conditionalActionsProp;

        private readonly string conditionalAtionsPropName = nameof(ConditionalEvent.conditionActions);

        private void OnEnable()
        {
            conditionalActionsProp = serializedObject.FindProperty(conditionalAtionsPropName);
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            EditorGUILayout.Space();

            for (int i = 0; i < conditionalActionsProp.arraySize; i++)
            {
                var prop = conditionalActionsProp.GetArrayElementAtIndex(i);
                DoConditionalActionDraw(prop, i);
            }

            DoAddButtonDraw();
            EditorGUILayout.Space();
            serializedObject.ApplyModifiedProperties();
        }

        private void DoConditionalActionDraw(SerializedProperty prop, int index)
        {
            EditorGUILayout.BeginVertical(GUI.skin.box);
            EditorGUI.indentLevel++;

            if (EditorGUILayout.PropertyField(prop))
            {
                var curProp = prop.Copy();
                if (curProp.NextVisible(true))
                {
                    do
                    {
                        EditorGUILayout.PropertyField(curProp, true);
                    } while (curProp.NextVisible(false));
                }
                GUILayout.Space(6f);
                if (GUILayout.Button("Remove This Entry"))
                {
                    conditionalActionsProp.DeleteArrayElementAtIndex(index);
                }
                GUILayout.Space(6f);
            }
            EditorGUI.indentLevel--;
            EditorGUILayout.EndVertical();
        }

        private void DoAddButtonDraw()
        {
            GUILayout.Space(6f);
            if (GUILayout.Button("Add New Entry", GUILayout.Height(24f)))
            {
                conditionalActionsProp.arraySize++;
                serializedObject.ApplyModifiedProperties();
            }
        }
    }
}