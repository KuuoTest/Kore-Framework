using UnityEngine;

namespace Kore
{
    public abstract class ConditionCheck : ScriptableObject
    {
        public virtual bool Satisfied => Check();

        protected abstract bool Check();
    }
}