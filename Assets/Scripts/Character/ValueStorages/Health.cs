using Character.ComponentContainer;
using Character.ValueStorages.Bars;
using Global;
using UnityEngine;

namespace Character.ValueStorages
{
    public class Health : ValueStorage
    {
        public delegate void healthEvent();
        public healthEvent Falldown;
        public healthEvent Die;
        
        public Health(PersonContainer personContainer, float currentValue, float maxValue) : base(currentValue, maxValue) 
        {
            PersonContainer = personContainer;
        }

        public Health(PersonContainer personContainer, float currentValue, float maxValue, ValueBar bar) : base(currentValue, maxValue, bar)
        {
            PersonContainer = personContainer;
        }

        private PersonContainer PersonContainer { get; }
        public bool CanDamage { get; set; } = true;

        public void TakeHeal(float value) => Increase(value);
        public void TakeFullHeal() => Increase(MaxValue);

        public void TakeDamage(float value)
        {
            if (!CanDamage) return;
            
            base.Decrease(value);
            
            // Debug.Log($"DamageL {value}; Current: {CurrentValue}");
            
            if (value >= GlobalConstants.KnockdownDamage) Falldown?.Invoke();
            if (CurrentValue <= MinValue) Die?.Invoke();
        }
    }
}