using UnityEngine;

namespace FightParty.Game.PlayScene
{
    public class PlayWindowGenerator
    {
        private PlayWindowFactory _factroy;
        private Transform _targetParent;

        public PlayWindowGenerator(PlayWindowFactory factroy, GamePlayMenuView gamePlayMenuView)
        {
            _factroy = factroy;
            _targetParent = gamePlayMenuView.transform;
        }

        public void Create(GameTypes gameModeTypes)
        {
            WindowBase playInterface = _factroy.Get(gameModeTypes);

            playInterface.transform.SetParent(_targetParent);
            playInterface.SetDefaultPos();
        }
    }
}