using Character.Classes;
using Character.ValueStorages.Bars;

namespace Character.ValueStorages
{
    public class Health : ValueStorage
    {
        public Health(Person person, int maxValue) : base(maxValue)
        {
            Person = person;
        }
        public Health(Person person, int maxValue, ValueBar bar) : base(maxValue, bar)
        {
            Person = person;
        }
        
        private Person Person { get; }

        public void TakeHeal(float value) => Increase(value);
        public void TakeDamage(float value)
        {
            base.Decrease(value);
            if (CurrentValue <= MinValue) Person.Die();
        }
    }
}