using UnityEditor;
using Kore;
using Kore.Events;

namespace KoreEditor
{
    [CustomEditor(typeof(IntAsset))]
    public class IntAssetEditor : ValueAssetEditor<int, IntAsset, IntGameEvent>
    {
    }
}