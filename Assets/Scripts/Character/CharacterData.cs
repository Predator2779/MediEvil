using UnityEngine;

namespace Character
{
    [CreateAssetMenu(menuName = "CharacterData", fileName = "New CharacterData", order = 0)]
    public class CharacterData : ScriptableObject
    {
        public string Name;
        public int SpeedMove;
        public int SpeedRun;
        public int JumpForce;
        public int RollDistance;
        public float MaxHealth;
        public float CurrentHealth;
        public float Damage;
    }
}