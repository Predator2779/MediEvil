using UnityEngine;

namespace Character
{
    [CreateAssetMenu(menuName = "CharacterData", fileName = "New CharacterData", order = 0)]
    public class CharacterData : ScriptableObject
    {
        [Header("About")]
        public string Name;
        [Space][Header("Speed")]
        public int SpeedMove;
        public int SpeedRun;
        public int JumpForce;
        public int RollDistance;
        [Space][Header("Parameters")]
        [Header("Health")]
        public int MaxHealth;
        public int CurrentHealth;
        [Header("Stamina")]
        public int MaxStamina;
        public int CurrentStamina;
        public float StaminaRecovery;
        public float StaminaUsage;
        [Tooltip("Millisecond")]
        public int StaminaRestoreDelay;
        [Header("Mana")]
        public int MaxMana;
        public int CurrentMana;
        public float ManaUsage;
        [Header("Damage")]
        public float Damage;
    }
}