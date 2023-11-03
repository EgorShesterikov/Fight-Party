using FightParty.Game.PlayScene.Battle;
using FightParty.Game.PlayScene.Survival;
using System;
using System.IO;
using UnityEngine;
using Zenject;

namespace FightParty.Game.PlayScene
{
    public class PlayWindowFactory
    {
        private const string PathFolderGameModsConfig = "Game Mods";

        private const string PathNameBattleInterface = "Battle Interface";
        private const string PathNameSurvivalInterface = "Survival Interface";

        private DiContainer _container;
        public PlayWindowFactory(DiContainer container)
            => _container = container;

        public WindowBase Get(GameTypes gameModeTypes)
        => gameModeTypes switch
        {
            GameTypes.Battle => _container.InstantiatePrefabForComponent<BattleMenuView>(LoadBattleInterface()),
            GameTypes.Survival => _container.InstantiatePrefabForComponent<SurvivalMenuView>(LoadSurvivalInterface()),
            _ => throw new NotImplementedException()
        };

        private WindowBase LoadBattleInterface()
            => Resources.Load<WindowBase>(Path.Combine(PathFolderGameModsConfig, PathNameBattleInterface));

        private WindowBase LoadSurvivalInterface()
            => Resources.Load<WindowBase>(Path.Combine(PathFolderGameModsConfig, PathNameSurvivalInterface));
    }
}