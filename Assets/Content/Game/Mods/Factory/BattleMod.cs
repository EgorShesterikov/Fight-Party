using FightParty.Game.PlayScene;

namespace FightParty.Game
{
    public class BattleMod : IGameMode
    {
        private StateMachine _stateMachine;

        public void Initialize(GameSpawner playWindowSpawner, BallSpawner ballSpawner, CharacterSpawner characterSpawner)
        {
            ballSpawner.SpawnDefaultBallInCenter();

            characterSpawner.SpawnFirstCharacterInLeftCorner();
            characterSpawner.SpawnSecondCharacterInRightCorner();

            playWindowSpawner.SpawnBattleWindow();
        }

        public void BindStateMachine(StateMachine stateMachine)
            => _stateMachine = stateMachine;

        public void Update()
            => _stateMachine?.Tick();
    }
}