using System;
using Kore.Events;
using UnityEngine;
using UnityEngine.Events;

namespace Kore.Chemistry
{
    [AddComponentMenu("Kore/Chemistry/Temperature")]
    public class Temperature : MonoBehaviour
    {
        [SerializeField] private int m_Value;
        public IntUnityEvent onValueChanged;

        public int Value
        {
            get { return m_Value; }
            set
            {
                if (value == m_Value) return;
                m_Value = value;
                onValueChanged?.Invoke(m_Value);
            }
        }
    }
}