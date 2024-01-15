using FightParty.Game.PlayScene;

namespace FightParty.Game
{
    public class SurvivalMod : IGameMode
    {
        private StateMachine _stateMachine;

        public void Initialize(GameSpawner playWindowSpawner, BallSpawner ballGenerator, CharacterSpawner characterSpawner)
        {
            characterSpawner.SpawnFirstCharacterInCentr();
            characterSpawner.SpawnSecondCharacterInCentr();

            playWindowSpawner.CreateSurvivalWindow();
        }

        public void BindStateMachine(StateMachine stateMachine)
            => _stateMachine = stateMachine;

        public void Update()
            => _stateMachine?.Tick();
    }
}