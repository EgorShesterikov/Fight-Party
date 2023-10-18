using UnityEngine;

namespace FightParty
{
    public class RotationObject : MonoBehaviour
    {
        [SerializeField, Range(0, 10)] private float _rotationSpeed = 5f;

        [SerializeField, Range(-1, 1)] private float _directionX = 1f;
        [SerializeField, Range(-1, 1)] private float _directionY = 1f;
        [SerializeField, Range(-1, 1)] private float _directionZ = 1f;

        private void Update()
            => transform.Rotate(new Vector3(_directionX, _directionY, _directionZ) * _rotationSpeed * Time.deltaTime);
    }
}
