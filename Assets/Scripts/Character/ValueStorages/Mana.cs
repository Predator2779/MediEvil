using Character.Classes;
using Character.ValueStorages.Bars;

namespace Character.ValueStorages
{
    public class Mana : Stamina
    {
        public Mana(Person person, float currentValue, float maxValue) : base(person, currentValue, maxValue) 
        {
        }

        public Mana(Person person, float currentValue, float maxValue, ValueBar bar) : base(person, currentValue, maxValue, bar)
        {
        }
    }
}