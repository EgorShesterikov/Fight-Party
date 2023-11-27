namespace FightParty.Game.PlayScene
{
    public class GameModInitializer
    {
        public GameModInitializer(IGameMode<GameModeConfig> gameMode, GameSpawner playWindowSpawner, 
            BallSpawner ballSpawner, CharacterSpawner characterSpawner) 
            => gameMode.Initialize(playWindowSpawner, ballSpawner, characterSpawner);
    }
}