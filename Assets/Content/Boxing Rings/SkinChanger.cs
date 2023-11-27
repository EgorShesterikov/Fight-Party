using FightParty.Save;
using System;

namespace FightParty.Game
{
    public class SkinChanger
    {
        private int _indexCurrentSkin;

        private SkinChangerConfig _config;

        private ProgressManager _progressManager;

        public SkinChanger(SkinChangerConfig config, ProgressManager progressManager)
        {
            _config = config;

            _progressManager = progressManager;

            ProgressJSON progressJSON = _progressManager.Load();

            switch(progressJSON.RingIndex)
            {
                case 0:
                    SetDefaultSkin();
                    break;

                case 1:
                    SetBattleSkin();
                    break;

                case 2:
                    SetSurvivalSkin();
                    break;

                default:
                    throw new NotImplementedException();
            }
        }

        public int IndexCurrentSkin => _indexCurrentSkin;

        public bool SetDefaultSkin()
        {
            _indexCurrentSkin = 0;

            ProgressJSON progressJSON = _progressManager.Load();

            _config.TargetMaterial.mainTexture = _config.DefaultTexture;

            progressJSON.RingIndex = _indexCurrentSkin;
            _progressManager.Save(progressJSON);

            return true;
        }

        public bool SetBattleSkin()
        {
            _indexCurrentSkin = 1;

            ProgressJSON progressJSON = _progressManager.Load();

            if (progressJSON.BattleVictories >= 10)
            {
                _config.TargetMaterial.mainTexture = _config.BattleTexture;

                progressJSON.RingIndex = _indexCurrentSkin;
                _progressManager.Save(progressJSON);

                return true;
            }
            else
            {
                _config.TargetMaterial.mainTexture = _config.CloseTexture;
                return false;
            }
        }

        public bool SetSurvivalSkin()
        {
            _indexCurrentSkin = 2;

            ProgressJSON progressJSON = _progressManager.Load();

            if (progressJSON.SurvivalTime >= 120)
            {
                _config.TargetMaterial.mainTexture = _config.SurvivalTexture;

                progressJSON.RingIndex = _indexCurrentSkin;
                _progressManager.Save(progressJSON);

                return true;
            }
            else
            {
                _config.TargetMaterial.mainTexture = _config.CloseTexture;
                return false;
            }
        }

        public bool IsCloseTexture()
            => _config.TargetMaterial.mainTexture == _config.CloseTexture;
    }
}
