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

        public void Load(LevelLoadingData levelLoadingData, SceneID sceneID)
        {
            _zenjectSceneLoader.Load(container =>
            {
                container.BindInstance(levelLoadingData);
            }, (int)sceneID);
        }
    }
}