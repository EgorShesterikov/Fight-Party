using Zenject;

namespace FightParty.Game.PlayScene
{
    public class GameModInitializer : ITickable
    {
        private IGameMode _gameMode;

        public GameModInitializer(IGameMode gameMode, GameSpawner playWindowSpawner,
            BallSpawner ballSpawner, CharacterSpawner characterSpawner)
        {
            _gameMode = gameMode;
            _gameMode.Initialize(playWindowSpawner, ballSpawner, characterSpawner);
        }

        public void Tick()
            => _gameMode.Update();
    }
}