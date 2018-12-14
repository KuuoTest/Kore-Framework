using UnityEngine;
using UnityEngine.Events;

namespace Kore.Events
{
    [AddComponentMenu("Kore/Events/UnityEventRaiser")]
    public class UnityEventRaiser : MonoBehaviour
    {
        public UnityEvent Event;

        public virtual void Raise()
        {
            Event.Invoke();
        }

        public void DelayedRaise(float delay)
        {
            Invoke(nameof(UnityEventRaiser.Raise), delay);
        }

#if UNITY_EDITOR
        [ContextMenu("Test Invoke")]
        public void InvokeTest()
        {
            Event.Invoke();
        }
#endif
    }
}