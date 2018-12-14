using UnityEngine;

namespace Kore
{
    [CreateAssetMenu(menuName = "Kore/ConditionCheck/LayerCheck")]
    public class LayerCheck : ScriptableObject
    {
        public LayerMask acceptLayer;

        public bool Accept(GameObject go)
        {
            return Accept(go.layer);
        }

        public bool Accept(Collision collision)
        {
            return Accept(collision.gameObject);
        }

        public bool Accept(Collision2D collision)
        {
            return Accept(collision.gameObject);
        }

        public bool Accept(Component component)
        {
            return Accept(component.gameObject);
        }

        public bool Accept(int layer)
        {
            return (acceptLayer.value & (1 << layer)) != 0;
        }
    }
}