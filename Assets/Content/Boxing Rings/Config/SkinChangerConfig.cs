using UnityEngine;

namespace FightParty.Game
{
    [CreateAssetMenu(fileName = "SkinChangerConfig", menuName = "Skin/SkinChangerConfig")]
    public class SkinChangerConfig : ScriptableObject
    {
        [SerializeField] private Material _targetMaterial;

        [Space]
        [SerializeField] private Texture2D _closeTexture;
        [SerializeField] private Texture2D _defaultTexture;
        [SerializeField] private Texture2D _battleTexture;
        [SerializeField] private Texture2D _survivalTexture;

        public Texture2D CloseTexture => _closeTexture;
        public Texture2D DefaultTexture => _defaultTexture;
        public Texture2D BattleTexture => _battleTexture;
        public Texture2D SurvivalTexture => _survivalTexture;

        public Material TargetMaterial => _targetMaterial;
    }
}
