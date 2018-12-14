using UnityEngine;
using UnityEngine.Events;

namespace Kore.Events
{
    [AddComponentMenu("Kore/Events/Listeners/FloatGameEventListener")]
    public class FloatGameEventListener : GameEventListener<float>
    {
        public FloatGameEvent ListeningEvent;
        public FloatUnityEvent EventHandle;

        protected override GameEvent<float> listeningEvent => ListeningEvent;

        protected override UnityEvent<float> eventHandle => EventHandle;
    }
}