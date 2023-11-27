using System;
using UnityEngine;

namespace FightParty.Game.PlayScene
{
    public class PlayerIndication : IDisposable, ISelectJoysticks, IChangeJoystick
    {
        public event Action SelectedYellowJoystick;
        public event Action SelectedBlueJoystick;

        public event Action<Vector2> ChangedJoystick;
        public event Action EndChangedJoystick;

        private VariableJoystick _selectJoystick;

        private PlayerIndicationView _view;

        private ITriggerBall _yellowCharacter;
        private ITriggerBall _blueCharacter;

        private int _currentHealYellow = 3;
        private int _currentHealBlue = 3;

        public PlayerIndication(PlayerIndicationView view, ITriggerBall yellowCharacter, ITriggerBall blueCharacter)
        {
            _view = view;

            _view.YellowJoystick.OnChanged += SelectYellowJoystick;
            _view.BlueJoystick.OnChanged += SelectBlueJoystick;

            _view.YellowJoystick.OnEndChanged += EndChangeJoystick;
            _view.BlueJoystick.OnEndChanged += EndChangeJoystick;

            _yellowCharacter = yellowCharacter;
            _blueCharacter = blueCharacter;

            _yellowCharacter.BallTriggered += TakeDamageYellow;
            _blueCharacter.BallTriggered += TakeDamageBlue;
        }

        public IHidePlayerIndication View => _view;

        public void Dispose()
        {
            _view.YellowJoystick.OnChanged -= SelectYellowJoystick;
            _view.BlueJoystick.OnChanged -= SelectBlueJoystick;

            _view.YellowJoystick.OnEndChanged -= EndChangeJoystick;
            _view.BlueJoystick.OnEndChanged -= EndChangeJoystick;

            _view.YellowJoystick.OnChanged -= ChangeJoystick;
            _view.BlueJoystick.OnChanged -= ChangeJoystick;

            _yellowCharacter.BallTriggered -= TakeDamageYellow;
            _blueCharacter.BallTriggered -= TakeDamageBlue;
        }

        private void SelectYellowJoystick()
        {
            SelectedYellowJoystick?.Invoke();

            _view.YellowJoystick.OnChanged += ChangeJoystick;

            _selectJoystick = _view.YellowJoystick;
        }
        private void SelectBlueJoystick()
        {
            SelectedBlueJoystick?.Invoke();

            _view.BlueJoystick.OnChanged += ChangeJoystick;

            _selectJoystick = _view.BlueJoystick;
        }

        private void ChangeJoystick()
        {
            if(_selectJoystick != null)
                ChangedJoystick?.Invoke(_selectJoystick.Direction);
        }

        private void EndChangeJoystick()
        {
            if (_selectJoystick != null)
                EndChangedJoystick?.Invoke();
        }

        private void TakeDamageYellow()
        {
            if (_currentHealYellow <= 0)
                return;

            _currentHealYellow--;
            _view.ChangeHealYellow(_currentHealYellow);
        }
        private void TakeDamageBlue()
        {
            if (_currentHealBlue <= 0)
                return;

            _currentHealBlue--;
            _view.ChangeHealBlue(_currentHealBlue);
        }
    }
}