using UnityEngine;
using Kore.Events;

namespace Kore
{
    [CreateAssetMenu(menuName = "Kore/VariableAsset/Value/Bool")]
    public class BoolAsset : ValueAsset<bool>
    {
        [SerializeField]
        private BoolGameEvent _onValueChangeEvent;

        public override GameEvent<bool> OnValueChanged
        {
            get { return _onValueChangeEvent; }
            set { _onValueChangeEvent = value as BoolGameEvent; }
        }

        public static implicit operator bool(BoolAsset v) => v.Value;
    }
}