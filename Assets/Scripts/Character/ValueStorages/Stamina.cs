using Character.Classes;
using Character.ValueStorages.Bars;

namespace Character.ValueStorages
{
    public class Stamina : ValueStorage
    {
        public Stamina(Person person, int maxValue) : base(maxValue)
        {
            Person = person;
        }
        public Stamina(Person person, int maxValue, ValueBar bar) : base(maxValue, bar)
        {
            Person = person;
        }

        private Person Person { get; set; }
        public bool CanUse() => CurrentValue > MinValue;
        public bool CanRestore() => CurrentValue < MaxValue;
    }
}