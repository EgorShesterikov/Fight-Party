namespace FightParty.Game.SceneLoader
{
    public interface IDataSceneLoader
    {
        void Load(LevelLoadingData levelLoadingData, SceneID sceneID);
    }
}
