using UnityEngine;

namespace FightParty.Game
{
    public class DestroyBall : Ball
    {
        private const string GroundTag = "Ground";

        [SerializeField] private ParticleSystem _destroyEffect;

        private const float TimeToDestroy = 0.25f;

        protected override void OnTriggerEnter(Collider other)
        {
            base.OnTriggerEnter(other);

            if (other.CompareTag(GroundTag))
            {
                Invoke(nameof(SpawnDestroyEffect), TimeToDestroy);
                Destroy(gameObject, TimeToDestroy);
            }
            else if (other.TryGetComponent(out Character character))
            {
                SpawnDestroyEffect();
                Destroy(gameObject);
            }
        }

        private void SpawnDestroyEffect()
            => Instantiate(_destroyEffect, transform.position, Quaternion.identity);
    }
}