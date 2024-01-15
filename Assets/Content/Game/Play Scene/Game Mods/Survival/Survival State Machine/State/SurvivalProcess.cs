using UnityEngine;

namespace FightParty.Game.PlayScene.Survival
{
    public class SurvivalProcess : SurvivalState
    {
        private const float JumpRechargeTime = 1.25f;

        private bool _isCharacterJumpReady;
        private float _currentJumpRechargeTime;

        private float _currentSpawnDestroyBallRechargeTime;

        private IReaderJoystick _readerJoystick;
        private SurvivalTimeIndication _timeIndication;
        private BallSpawner _ballSpawner;
        private IHidePlayerIndication _hidePlayerIndication;

        public SurvivalProcess(IStateSwitcher stateSwitcher, SurvivalStateMachineData data,
            IReaderJoystick readerJoystick, SurvivalTimeIndication timeIndication, BallSpawner ballSpawner, 
            IHidePlayerIndication hidePlayerIndication) 
            : base(stateSwitcher, data)
        {
            _readerJoystick = readerJoystick;
            _timeIndication = timeIndication;
            _ballSpawner = ballSpawner;
            _hidePlayerIndication = hidePlayerIndication;
        }

        public override void Enter()
        {
            _readerJoystick.EndChangedPosition += StartJumpCharacter;

            Data.SelectCharacterPlayer.BallTriggered += TakeDamageCharacter;

            Data.SelectCharacterPlayer.Preparation();
            _isCharacterJumpReady = true;
        }

        public override void Exit()
        {
            _readerJoystick.EndChangedPosition -= StartJumpCharacter;

            Data.SelectCharacterPlayer.BallTriggered -= TakeDamageCharacter;
        }

        public override void Update()
        {
            _timeIndication.UpdateSecond();

            if (!_isCharacterJumpReady)
            {
                if (_currentJumpRechargeTime > 0)
                    _currentJumpRechargeTime -= Time.deltaTime;
                else if (Data.SelectCharacterPlayer.IsStopped())
                {
                    Data.SelectCharacterPlayer.Preparation();
                    _isCharacterJumpReady = true;

                    ChangeInteractableJoystick(true);
                }
            }

            if (_currentSpawnDestroyBallRechargeTime > 0)
                _currentSpawnDestroyBallRechargeTime -= Time.deltaTime;
            else
                SpawnDestroyBall();

            if (Data.SelectCharacterPlayer.CurrentHeal == 0)
                StateSwitcher.SwitchState<SurvivalResults>();
        }

        private void StartJumpCharacter()
        {
            if (!_isCharacterJumpReady)
                return;

            Data.SelectCharacterPlayer.Jump();
            _isCharacterJumpReady = false;

            ChangeInteractableJoystick(false);

            _currentJumpRechargeTime = JumpRechargeTime;
        }

        private void TakeDamageCharacter()
        {
            if (Data.SelectCharacterPlayer.CurrentHeal == 0)
                return;

            _isCharacterJumpReady = false;

            ChangeInteractableJoystick(false);

            _currentJumpRechargeTime = JumpRechargeTime;
        }

        private void ChangeInteractableJoystick(bool value)
        {
            if(Data.SelectCharacterPlayer.Type == CharacterTypes.First)
                _hidePlayerIndication.SetIneterctableFirstJoystick(value);
            else
                _hidePlayerIndication.SetIneterctableSecondJoystick(value);
        }

        private void SpawnDestroyBall()
        {
            _ballSpawner.SpawnDestroyBallInSky();

            _currentSpawnDestroyBallRechargeTime = GetRandomSpawnTime();
        }

        private float GetRandomSpawnTime()
        {
            if(_timeIndication.CurrentSecond < 15)
                return Random.Range(0.8f, 1f);
            else if (_timeIndication.CurrentSecond < 30)
                return Random.Range(0.6f, 0.8f);
            else if (_timeIndication.CurrentSecond < 60)
                return Random.Range(0.5f, 0.6f);
            else if (_timeIndication.CurrentSecond < 120)
                return Random.Range(0.4f, 0.5f);
            else
                return Random.Range(0.2f, 0.4f);
        }
    }
}