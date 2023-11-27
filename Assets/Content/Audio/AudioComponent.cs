using System;
using System.Collections.Generic;
using UnityEngine;

namespace FightParty.Audio
{
    [RequireComponent(typeof(AudioSource))]
    public class AudioComponent : MonoBehaviour
    {
        [SerializeField] private List<AudioClip> _sounds;

        private AudioSource _audioSource;

        private void Start()
            => _audioSource = GetComponent<AudioSource>();

        public void PlaySound(int indexSound)
        {
            if(indexSound < 0 || indexSound >= _sounds.Count)
                throw new ArgumentOutOfRangeException(nameof(indexSound));

            _audioSource.PlayOneShot(_sounds[indexSound]);
        }
    }
}
