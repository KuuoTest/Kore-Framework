using UnityEngine;
using UnityEngine.Events;

namespace Kore.Events
{
    [AddComponentMenu("Kore/Events/TriggerEvent")]
    public class TriggerEvent : MonoBehaviour
    {
        [System.Serializable]
        public class ColliderUnityEvent : UnityEvent<Collider> { }

        public LayerCheck layerChecker;
        public ColliderUnityEvent onTriggerEnter;
        public ColliderUnityEvent onTriggerStay;
        public ColliderUnityEvent onTriggerExit;

        private void OnTriggerEnter(Collider other)
        {
            if (!layerChecker.Accept(other)) return;
            onTriggerEnter.Invoke(other);
        }

        private void OnTriggerStay(Collider other)
        {
            if (!layerChecker.Accept(other)) return;
            onTriggerStay.Invoke(other);
        }

        private void OnTriggerExit(Collider other)
        {
            if (!layerChecker.Accept(other)) return;
            onTriggerExit.Invoke(other);
        }
    }
}