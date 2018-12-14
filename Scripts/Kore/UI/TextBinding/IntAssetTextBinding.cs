using UnityEngine;

namespace Kore.UI
{
    [AddComponentMenu("Kore/UI/TextBinding/IntAssetTextBinding")]
    public class IntAssetTextBinding : ValueAssetTextBinding<int>
    {
        public IntAsset asset;

        public override ValueAsset<int> valueAsset => asset;
    }
}