namespace FightParty.Game
{
    public class BattleMod : IGameMode<BattleConfig>
    {
        private BattleConfig _config;

        private int _battleRating;

        public BattleMod(int battleRating, BattleConfig config)
        { 
            _battleRating = battleRating;

            _config = config;
        }

        public BattleConfig Config => _config;

        public GameTypes GameType => GameTypes.Battle;

        public void Initialize(BallSpawner ballGenerator, CharacterSpawner characterSpawner)
        {
            ballGenerator.SpawnDefaultBallInCenter();

            characterSpawner.SpawnYellowCharacterInLeftCorner();
            characterSpawner.SpawnBlueCharacterInRightCorner();
        }

        public bool IsResult()
        {
            return true;
        }
    }
}