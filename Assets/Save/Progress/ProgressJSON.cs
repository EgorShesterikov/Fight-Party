using System;

namespace FightParty.Save
{
    [Serializable]
    public struct ProgressJSON
    {
        public int BattleRating;
        public int SurvivalTime;

        public int RingIndex;

        public ProgressJSON(int battleRaing, int survivalTime, int ringIndex)
        { 
            BattleRating = battleRaing;
            SurvivalTime = survivalTime;

            RingIndex = ringIndex;
        }
    }
}
