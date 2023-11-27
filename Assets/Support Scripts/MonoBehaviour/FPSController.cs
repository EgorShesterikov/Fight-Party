using UnityEngine;

namespace FightParty
{
    public class FPSController : MonoBehaviour
    {
        [SerializeField] private int targerFPS = 60;

        private void Awake()
            => Application.targetFrameRate = targerFPS;
    }
}