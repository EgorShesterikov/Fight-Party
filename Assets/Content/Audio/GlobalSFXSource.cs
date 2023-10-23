using UnityEngine;

namespace FightParty.Audio
{
    [RequireComponent(typeof(AudioSource))]
    public class GlobalSFXSource : MonoBehaviour
    {
        [SerializeField] private AudioClip _sfxUIClick;
        [SerializeField] private AudioClip _sfxUILock;

        private AudioSource _sfxUISource;

        public void PlayClick() => _sfxUISource.PlayOneShot(_sfxUIClick);

        public void PlayLock() => _sfxUISource.PlayOneShot(_sfxUILock);

        private void Awake() => _sfxUISource = GetComponent<AudioSource>();
    }
}
