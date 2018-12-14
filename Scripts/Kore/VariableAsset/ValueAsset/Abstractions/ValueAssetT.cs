using UnityEngine;
using Kore.Events;

namespace Kore
{
    public abstract class ValueAsset<T> : ValueAsset
        where T : struct
    {
        [SerializeField]
        private T _value;

        public abstract GameEvent<T> OnValueChanged { get; set; }

        public T Value
        {
            get { return _value; }
            set
            {
                if (value.Equals(_value)) return;
                _value = value;
                OnValueChanged?.Raise(_value);
            }
        }
    }
}