namespace Kore.UI
{
    public abstract class ValueAssetTextBinding<TValue> : TextBinding
        where TValue : struct
    {
        public abstract ValueAsset<TValue> valueAsset { get; }

        private void Start()
        {
            SetText(valueAsset.Value);
        }

        private void OnEnable()
        {
            valueAsset.OnValueChanged.AddListener(SetText);
        }

        private void OnDisable()
        {
            valueAsset.OnValueChanged.RemoveListener(SetText);
        }

        protected virtual void SetText(TValue newValue)
        {
            SetText(newValue.ToString());
        }
    }
}