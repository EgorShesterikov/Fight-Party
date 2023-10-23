using UnityEngine;
using System;

namespace FightParty.Audio
{
    [RequireComponent(typeof(AudioSource))]
    public class MusicSource : MonoBehaviour
    {
        public enum TypesMusic
        {
            Default = 0,
            Play,
            Lose,
            Win
        }

        [SerializeField] private TypesMusic _startMusic = TypesMusic.Default;

        [Space]
        [SerializeField] private AudioClip _defaultMusic;
        [SerializeField] private AudioClip _playMusic;
        [SerializeField] private AudioClip _loseMusic;
        [SerializeField] private AudioClip _winMusic;

        private AudioSource _musicSource;

        public void PlayMusic(TypesMusic typeMusic)
        {
            switch (typeMusic)
            {
                case TypesMusic.Default:
                    _musicSource.clip = _defaultMusic;
                    break;

                case TypesMusic.Play:
                    _musicSource.clip = _playMusic;
                    break;

                case TypesMusic.Lose:
                    _musicSource.clip = _loseMusic;
                    break;

                case TypesMusic.Win:
                    _musicSource.clip = _winMusic;
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
