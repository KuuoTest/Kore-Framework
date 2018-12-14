using UnityEngine;

namespace Kore
{
    [CreateAssetMenu(menuName = "Kore/VariableAsset/Reference/AudioSource")]
    public class AudioSourceAsset : ReferenceAsset<AudioSource>
    {
        public void PlayOneShot(AudioClip clip)
        {
            Ref.PlayOneShot(clip);
        }
    }
}