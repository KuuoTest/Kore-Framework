using UnityEngine;
using UnityEngine.Events;

namespace Kore.Events
{
    [AddComponentMenu("Kore/Events/Collision2DEvent")]
    public class Collision2DEvent : MonoBehaviour
    {
        [System.Serializable]
        public class Collision2DUnityEvent : UnityEvent<Collision2D> { }

        public LayerCheck layerChecker;
        public Collision2DUnityEvent onCollisionEnter2D;
        public Collision2DUnityEvent onCollisionStay2D;
        public Collision2DUnityEvent onCollisionExit2D;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (!layerChecker.Accept(collision)) return;
            onCollisionEnter2D.Invoke(collision);
        }

        private void OnCollisionStay2D(Collision2D collision)
        {
            if (!layerChecker.Accept(collision)) return;
            onCollisionStay2D.Invoke(collision);
        }

        private void OnCollisionExit2D(Collision2D collision)
        {
            if (!layerChecker.Accept(collision)) return;
            onCollisionExit2D.Invoke(collision);
        }
    }
}