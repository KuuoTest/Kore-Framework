using UnityEngine;
using UnityEngine.Events;

namespace Kore.Events
{
    [AddComponentMenu("Kore/Events/Listeners/StringGameEventListener")]
    public class StringGameEventListener : GameEventListener<string>
    {
        public StringGameEvent ListeningEvent;
        public StringUnityEvent EventHandle;

        protected override GameEvent<string> listeningEvent => ListeningEvent;

        protected override UnityEvent<string> eventHandle => EventHandle;
    }
}