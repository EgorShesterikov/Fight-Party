namespace FightParty.Game.PlayScene
{
    public partial class GameController
    {
        private IGameMode<GameModeConfig> _gameMode;

        public GameController(IGameMode<GameModeConfig> gameMode, PlayWindowGenerator playWindowGenerator, 
            BallSpawner ballGenerator, CharacterSpawner characterSpawner) 
        { 
            _gameMode = gameMode;

            playWindowGenerator.Create(_gameMode.GameType);

            _gameMode.Initialize(ballGenerator, characterSpawner);
        }

    }
}