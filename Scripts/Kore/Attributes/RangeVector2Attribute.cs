using UnityEngine;

namespace Kore
{
    public class RangeVector2Attribute : PropertyAttribute
    {
        public float min;
        public float max;

        public RangeVector2Attribute(float min, float max)
        {
            this.min = min;
            this.max = max;
        }
    }
}