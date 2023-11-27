using System.Collections.Generic;
using UnityEngine;

namespace FightParty.Game.PlayScene
{
    public class PlayerIndicationView : WindowBase, IHidePlayerIndication
    {
        [SerializeField] private GameObject _yellowIndication;
        [SerializeField] private GameObject _blueIndication;

        [Space]
        [SerializeField] private VariableJoystick _yellowJoystick;
        [SerializeField] private VariableJoystick _blueJoystick;

        [Space]
        [SerializeField] private List<GameObject> _yellowHeals;
        [SerializeField] private List<GameObject> _blueHeals;

        public VariableJoystick YellowJoystick => _yellowJoystick;
        public VariableJoystick BlueJoystick => _blueJoystick;

        public void SetActivYellowJoystic(bool value)
            => _yellowJoystick.gameObject.SetActive(value);
        public void SetActivBlueJoystic(bool value)
            => _blueJoystick.gameObject.SetActive(value);

        public void ChangeHealYellow(int value)
            => _yellowHeals[value].gameObject.SetActive(false);
        public void ChangeHealBlue(int value)
            => _blueHeals[value].gameObject.SetActive(false);

        public void SetActivYellowIndication(bool value)
            => _yellowIndication.SetActive(value);

        public void SetActivBlueIndication(bool value)
            => _blueIndication.SetActive(value);

        public void SetIneterctableYellowJoystick(bool value)
            => _yellowJoystick.IsInterectable(value);

        public void SetIneterctableBlueJoystick(bool value)
            => _blueJoystick.IsInterectable(value);
    }
}