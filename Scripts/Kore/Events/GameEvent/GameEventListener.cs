using UnityEngine;
using UnityEngine.Events;

namespace Kore.Events
{
    [AddComponentMenu("Kore/Events/Listeners/GameEventListener")]
    public class GameEventListener : MonoBehaviour
    {
        public GameEvent listeningEvent;
        public UnityEvent eventHandle;

        private void OnEnable()
        {
            listeningEvent.AddListener(Response);
        }

        private void OnDisable()
        {
            listeningEvent.RemoveListener(Response);
        }

        public void Response()
        {
            eventHandle?.Invoke();
        }
    }
}