
namespace Kore
{
    [System.Serializable]
    public class IntReference
    {
        public bool useConstant = true;
        public int constantValue;
        public IntAsset variable;

        public int Value
        {
            get { return useConstant ? constantValue : variable; }
            set
            {
                if (useConstant) constantValue = value;
                else variable.Value = value;
            }
        }

        public static implicit operator int(IntReference intReference) => intReference.Value;
    }
}