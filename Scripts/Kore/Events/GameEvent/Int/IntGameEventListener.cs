using UnityEngine;
using UnityEngine.Events;

namespace Kore.Events
{
    [AddComponentMenu("Kore/Events/Listeners/IntGameEventListener")]
    public class IntGameEventListener : GameEventListener<int>
    {
        public IntGameEvent ListeningEvent;
        public IntUnityEvent EventHandle;

        protected override GameEvent<int> listeningEvent => ListeningEvent;

        protected override UnityEvent<int> eventHandle => EventHandle;
    }
}