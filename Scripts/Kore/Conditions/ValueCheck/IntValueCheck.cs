using UnityEngine;

namespace Kore
{
    [CreateAssetMenu(menuName = "Kore/ConditionCheck/ValueCheck/Int")]
    public class IntValueCheck : ConditionCheck
    {
        public IntReference lhs;
        public ValueComparison comparison;
        public IntReference rhs;

        protected override bool Check() => comparison.Check(lhs.Value, rhs.Value);
    }
}