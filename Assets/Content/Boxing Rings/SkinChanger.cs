using FightParty.Save;
using System;

namespace FightParty.Game
{
    public partial class SkinChanger
    {
        private int _indexCurrentSkin;

        private SkinChangerConfig _config;

        private ProgressManager _progressManager;

        public SkinChanger(SkinChangerConfig config, ProgressManager progressManager)
        {
            _config = config;

            _progressManager = progressManager;

            ProgressJSON progressJSON = _progressManager.Load();
            SetSkin((RingSkinTypes)progressJSON.RingIndex);
        }

        public int IndexCurrentSkin => _indexCurrentSkin;

        public bool SetSkin(RingSkinTypes skinType)
        {
            _indexCurrentSkin = (int)skinType;

            bool isChange = false;
            ProgressJSON progressJSON = _progressManager.Load();

            switch (skinType)
            {
                case RingSkinTypes.Default:

                    _config.TargetMaterial.mainTexture = _config.DefaultTexture;
                    isChange = true;

                    break;

                case RingSkinTypes.Battle:

                    if (progressJSON.BattleVictories >= 10)
                    {
                        _config.TargetMaterial.mainTexture = _config.BattleTexture;
                        isChange = true;
                    }

                    break;

                case RingSkinTypes.Survival:

                    if (progressJSON.SurvivalTime >= 120)
                    {
                        _config.TargetMaterial.mainTexture = _config.SurvivalTexture;
                        isChange = true;
                    }

                    break;
            }

            if (isChange)
            {
                progressJSON.RingIndex = _indexCurrentSkin;
                _progressManager.Save(progressJSON);
            }
            else
            {
                _config.TargetMaterial.mainTexture = _config.CloseTexture;
            }

            return isChange;
        }

        public bool IsCloseTexture()
            => _config.TargetMaterial.mainTexture == _config.CloseTexture;
    }
}
