using FightParty.Game.PlayScene;
using FightParty.Game.PlayScene.Survival;

namespace FightParty.Game
{
    public class SurvivalMod : IGameMode<SurvivalConfig>
    {
        private SurvivalConfig _config;

        private SurvivalStateMachine _stateMachine;

        public SurvivalMod(SurvivalConfig config)
        {
            _config = config;
        }

        public SurvivalConfig Config => _config;

        public GameTypes GameType => GameTypes.Survival;

        public StateMachine StateMachine => _stateMachine;

        public void Initialize(GameSpawner playWindowSpawner, BallSpawner ballGenerator, CharacterSpawner characterSpawner)
        {
            characterSpawner.SpawnYellowCharacterInCentr();
            characterSpawner.SpawnBlueCharacterInCentr();

            playWindowSpawner.CreateSurvivalWindow();
        }

        public void BindStateMachine(StateMachine stateMachine)
           => _stateMachine = (SurvivalStateMachine)stateMachine;
    }
}