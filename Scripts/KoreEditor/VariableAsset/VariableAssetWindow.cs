using Kore;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace KoreEditor
{
    public class VariableAssetWindow : EditorWindow
    {
        public enum AssetType { Value, Reference }

        private class Styles
        {
            public static readonly GUIStyle toolbarStyle = "LargeButton";

            public static readonly GUIContent[] toolbarContent =
            {
                new GUIContent("ValueType"),
                new GUIContent("ReferenceType")
            };
        }

        private string newAssetName;
        private string newAssetTypeName;
        private Type newAssetType;
        private AssetType selectedAssetType = AssetType.Value;

        private void OnGUI()
        {
            GUILayout.Space(20f);
            AssetTypeToggle();
            GUILayout.Space(20f);

            switch (selectedAssetType)
            {
                case AssetType.Value:
                    ValueAssetDraw();
                    break;
                case AssetType.Reference:
                    ReferenceAssetDraw();
                    break;
            }
        }

        private void ValueAssetDraw()
        {
            EditorGUILayout.LabelField("ValueAssetDraw");
        }

        private void ReferenceAssetDraw()
        {
            EditorGUILayout.LabelField("ReferenceAssetDraw");
        }

        private void AssetTypeToggle()
        {
            EditorGUILayout.BeginHorizontal();
            GUILayout.FlexibleSpace();

            selectedAssetType = (AssetType)GUILayout.Toolbar((int)selectedAssetType, 
                Styles.toolbarContent, Styles.toolbarStyle, GUI.ToolbarButtonSize.FitToContents);

            GUILayout.FlexibleSpace();
            EditorGUILayout.EndHorizontal();
        }

        //[MenuItem("Kore/VariableAsset")]
        private static void CreateWindow()
        {
            var window = GetWindow<VariableAssetWindow>();
            window.minSize = new Vector2(300f, 300f);
            window.titleContent = new GUIContent("VariableAsset");
            window.Show();
        }
    }
}