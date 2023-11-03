namespace FightParty.Game
{
    public class SurvivalMod : IGameMode<SurvivalConfig>
    {
        private SurvivalConfig _config;

        public SurvivalMod(SurvivalConfig config)
        {
            _config = config;
        }

        public SurvivalConfig Config => _config;

        public GameTypes GameType => GameTypes.Survival;

        public void Initialize(BallSpawner ballGenerator, CharacterSpawner characterSpawner)
        {
            characterSpawner.SpawnBlueCharacterInCentr();
        }

        public bool IsResult()
        {
            return true;
        }
    }
}