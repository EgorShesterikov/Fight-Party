using FightParty.Game.PlayScene;

namespace FightParty.Game
{
    public interface IGameMode<out T> where T : GameModeConfig
    {
        T Config { get; }

        StateMachine StateMachine { get;}

        GameTypes GameType { get; }

        void Initialize(GameSpawner playWindowSpawner, BallSpawner ballGenerator, CharacterSpawner characterSpawner);

        void BindStateMachine(StateMachine stateMachine);
    }
}