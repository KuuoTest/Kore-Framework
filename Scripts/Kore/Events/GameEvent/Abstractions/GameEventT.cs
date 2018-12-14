using UnityEngine;

namespace Kore.Events
{
    public abstract class GameEvent<T> : ScriptableObject
    {
        protected event System.Action<T> OnEventRaise;

        public void Raise(T arg)
        {
            OnEventRaise?.Invoke(arg);
        }

        public void AddListener(System.Action<T> listener)
        {
            OnEventRaise += listener;
        }

        public void RemoveListener(System.Action<T> listener)
        {
            OnEventRaise -= listener;
        }
    }
}