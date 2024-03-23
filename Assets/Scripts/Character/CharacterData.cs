using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace Character
{
    [CreateAssetMenu(menuName = "CharacterData", fileName = "New CharacterData", order = 0)]
    public class CharacterData : ScriptableObject
    {
        [Header("About")] [Space]
        public string Name;
        [Space] [Header("Speed")] 
        public float SpeedMove;
        public float SpeedRun;
        public float JumpForce;
        public float FallSpeed;
        public float RollForce;
        public float SlideLimitVelocity;
        public float SlideSpeed;

        [Space] [Header("Parameters")] [Header("Health")]
        public int MaxHealth;

        public int CurrentHealth;
        [Header("Stamina")] public int MaxStamina;
        public int CurrentStamina;
        public float StaminaRecovery;
        public float StaminaUsage;
        [Tooltip("Millisecond")] public int StaminaRestoreDelay;
        [Header("Mana")] public int MaxMana;
        public int CurrentMana;
        public float ManaUsage;
        [Header("Damage")] public float Damage;
        [Header("Death")] public List<Transform> SavePoints;
        [Tooltip("Millisecond")] public int TimeToRespawn;
    }
}