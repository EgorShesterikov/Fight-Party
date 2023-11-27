namespace FightParty.Game.PlayScene
{
    public interface IHidePlayerIndication
    {
        void SetActivYellowJoystic(bool value);
        void SetActivBlueJoystic(bool value);

        void SetActivYellowIndication(bool value);
        void SetActivBlueIndication(bool value);

        void SetIneterctableYellowJoystick(bool value);
        void SetIneterctableBlueJoystick(bool value);
    }
}