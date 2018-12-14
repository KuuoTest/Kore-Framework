using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Kore.Events
{
    [AddComponentMenu("Kore/Events/ConditionalEvent")]
    public class ConditionalEvent : MonoBehaviour
    {
        [System.Serializable]
        public class ConditionalAction
        {
            public string description;
            public List<ConditionCheck> conditionChecks;
            public UnityEvent handle;

            public bool Satisfied => conditionChecks.TrueForAll(c => c.Satisfied);

            public bool CheckAndHandle()
            {
                if (Satisfied)
                {
                    handle.Invoke();
                    return true;
                }
                return false;
            }
        }

        public List<ConditionalAction> conditionActions;

        public void CheckAndRaise()
        {
            conditionActions.ForEach(ca =>
            {
                if (ca.CheckAndHandle()) return;
            });
        }
    }
}