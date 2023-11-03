namespace FightParty.Game
{
    public interface IGameMode<out T> where T : GameModeConfig
    {
        T Config { get; }

        GameTypes GameType { get; }

        void Initialize(BallSpawner ballGenerator, CharacterSpawner characterSpawner);

        bool IsResult();
    }
}