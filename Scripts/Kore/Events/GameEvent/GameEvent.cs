using UnityEngine;

namespace Kore.Events
{
    [CreateAssetMenu(menuName = "Kore/GameEvent/GameEvent")]
    public class GameEvent : ScriptableObject
    {
        protected event System.Action OnEventRaise;

        public void Raise()
        {
            OnEventRaise?.Invoke();
        }

        public void AddListener(System.Action listener)
        {
            OnEventRaise += listener;
        }

        public void RemoveListener(System.Action listener)
        {
            OnEventRaise -= listener;
        }
    }
}