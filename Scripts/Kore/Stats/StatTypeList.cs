using System;
using System.Linq;
using UnityEngine;

namespace Kore.Stats
{
    [CreateAssetMenu(menuName = "Kore/Stats/StatTypeData")]
    public class StatTypeList : ScriptableObject
    {
        public StatType[] data;

        public StatType this[string typeName] =>
            data.FirstOrDefault(t => t.typeName == typeName);
    }
}