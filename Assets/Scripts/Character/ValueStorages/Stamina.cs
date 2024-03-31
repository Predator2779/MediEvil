using System.Threading.Tasks;
using Character.Classes;
using Character.ValueStorages.Bars;

namespace Character.ValueStorages
{
    public class Stamina : ValueStorage
    {
        public Stamina(Person person, float currentValue, float maxValue) : base(currentValue, maxValue) 
        {
            Person = person;
        }

        public Stamina(Person person, float currentValue, float maxValue, ValueBar bar) : base(currentValue, maxValue, bar)
        {
            Person = person;
        }

        private bool _cooldown;
        private bool _cooldownRestore;

        public override void Increase(float value)
        {
            if (_cooldownRestore)
            {
                Task.Delay(Person.Data.StaminaRestoreDelay).ContinueWith(_ => { _cooldownRestore = false; });
                return;
            }

            if (_cooldown && CurrentValue > MaxValue / 4)  _cooldown = false;
            base.Increase(value);
        }

        public override void Decrease(float value)
        {
            if (CurrentValue <= MinValue)
            {
                _cooldown = true;
                _cooldownRestore = true;
            }

            base.Decrease(value);
        }

        private Person Person { get; }
        public bool CanUse() => !_cooldown;
        public bool CanRestore() => CurrentValue < MaxValue;
    }
}