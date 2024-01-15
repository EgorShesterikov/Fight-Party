using FightParty.Audio;
using FightParty.Save;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace FightParty.Game
{
    public abstract class GameBootstrap : MonoBehaviour
    {
        protected IGameMode GameMode;

        protected MusicSource MusicSource;

        protected GlobalSFXSource GlobalSFXSource;

        protected ProgressManager ProgressManager;

        protected List<Character> Characters;

        [Inject]
        public void Construct(IGameMode gameMode, MusicSource musicSource, GlobalSFXSource globalSFXSource, ProgressManager progressManager,
            List<Character> characters)
        {
            GameMode = gameMode;

            MusicSource = musicSource;

            GlobalSFXSource = globalSFXSource;

            ProgressManager = progressManager;

            Characters = characters;
        }

        protected abstract void Binding();

        private void Awake() => Binding();
    }
}
