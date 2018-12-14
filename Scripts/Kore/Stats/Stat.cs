using System.Collections.Generic;
using System.Linq;

namespace Kore.Stats
{
    [System.Serializable]
    public class Stat
    {
        public StatConfig config;

        public List<StatModifier> modifiers = new List<StatModifier>();

        public StatType type => config.type;

        public float baseValue => config.value;

        public int intValue => (int)value;

        public float value
        {
            get
            {
                if (isDirty)
                {
                    modValue = CalculateValue();
                    isDirty = false;
                }
                return baseValue + modValue;
            }
        }

        private bool isDirty;
        private float modValue;

        public Stat(StatConfig config)
        {
            this.config = config;
        }

        public bool AddModifier(StatModifier newModifier)
        {
            if (newModifier.targetType != type) return false;
            modifiers.Add(newModifier);
            return isDirty = true;
        }

        public bool RemoveModifier(StatModifier modifierToRemove)
        {
            if (modifierToRemove.targetType != type) return false;
            return isDirty = modifiers.Remove(modifierToRemove);
        }

        public void ClearModifier()
        {
            modifiers.Clear();
        }

        private float CalculateValue()
        {
            return modifiers.Sum(m => m.modifyAmount);
        }
    }
}