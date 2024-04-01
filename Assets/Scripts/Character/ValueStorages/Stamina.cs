using System.Threading.Tasks;
using Character.Classes;
using Character.ValueStorages.Bars;

namespace Character.ValueStorages
{
    public class Stamina : ValueStorage
    {
        public bool CanUse { get; private set; }  = true;
        private Person Person { get; }

        private bool _restoreIsDelayed;

        public Stamina(Person person, float currentValue, float maxValue) : base(currentValue, maxValue) 
        {
            Person = person;
        }

        public Stamina(Person person, float currentValue, float maxValue, ValueBar bar) : base(currentValue, maxValue, bar)
        {
            Person = person;
        }

        public override void Increase(float value)
        {
            if (_restoreIsDelayed) return;
            if (CurrentValue > MaxValue / 4)  CanUse = true;
            base.Increase(value);
        }

        public override void Decrease(float value)
        {
            if (!CanUse) return;
            
            base.Decrease(value);

            if (CurrentValue > MinValue) return;
            
            CanUse = false;
            _restoreIsDelayed = true;
                 
            Task.Delay(Person.Config.StaminaRestoreDelay).ContinueWith(_ => { CanUse = true; _restoreIsDelayed = false; });
        }

        public bool CanRestore() => CurrentValue < MaxValue && !_restoreIsDelayed;
    }
}