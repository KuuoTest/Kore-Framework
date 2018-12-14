using System;
using System.Linq;
using UnityEngine;
using UnityEditor;
using Kore.Events;

namespace KoreEditor.Events
{
    [CustomEditor(typeof(MonoBehaviourEventTrigger))]
    public class MonoBehaviourEventTriggerEditor : Editor
    {
        private SerializedProperty delegatesProp;
        private GUIContent iconToolbarMinus;
        private GUIContent eventTypeName;
        private GUIContent[] eventTypes;
        private GUIContent addButtonContent;

        private const float addButtonWidth = 200f;

        private readonly string entryTypePropName = nameof(MonoBehaviourEventTrigger.Entry.type);
        private readonly string entryCallbackPropName = nameof(MonoBehaviourEventTrigger.Entry.callback);

        protected virtual void OnEnable()
        {
            delegatesProp = serializedObject.FindProperty("delegates");

            addButtonContent = new GUIContent("Add New Event Type");
            eventTypeName = new GUIContent("");
            iconToolbarMinus = new GUIContent(EditorGUIUtility.IconContent("Toolbar Minus"))
            {
                tooltip = "Remove this trigger"
            };

            eventTypes = Enum.GetNames(typeof(MonoBehaviourEventTrigger.EventType))
                             .Select(n => new GUIContent(n)).ToArray();
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            EditorGUILayout.Space();
            Vector2 vector = GUIStyle.none.CalcSize(iconToolbarMinus);
            int num = -1;

            for (int i = 0; i < delegatesProp.arraySize; i++)
            {
                var entryProp = delegatesProp.GetArrayElementAtIndex(i);
                var typeProp = entryProp.FindPropertyRelative(entryTypePropName);
                var callbackProp = entryProp.FindPropertyRelative(entryCallbackPropName);

                eventTypeName.text = typeProp.enumDisplayNames[typeProp.enumValueIndex];
                EditorGUILayout.PropertyField(callbackProp, eventTypeName);

                var lastRect = GUILayoutUtility.GetLastRect();
                Rect position = new Rect(lastRect.xMax - vector.x - 8f, lastRect.y + 1f, vector.x, vector.y);
                if (GUI.Button(position, iconToolbarMinus, GUIStyle.none))
                {
                    num = i;
                }
                EditorGUILayout.Space();
            }

            if (num > -1)
            {
                RemoveEntry(num);
            }

            var buttonRect = GUILayoutUtility.GetRect(addButtonContent, GUI.skin.button);
            buttonRect.x += (buttonRect.width - addButtonWidth) / 2f;
            buttonRect.width = addButtonWidth;
            if (GUI.Button(buttonRect, addButtonContent))
            {
                ShowAddTriggerMenu();
            }

            serializedObject.ApplyModifiedProperties();
        }

        private void RemoveEntry(int index)
        {
            delegatesProp.DeleteArrayElementAtIndex(index);
        }

        private void ShowAddTriggerMenu()
        {
            var menu = new GenericMenu();

            for (int i = 0; i < eventTypes.Length; i++)
            {
                bool flag = true;
                for (int j = 0; j < delegatesProp.arraySize; j++)
                {
                    var entryTypeProp = delegatesProp.GetArrayElementAtIndex(j)
                                                .FindPropertyRelative(entryTypePropName);
                    if (entryTypeProp.enumValueIndex == i)
                    {
                        flag = false;
                        break;
                    }
                }

                if (flag)
                {
                    menu.AddItem(eventTypes[i], false,
                                 new GenericMenu.MenuFunction2(OnAddNewSelected), i);
                }
                else
                {
                    menu.AddDisabledItem(eventTypes[i]);
                }
            }

            menu.ShowAsContext();
            Event.current.Use();
        }

        private void OnAddNewSelected(object index)
        {
            delegatesProp.arraySize++;

            delegatesProp.GetArrayElementAtIndex(delegatesProp.arraySize - 1)
                         .FindPropertyRelative(entryTypePropName)
                         .enumValueIndex = (int)index;

            serializedObject.ApplyModifiedProperties();
        }
    }
}