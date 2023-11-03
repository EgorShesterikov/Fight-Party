using FightParty.Installers;
using System;

namespace FightParty.Game.SceneLoader
{
    public class SceneLoader : ISimpleSceneLoader, IDataSceneLoader
    {
        private ZenjectSceneLoaderWrapper _zenjectSceneLoader;

        public SceneLoader(ZenjectSceneLoaderWrapper zenjectSceneLoader)
            => _zenjectSceneLoader = zenjectSceneLoader;

        public void Load(SceneID sceneID)
        {
            if (sceneID == SceneID.PlayScene)
                throw new ArgumentException($"{SceneID.PlayScene} cannot be started without configuration");

            _zenjectSceneLoader.Load(null, (int)sceneID);
        }

        public void Load(LoadingData loadingData)
        {
            _zenjectSceneLoader.Load(container =>
            {
                container.BindInstance(loadingData).WhenInjectedInto<PlaySceneInstaller>();
            }, (int)SceneID.PlayScene);
        }
    }
}