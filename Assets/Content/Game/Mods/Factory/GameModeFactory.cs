using System;

namespace FightParty.Game
{
    public class GameModeFactory
    {
        public IGameMode Get(GameTypes gameModeTypes)
        => gameModeTypes switch
        {
            GameTypes.Battle => new BattleMod(),
            GameTypes.Survival => new SurvivalMod(),
            _ => throw new NotImplementedException()
        };
    }
}
