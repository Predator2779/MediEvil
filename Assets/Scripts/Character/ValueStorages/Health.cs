using Character.Classes;
using Character.ValueStorages.Bars;
using Global;
using UnityEngine;

namespace Character.ValueStorages
{
    public class Health : ValueStorage
    {
        public Health(Person person, float currentValue, float maxValue) : base(currentValue, maxValue) 
        {
            Person = person;
        }

        public Health(Person person, float currentValue, float maxValue, ValueBar bar) : base(currentValue, maxValue, bar)
        {
            Person = person;
        }

        private Person Person { get; }

        public void TakeHeal(float value) => Increase(value);
        public void TakeFullHeal() => Increase(MaxValue);

        public void TakeDamage(float value)
        {
            // Debug.Log(value);
            base.Decrease(value);
            if (value >= GlobalConstants.KnockdownDamage) Person.FallDown();
            if (CurrentValue <= MinValue) Person.Die();
        }
    }
}