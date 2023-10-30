namespace FightParty.Game.SceneLoader
{
    public class SceneLoadMediator
    {
        private ISimpleSceneLoader _simpleSceneLoader;
        private IDataSceneLoader _dataSceneLoader;
        
        public SceneLoadMediator(ISimpleSceneLoader simpleSceneLoader, IDataSceneLoader dataSceneLoader)
        {
            _simpleSceneLoader = simpleSceneLoader;
            _dataSceneLoader = dataSceneLoader;
        }

        public void GoToMainScene()
            => _simpleSceneLoader.Load(SceneID.MenuScene);

        public void GoToPlayScene(LevelLoadingData levelLoadingData)
            => _dataSceneLoader.Load(levelLoadingData, SceneID.PlayScene);
    }
}
