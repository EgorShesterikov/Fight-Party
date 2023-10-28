using FightParty.Audio;
using UnityEngine;
using Zenject;

namespace FightParty.Installers
{
    public class AudioInstaller : MonoInstaller
    {
        [SerializeField] private MusicSource _musicSource;
        [SerializeField] private GlobalSFXSource _globalSFXSource;

        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<AudioSystem>().FromNew().AsSingle();
            Container.BindInstance(_musicSource).AsSingle();
            Container.BindInstance(_globalSFXSource).AsSingle();
        }
    }
}
