using System;
using UnityEngine;

namespace Kore.Chemistry
{
    [AddComponentMenu("Kore/Chemistry/Temperaturmental")]
    public class Temperaturmental : MonoBehaviour
    {
        public Temperature temperature;
        public TemperaturePoint[] reactionPoints;

        private void TemperatureChangeHanlde(int newTemperature)
        {
            Array.ForEach(reactionPoints, p => p.TryRaiseEvent(newTemperature));
        }

        private void OnEnable()
        {
            temperature.onValueChanged.AddListener(TemperatureChangeHanlde);
        }

        private void OnDisable()
        {
            temperature.onValueChanged.RemoveListener(TemperatureChangeHanlde);
        }
    }
}