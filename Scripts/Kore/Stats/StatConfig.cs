using System;

namespace Kore.Stats
{
    [Serializable]
    public class StatConfig
    {
        public StatType type;

        public float value;

        public int intValue => (int)value;
    }
}