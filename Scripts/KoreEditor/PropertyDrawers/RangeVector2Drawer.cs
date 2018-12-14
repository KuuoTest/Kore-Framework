using UnityEngine;
using UnityEditor;
using Kore;

namespace KoreEditor
{
    [CustomPropertyDrawer(typeof(RangeVector2Attribute))]
    public class RangeVector2Drawer : PropertyDrawer
    {
        private RangeVector2Attribute rangeAttribute;
        private float min = 0f;
        private float max = 0f;

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return 38f;
        }

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            rangeAttribute = attribute as RangeVector2Attribute;
            var propType = property.propertyType;
            if (propType == SerializedPropertyType.Vector2)
            {
                min = property.vector2Value.x;
                max = property.vector2Value.y;
                DoDraw(position, label);
                property.vector2Value = new Vector2(min, max);
            }
            else if (propType == SerializedPropertyType.Vector2Int)
            {
                min = property.vector2IntValue.x;
                max = property.vector2IntValue.y;
                DoDraw(position, label);
                property.vector2IntValue = new Vector2Int((int)min, (int)max);
            }
            else
            {
                EditorGUI.LabelField(position, "Use this at Vector2 field");
            }
        }

        private void DoDraw(Rect position, GUIContent label)
        {
            EditorGUI.MinMaxSlider(position, label, ref min, ref max, rangeAttribute.min, rangeAttribute.max);
            position.height = 16f;
            EditorGUI.indentLevel++;
            position.y += 22f;
            EditorGUI.LabelField(position, $"Min: {min.ToString()}", $"Max: {max.ToString()}");
            EditorGUI.indentLevel--;
        }
    }
}