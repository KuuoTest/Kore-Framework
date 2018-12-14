using UnityEngine;
using UnityEngine.UI;

namespace Kore.UI
{
    public abstract class TextBinding : MonoBehaviour
    {
        public Text bindText;
        public string format = "G";

        protected void SetText(string text)
        {
            bindText.text = text;
        }
    } 
}