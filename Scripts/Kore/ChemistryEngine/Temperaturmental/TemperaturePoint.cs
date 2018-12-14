using UnityEngine;
using UnityEngine.Events;

namespace Kore.Chemistry
{
    [System.Serializable]
    public class TemperaturePoint
    {
        public int point;
        public UnityEvent onExceedPoint;
        public UnityEvent onBelowPoint;

        private bool m_Exceeded;
        private bool m_Belowed;

        public bool TryRaiseEvent(int newTemperature)
        {
            if (!m_Exceeded && newTemperature > point)
            {
                onExceedPoint?.Invoke();
                m_Exceeded = true;
                m_Belowed = false;
                return true;
            }
            else if (!m_Belowed && newTemperature < point)
            {
                onBelowPoint?.Invoke();
                m_Belowed = true;
                m_Exceeded = false;
                return true;
            }

            return false;
        }
    }
}