using System;

namespace Kore.Stats
{
    [Serializable]
    public class StatModifier
    {
        public StatType targetType;

        public float baseAmount;

        public float modifyAmount => GetModifyAmount?.Invoke() ?? baseAmount;

        public Func<float> GetModifyAmount;
        
        public StatModifier(StatType targetType, float baseAmount = 0f)
        {
            this.targetType = targetType;
            this.baseAmount = baseAmount;
            GetModifyAmount = () => baseAmount;
        }
    }
}