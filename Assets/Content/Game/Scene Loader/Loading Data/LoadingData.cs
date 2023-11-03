namespace FightParty.Game.SceneLoader
{
    public class LoadingData
    { 
        private IGameMode<GameModeConfig> _gameMode;

        public LoadingData(IGameMode<GameModeConfig> gameMode)
            => _gameMode = gameMode;

        public IGameMode<GameModeConfig> GameMode => _gameMode;
    }
}
