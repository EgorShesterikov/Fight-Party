using FightParty.Save;
using System;
using System.IO;
using UnityEngine;

namespace FightParty.Game
{
    public class GameModeFactory
    {
        private const string PathFolderGameModsConfig = "Game Mods";

        private const string PathNameBattleConfig = "BattleConfig";
        private const string PathNameSurvivalConfig = "SurvivalConfig";

        private ProgressManager _progressManager;

        public GameModeFactory(ProgressManager progressManager) 
            => _progressManager = progressManager;

        public IGameMode<GameModeConfig> Get(GameTypes gameModeTypes)
        => gameModeTypes switch
        {
            GameTypes.Battle => new BattleMod(_progressManager.Load().BattleRating, LoadBattleConfig()),
            GameTypes.Survival => new SurvivalMod(LoadSurvivalConfig()),
            _ => throw new NotImplementedException()
        };

        private BattleConfig LoadBattleConfig()
            => Resources.Load<BattleConfig>(Path.Combine(PathFolderGameModsConfig, PathNameBattleConfig));

        private SurvivalConfig LoadSurvivalConfig()
            => Resources.Load<SurvivalConfig>(Path.Combine(PathFolderGameModsConfig, PathNameSurvivalConfig));
    }
}
