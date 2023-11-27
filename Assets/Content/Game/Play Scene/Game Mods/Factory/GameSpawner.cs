using UnityEngine;

namespace FightParty.Game.PlayScene
{
    public class GameSpawner
    {
        private GameFactory _factroy;
        private Transform _targetParent;

        public GameSpawner(GameFactory factroy, GamePlayMenuView gamePlayMenuView)
        {
            _factroy = factroy;
            _targetParent = gamePlayMenuView.transform;
        }

        public void SpawnBattleWindow()
        {
            GameBootstrap playInterface = _factroy.Get(GameTypes.Battle);
            ResetPosition(playInterface);
        }

        public void CreateSurvivalWindow()
        {
            GameBootstrap playInterface = _factroy.Get(GameTypes.Survival);
            ResetPosition(playInterface);
        }

        private void ResetPosition(GameBootstrap windowBase)
        {
            windowBase.transform.SetParent(_targetParent);

            RectTransform rectTransform = windowBase.GetComponent<RectTransform>();

            rectTransform.anchoredPosition = Vector3.zero;
            rectTransform.sizeDelta = Vector3.zero;
        }
    }
}