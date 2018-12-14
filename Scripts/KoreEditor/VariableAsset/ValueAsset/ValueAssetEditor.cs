using UnityEditor;
using UnityEngine;
using Kore;
using Kore.Events;

namespace KoreEditor
{
    public abstract class ValueAssetEditor<TValue, TAsset, TGameEvent> : Editor
        where TValue : struct
        where TAsset : ValueAsset<TValue>
        where TGameEvent : GameEvent<TValue>
    {
        private ValueAsset<TValue> asset;

        private void OnEnable()
        {
            asset = target as ValueAsset<TValue>;
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            EditorGUILayout.Space();

            if (asset.OnValueChanged == null)
            {
                NoEventDraw();
            }
            else
            {
                ExistEventDraw();
            }
        }

        private void NoEventDraw()
        {
            if (GUILayout.Button("Create OnValueChange Event"))
            {
                CreateEvent(asset);
            }
        }

        private void ExistEventDraw()
        {
            if (GUILayout.Button("Remove OnValueChange Event"))
            {
                RemoveEvent(asset);
            }
        }

        public static void CreateEvent(ValueAsset<TValue> asset)
        {
            var newEvent = CreateInstance<TGameEvent>();
            newEvent.name = $"On{asset.name}Change";

            Undo.RecordObject(newEvent, $"Created new {typeof(TGameEvent).Name} to {asset.name}");

            AssetDatabase.AddObjectToAsset(newEvent, asset);
            AssetDatabase.ImportAsset(AssetDatabase.GetAssetPath(newEvent));

            asset.OnValueChanged = newEvent;
            AssetDatabase.SaveAssets();
            EditorUtility.SetDirty(asset);
        }

        public static void RemoveEvent(ValueAsset<TValue> asset)
        {
            Undo.RecordObject(asset, $"Remove {typeof(TGameEvent).Name} at {asset.name}");

            DestroyImmediate(asset.OnValueChanged, true);
            asset.OnValueChanged = null;

            AssetDatabase.SaveAssets();
            EditorUtility.SetDirty(asset);
        }
    }
}