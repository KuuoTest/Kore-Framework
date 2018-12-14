using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

namespace Kore.Events
{
    [AddComponentMenu("Kore/Events/MonoBehaviourEventTrigger")]
    public class MonoBehaviourEventTrigger : MonoBehaviour
    {
        [SerializeField]
        private List<Entry> delegates;

        public List<Entry> triggers
        {
            get
            {
                if (delegates == null) delegates = new List<Entry>();
                return delegates;
            }
            set { delegates = value; }
        }

        private void Awake()
        {
            Execute(EventType.Awake);
        }

        private void OnEnable()
        {
            Execute(EventType.OnEnable);
        }

        private void Start()
        {
            Execute(EventType.Start);
        }

        private void OnDisable()
        {
            Execute(EventType.OnDisable);
        }

        private void OnDestroy()
        {
            Execute(EventType.OnDestroy);
        }

        private void Execute(EventType type)
        {
            triggers.Where(e => e.type == type)?.ToList()
                    .ForEach(e => e.callback.Invoke());
        }

        [System.Serializable]
        public class Entry
        {
            public EventType type = EventType.Awake;
            public UnityEvent callback = new UnityEvent();
        }

        public enum EventType
        {
            Awake,
            OnEnable,
            Start,
            OnDisable,
            OnDestroy
        }
    }
}