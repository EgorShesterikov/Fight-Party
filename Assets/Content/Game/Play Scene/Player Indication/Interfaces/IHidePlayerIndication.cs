namespace FightParty.Game.PlayScene
{
    public interface IHidePlayerIndication
    {
        void SetActivFirstJoystick(bool value);
        void SetActivSecondJoystick(bool value);

        void SetActivFirstIndication(bool value);
        void SetActivSecondIndication(bool value);

        void SetIneterctableFirstJoystick(bool value);
        void SetIneterctableSecondJoystick(bool value);
    }
}