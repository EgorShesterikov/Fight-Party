using System;

namespace FightParty.Save
{
    [Serializable]
    public struct ProgressJSON
    {
        public int BattleVictories;
        public int SurvivalTime;

        public int RingIndex;

        public ProgressJSON(int battleVictories, int survivalTime, int ringIndex)
        { 
            BattleVictories = battleVictories;
            SurvivalTime = survivalTime;

            RingIndex = ringIndex;
        }
    }
}
