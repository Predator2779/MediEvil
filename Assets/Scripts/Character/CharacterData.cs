using UnityEngine;

namespace Character
{
    public class CharacterData : ScriptableObject
    {
        [field: SerializeField] public string Name { get; }
        [field: SerializeField] public int SpeedMove { get; }
        [field: SerializeField] public int SpeedRun { get; }
        [field: SerializeField] public int JumpForce { get; }
        [field: SerializeField] public float MaxHealth { get; }
        [field: SerializeField] public float CurrentHealth { get; }
        [field: SerializeField] public float Damage { get; }
    }
}