using FightParty.Audio;
using System;
using UnityEngine;

namespace FightParty.Game
{
    [RequireComponent(typeof(Rigidbody), typeof(AudioComponent))]
    public abstract class Ball : MonoBehaviour
    {
        private const float IsMoveInaccuracy = 0.25f;
        private const float IsjumpInaccuracy = 2.15f;
        private const float SpeedToStop = 1f;

        private const float TimeSoundRestore = 0.25f;

        private const float MaxScaleChange = 1.1f;
        private const float ScaleCoefficient = 2;

        [SerializeField] private float MaxValueMagnitudeFromTrigger = 5f;
        [SerializeField] private ConfigurableJoint _springPrefab;

        private Vector3 _savePosition;

        private ConfigurableJoint _spring;
        private Transform _model;

        private Rigidbody _rigidbody;

        protected AudioComponent _audioComponent;
        private float _currentTimeSoundRestore;

        public Rigidbody Rigidbody => _rigidbody;

        public bool IsStopped()
        {
            if (Vector3.Distance(_rigidbody.velocity, Vector3.zero) < SpeedToStop
                && transform.position.y < IsjumpInaccuracy)
                return true;

            return false;
        }

        public bool IsMoved()
        {
            if (Vector3.Distance(transform.position, _savePosition) < IsMoveInaccuracy)
                return true;

            return false;
        }

        public void SetFreezing(bool value)
        {
            if (value == true)
                _rigidbody.constraints = RigidbodyConstraints.FreezeAll;
            else
                _rigidbody.constraints = RigidbodyConstraints.None;
        }

        public bool IsTriggerMagnitude(Rigidbody obj)
        {            
            if(Rigidbody.velocity.magnitude - obj.velocity.magnitude > MaxValueMagnitudeFromTrigger)
                return true;
            else
                return false;
        }

        protected virtual void OnTriggerEnter(Collider other)
            => PlayHitSound();

        private void Awake()
        {
            _audioComponent = GetComponent<AudioComponent>();

            _rigidbody = GetComponent<Rigidbody>();

            _model = transform.GetChild(0);

            _spring = Instantiate(_springPrefab, _model.transform.position, Quaternion.identity);
            _spring.connectedBody = _rigidbody;

            _savePosition = transform.position;
        }

        private void Update()
        {
            ApplicationElasticity();

            if (_currentTimeSoundRestore > 0)
                _currentTimeSoundRestore -= Time.deltaTime;
        }

        private void ApplicationElasticity()
        {
            float interpolantHorizontal = Vector3.Distance(_model.transform.position, _spring.transform.position) * ScaleCoefficient;
            Vector3 scaleHorizontal = Vector3.LerpUnclamped(Vector3.one, Vector3.one * MaxScaleChange, interpolantHorizontal);

            _model.transform.localScale = scaleHorizontal;
        }

        private void PlayHitSound()
        {
            if (_currentTimeSoundRestore > 0)
                return;

            _currentTimeSoundRestore = TimeSoundRestore;
            _audioComponent.PlaySound(0);
        }
    }
}