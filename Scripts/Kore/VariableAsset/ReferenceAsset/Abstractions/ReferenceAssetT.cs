namespace Kore
{
    public abstract class ReferenceAsset<T> : ReferenceAsset
        where T: class
    {
        public T Ref { get; set; }

        public void Release() => Ref = null;
    }
}