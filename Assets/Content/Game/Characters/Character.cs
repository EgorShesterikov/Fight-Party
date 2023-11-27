using FightParty.Audio;
using FightParty.Game.PlayScene;
using System;
using UnityEngine;

namespace FightParty.Game
{
    [RequireComponent(typeof(Animator), typeof(AudioComponent))]
    public class Character : MonoBehaviour, ITriggerBall, IJumping, IPreparation, IDancing
    {
        private const int MaxHeal = 3;

        private const float BallTriggerTimeRestore = 0.75f;
        private const float SpeedToStop = 1f;

        public event Action Jumped;
        public event Action Prepared;
        public event Action BallTriggered;
        public event Action Danced;

        [SerializeField] private CharacterTypes _type;
        [SerializeField] private Transform _jumpDirection;

        private int _currentHeal = MaxHeal;
        private float _ballTriggerRestore = BallTriggerTimeRestore;

        private bool _isPlayerController = false;
        private BattleAutoControllerData _autoControllerData;

        private CharacterStateMachine _stateMachine;
        private Rigidbody _rigidbody;
        private Animator _animator;
        private AudioComponent _audio;

        public void Initialized(IChangeJoystick changeJoystick)
        {
            _stateMachine = new CharacterStateMachine(this, changeJoystick);
        }

        public int CurrentHeal
        {
            get => _currentHeal;
            set
            {
                if (value < 0 || value > MaxHeal)
                    throw new ArgumentOutOfRangeException(nameof(value));

                _currentHeal = value;
            }
        }

        public Transform JumpDirection => _jumpDirection;
        public bool IsPlayerController => _isPlayerController;
        public BattleAutoControllerData AutoControllerData => _autoControllerData;

        public IStateSwitcher StateSwitcher => _stateMachine;

        public CharacterTypes Type => _type;

        public Rigidbody Rigidbody => _rigidbody;
        public Animator Animator => _animator;
        public AudioComponent Audio => _audio;

        public void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _animator = GetComponent<Animator>();
            _audio = GetComponent<AudioComponent>();
        }

        public void Update()
        {
            if (_stateMachine != null)
                _stateMachine.Tick();

            if (_ballTriggerRestore > 0)
                _ballTriggerRestore -= Time.deltaTime;
        }

        public void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Ball ball))
            {
                if(_ballTriggerRestore <= 0 && ball.IsTriggerMagnitude(Rigidbody) && !ball.IsStopped())
                {
                    BallTriggered?.Invoke();

                    _ballTriggerRestore = BallTriggerTimeRestore;
                }
            }
        }

        public void SetPlayerController()
            => _isPlayerController = true;
        public void SetAutoController(Character targetPlayer, Ball ball)
            => _autoControllerData = new BattleAutoControllerData(targetPlayer, ball);

        public bool IsStopped()
        {
            if (Vector3.Distance(_rigidbody.velocity, Vector3.zero) < SpeedToStop)
            {
                _rigidbody.velocity = Vector3.zero;
                _rigidbody.angularVelocity = Vector3.zero;
                return true;
            }

            return false;
        }

        public void Preparation()
            => Prepared?.Invoke();

        public void Jump()
            => Jumped?.Invoke();

        public void Dance()
            => Danced?.Invoke();

        public void Destroy()
            => Destroy(gameObject);
    }
}