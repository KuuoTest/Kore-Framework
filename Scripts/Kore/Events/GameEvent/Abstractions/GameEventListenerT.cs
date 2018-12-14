using UnityEngine;
using UnityEngine.Events;

namespace Kore.Events
{
    public abstract class GameEventListener<T> : MonoBehaviour
    {
        protected abstract GameEvent<T> listeningEvent { get; }
        protected abstract UnityEvent<T> eventHandle { get; }

        private void OnEnable()
        {
            listeningEvent.AddListener(Response);
        }

        private void OnDisable()
        {
            listeningEvent.RemoveListener(Response);
        }

        public void Response(T arg)
        {
            eventHandle?.Invoke(arg);
        }
    }
}