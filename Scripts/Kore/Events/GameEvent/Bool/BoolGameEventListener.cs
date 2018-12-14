using UnityEngine;
using UnityEngine.Events;

namespace Kore.Events
{
    [AddComponentMenu("Kore/Events/Listeners/BoolGameEventListener")]
    public class BoolGameEventListener : GameEventListener<bool>
    {
        public BoolGameEvent ListeningEvent;
        public BoolUnityEvent EventHandle;

        protected override GameEvent<bool> listeningEvent => ListeningEvent;

        protected override UnityEvent<bool> eventHandle => EventHandle;
    }
}