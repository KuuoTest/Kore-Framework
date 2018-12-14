using UnityEngine;
using UnityEngine.Events;

namespace Kore.Events
{
    [AddComponentMenu("Kore/Events/CollisionEvent")]
    public class CollisionEvent : MonoBehaviour
    {
        [System.Serializable]
        public class CollideUnityEvent : UnityEvent<Collision> { }

        public LayerCheck layerChecker;
        public CollideUnityEvent onCollisionEnter;
        public CollideUnityEvent onCollisionStay;
        public CollideUnityEvent onCollisionExit;

        private void OnCollisionEnter(Collision collision)
        {
            if (!layerChecker.Accept(collision)) return;
            onCollisionEnter.Invoke(collision);
        }

        private void OnCollisionStay(Collision collision)
        {
            if (!layerChecker.Accept(collision)) return;
            onCollisionStay.Invoke(collision);
        }

        private void OnCollisionExit(Collision collision)
        {
            if (!layerChecker.Accept(collision)) return;
            onCollisionExit.Invoke(collision);
        }
    }
}