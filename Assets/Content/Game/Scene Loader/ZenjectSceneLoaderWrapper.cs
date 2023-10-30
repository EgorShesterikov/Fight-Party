using System;
using UnityEngine.SceneManagement;
using Zenject;

namespace FightParty.Game.SceneLoader
{
    public class ZenjectSceneLoaderWrapper
    {
        private readonly ZenjectSceneLoader _zenjectSceneLoader; 

        public ZenjectSceneLoaderWrapper(ZenjectSceneLoader sceneLoader)
            => _zenjectSceneLoader = sceneLoader;

        public void Load(Action<DiContainer> action, int sceneID)
            => _zenjectSceneLoader.LoadScene(sceneID, LoadSceneMode.Single, container => action?.Invoke(container));
    }
}
