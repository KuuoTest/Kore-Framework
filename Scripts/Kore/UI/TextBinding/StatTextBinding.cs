using Kore.Stats;
using UnityEngine;

namespace Kore.UI
{
    [AddComponentMenu("Kore/UI/TextBinding/StatTextBinding")]
    public class StatTextBinding : TextBinding
    {
        public StatType targetType;
        public CharacterStatsAsset statsRef;
        
        private void Start()
        {
            SetText(statsRef.Ref[targetType]);
        }

        private void OnEnable()
        {
            statsRef.Ref?.onStatChanged.AddListener(SetText);
        }

        private void OnDisable()
        {
            statsRef.Ref?.onStatChanged.RemoveListener(SetText);
        }

        private void SetText(Stat newStat)
        {
            if (newStat == null) return;
            if (newStat.type != targetType) return;
            SetText(newStat.value.ToString(format));
        }
    }
}