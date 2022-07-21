using EMA.Scripts.PatternClasses;
using UnityEngine;

namespace _Main.Scripts.Sound
{
    public class SoundManager : MonoSingleton<SoundManager>
    {
        [SerializeField] private AudioSource audioSource;
        [SerializeField] private AudioClip popClip;
        
        public void PlayPopSound()
        {
            audioSource.PlayOneShot(popClip);
        }
    }
}
