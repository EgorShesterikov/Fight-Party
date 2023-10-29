using FightParty.Audio;
using FightParty.Game.PlayScene;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FightParty.Game.PlayScene.Battle
{
    public class BattleResultMenu
    {
        private BattleResultMenuView _view;

        private GlobalSFXSource _audio;

        public BattleResultMenu(BattleResultMenuView view, GlobalSFXSource audio)
        {
            _view = view;

            _audio = audio;
        }
    }
}