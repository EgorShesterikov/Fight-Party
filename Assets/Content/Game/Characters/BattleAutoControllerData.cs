namespace FightParty.Game
{
    public class BattleAutoControllerData
    {
        private Character _targetPlayer;
        private Ball _ball;

        public BattleAutoControllerData(Character targetPlayer, Ball ball)
        {
            _targetPlayer = targetPlayer;
            _ball = ball;
        }

        public Character TargetPlayer => _targetPlayer;
        public Ball Ball => _ball;
    }
}