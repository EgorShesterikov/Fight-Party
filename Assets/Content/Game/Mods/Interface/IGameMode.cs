using FightParty.Game.PlayScene;

namespace FightParty.Game
{
    public interface IGameMode
    {
        void Initialize(GameSpawner playWindowSpawner, BallSpawner ballGenerator, CharacterSpawner characterSpawner);

        void BindStateMachine(StateMachine stateMachine);

        void Update();
    }
}