using FightParty.Game.PlayScene;
using FightParty.Game.PlayScene.Battle;

namespace FightParty.Game
{
    public class BattleMod : IGameMode<BattleConfig>
    {
        private BattleConfig _config;

        private BattleStateMachine _stateMachine;

        public BattleMod(BattleConfig config)
            => _config = config;

        public BattleConfig Config => _config;

        public GameTypes GameType => GameTypes.Battle;

        public StateMachine StateMachine => _stateMachine;

        public void Initialize(GameSpawner playWindowSpawner, BallSpawner ballSpawner, CharacterSpawner characterSpawner)
        {
            ballSpawner.SpawnDefaultBallInCenter();

            characterSpawner.SpawnYellowCharacterInLeftCorner();
            characterSpawner.SpawnBlueCharacterInRightCorner();

            playWindowSpawner.SpawnBattleWindow();
        }

        public void BindStateMachine(StateMachine stateMachine)
            => _stateMachine = (BattleStateMachine)stateMachine;
    }
}