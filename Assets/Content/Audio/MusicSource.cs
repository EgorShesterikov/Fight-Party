using UnityEngine;
using System;

namespace FightParty.Audio
{
    [RequireComponent(typeof(AudioSource))]
    public class MusicSource : MonoBehaviour
    {
        public enum TypesMusic
        {
            None = 0,
            Default,
            Battle,
            Survival
        }

        [SerializeField] private TypesMusic _startMusic = TypesMusic.Default;

        [Space]
        [SerializeField] private AudioClip _defaultMusic;
        [SerializeField] private AudioClip _battleMusic;
        [SerializeField] private AudioClip _survivalMusic;

        private AudioSource _musicSource;

        public void PlayMusic(TypesMusic typeMusic)
        {
            switch (typeMusic)
            {
                case TypesMusic.None:
                    break;

                case TypesMusic.Default:
                    _musicSource.clip = _defaultMusic;
                    break;

                case TypesMusic.Battle:
                    _musicSource.clip = _battleMusic;
                    break;

                case TypesMusic.Survival:
                    _musicSource.clip = _survivalMusic;
                    break;

                default:
                    throw new ArgumentException(nameof(typeMusic));
            }

            _musicSource.Play();
        }

        private void Awake()
        {
            _musicSource = GetComponent<AudioSource>();

            PlayMusic(_startMusic);
        }
    }
}
