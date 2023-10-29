using FightParty.Game;
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Audio;

namespace FightParty.Audio
{
    public class AudioSystem : IDisposable
    {
        private const string AudioMixerMusicVolume = "MusicVol";
        private const string AudioMixerSFXVolume = "SFXVol";

        private const float AudioMixedMinVolume = 0.0001f;
        private const float AudioMixedMaxVolume = 1f;

        private const float ChangeVolumeMultiplicator = 20f;

        private const string PathFolderAudioMixer = "Audio";
        private const string PathNameAudioMixer = "AudioMixer";

        private AudioMixer _audioMixer;

        private List<IChangeAudio> _audioChangers;

        public AudioSystem(List<IChangeAudio> audioChangers)
        {
            _audioChangers = new List<IChangeAudio>(audioChangers);

            foreach(IChangeAudio changer in _audioChangers)
            {
                changer.ChangedMusic += ChangeVolumeMusic;
                changer.ChangedSound += ChangeVolumeSFX;
            }

            _audioMixer = Resources.Load<AudioMixer>(Path.Combine(PathFolderAudioMixer, PathNameAudioMixer));
        }

        public void Dispose()
        {
            foreach (IChangeAudio changer in _audioChangers)
            {
                changer.ChangedMusic -= ChangeVolumeMusic;
                changer.ChangedSound -= ChangeVolumeSFX;
            }
        }

        private void ChangeVolumeMusic(float volume)
        {
            if (volume < AudioMixedMinVolume || volume > AudioMixedMaxVolume)
                throw new ArgumentOutOfRangeException(nameof(volume));

            _audioMixer.SetFloat(AudioMixerMusicVolume, (float)(Math.Log10(volume) * ChangeVolumeMultiplicator));
        }

        private void ChangeVolumeSFX(float volume)
        {
            if (volume < AudioMixedMinVolume || volume > AudioMixedMaxVolume)
                throw new ArgumentOutOfRangeException(nameof(volume));

            _audioMixer.SetFloat(AudioMixerSFXVolume, (float)(Math.Log10(volume) * ChangeVolumeMultiplicator));
        }
    }
}
