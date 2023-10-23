using System;

namespace FightParty.Save
{
    [Serializable]
    public struct SettingsJSON
    {
        public float Music;
        public float SFX;
        public TypesLanguage Language;

        public SettingsJSON(float music, float sfx, TypesLanguage language)
        {
            Music = music;
            SFX = sfx;
            Language = language;
        }
    }
}