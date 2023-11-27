using FightParty.Game.PlayScene.Battle;
using FightParty.Game.PlayScene.Survival;
using System;
using System.IO;
using UnityEngine;
using Zenject;

namespace FightParty.Game.PlayScene
{
    public class GameFactory
    {
        private const string PathFolderGameModsConfig = "Game Mods";

        private const string PathNameBattleInterface = "Battle Interface";
        private const string PathNameSurvivalInterface = "Survival Interface";

        private DiContainer _container;

        public GameFactory(DiContainer container)
            => _container = container;

        public GameBootstrap Get(GameTypes gameModeTypes)
        {
            switch (gameModeTypes)
            {
                case GameTypes.Battle:
                    _container.BindInterfacesAndSelfTo<BattleResultUIMediator>().FromNew().AsSingle();
                    return _container.InstantiatePrefabForComponent<BattleBootstrap>(LoadBattleInterface());
                    
                case GameTypes.Survival:
                    _container.BindInterfacesAndSelfTo<SurvivalResultUIMediator>().FromNew().AsSingle();
                    return _container.InstantiatePrefabForComponent<SurvivalBootstrap>(LoadSurvivalInterface());

                default: 
                    throw new NotImplementedException();
            };
        }

        private BattleBootstrap LoadBattleInterface()
            => Resources.Load<BattleBootstrap>(Path.Combine(PathFolderGameModsConfig, PathNameBattleInterface));

        private SurvivalBootstrap LoadSurvivalInterface()
            => Resources.Load<SurvivalBootstrap>(Path.Combine(PathFolderGameModsConfig, PathNameSurvivalInterface));
    }
}