using UnityEngine;

namespace FightParty.Game
{
    public class DefaultBall : Ball
    {
        private const float MultiplyDopAddForce = 100f;

        protected override void OnTriggerEnter(Collider other)
        {
            base.OnTriggerEnter(other);

            if (other.TryGetComponent(out Character character))
                Rigidbody.AddForce(Rigidbody.velocity.normalized * MultiplyDopAddForce);
            else
                Rigidbody.AddForce(Rigidbody.velocity.normalized * MultiplyDopAddForce);
        }
    }
}