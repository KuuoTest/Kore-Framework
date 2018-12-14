using UnityEngine;

namespace Kore
{
    [CreateAssetMenu(menuName = "Kore/ConditionCheck/ValueCheck/Bool")]
    public class BoolValueCheck : ConditionCheck
    {
        public BoolAsset asset;
        public bool needValue;

        protected override bool Check()
        {
            return asset.Value == needValue;
        }
    }
}