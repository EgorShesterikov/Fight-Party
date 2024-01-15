namespace FightParty.Game.SceneLoader
{
    public class LoadingData
    { 
        private IGameMode _gameMode;

        public LoadingData(IGameMode gameMode)
            => _gameMode = gameMode;

        public IGameMode GameMode => _gameMode;
    }
}
