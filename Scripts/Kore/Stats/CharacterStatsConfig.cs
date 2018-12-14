using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Kore.Stats
{
    [CreateAssetMenu(menuName = "Kore/Stats/CharacterStatsConfig")]
    public class CharacterStatsConfig : ScriptableObject
    {
        public List<StatConfig> statConfigs = new List<StatConfig>();

        public StatConfig this[StatType statType] =>
            statConfigs.FirstOrDefault(c => c.type == statType);
    }
}