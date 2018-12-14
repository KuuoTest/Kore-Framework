using UnityEngine;
using Kore.Events;

namespace Kore
{
    [CreateAssetMenu(menuName = "Kore/VariableAsset/Value/Int")]
    public class IntAsset : ValueAsset<int>
    {
        [SerializeField]
        private IntGameEvent _onValueChangeEvent;

        public override GameEvent<int> OnValueChanged
        {
            get { return _onValueChangeEvent; }
            set { _onValueChangeEvent = value as IntGameEvent; }
        }

        public void Add(int amount) => Value += amount;

        public void Add(IntAsset asset) => Value += asset.Value;

        public static implicit operator int(IntAsset v) => v.Value;
    }
}