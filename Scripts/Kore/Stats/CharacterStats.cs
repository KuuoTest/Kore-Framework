using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

namespace Kore.Stats
{
    [AddComponentMenu("Kore/Stats/CharacterStats")]
    public class CharacterStats : MonoBehaviour
    {
        [Serializable]
        public class StatChangeEvent : UnityEvent<Stat> { }

        public CharacterStatsConfig config;
        public StatChangeEvent onStatChanged = new StatChangeEvent();

        public Stat this[StatType statType] =>
            data.FirstOrDefault(s => s.type == statType);

        [SerializeField]
        private List<Stat> data = new List<Stat>();


        public bool ModifyStat(StatType targetType, Func<Stat, bool> handle)
        {
            if (targetType == null || handle == null) return false;

            var stat = this[targetType];
            if (stat == null) return false;

            if (handle(stat))
            {
                onStatChanged.Invoke(stat);
                return true;
            }
            return false;
        }

        public bool AddModifier(StatModifier modifier)
        {
            if (modifier?.targetType == null) return false;
            return ModifyStat(modifier.targetType, s => s.AddModifier(modifier));
        }

        public bool RemoveModifier(StatModifier modifier)
        {
            if (modifier?.targetType == null) return false;
            return ModifyStat(modifier.targetType, s => s.RemoveModifier(modifier));
        }
        

#if UNITY_EDITOR
        [ContextMenu("Init Stat Data")]
        private void InitStatData()
        {
            if (config)
            {
                data.Clear();
                data.AddRange(config.statConfigs.Select(c => new Stat(c)));
            }
        }
#endif
    }
}