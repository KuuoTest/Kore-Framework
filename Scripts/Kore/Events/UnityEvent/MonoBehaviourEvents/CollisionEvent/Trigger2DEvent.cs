using UnityEngine;
using UnityEngine.Events;

namespace Kore.Events
{
    [AddComponentMenu("Kore/Events/Trigger2DEvent")]
    public class Trigger2DEvent : MonoBehaviour
    {
        [System.Serializable]
        public class Collider2DUnityEvent : UnityEvent<Collider2D> { }

        public LayerCheck layerChecker;
        public Collider2DUnityEvent onTriggerEnter2D;
        public Collider2DUnityEvent onTriggerStay2D;
        public Collider2DUnityEvent onTriggerExit2D;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!layerChecker.Accept(other)) return;
            onTriggerEnter2D.Invoke(other);
        }

        private void OnTriggerStay2D(Collider2D other)
        {
            if (!layerChecker.Accept(other)) return;
            onTriggerStay2D.Invoke(other);
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (!layerChecker.Accept(other)) return;
            onTriggerExit2D.Invoke(other);
        }
    }
}