using Character.Classes;
using Character.ValueStorages.Bars;

namespace Character.ValueStorages
{
    public class Mana : Stamina
    {
        public Mana(Person person, int maxValue) : base(person, maxValue)
        {
        }
        public Mana(Person person, int maxValue, ValueBar bar) : base(person, maxValue, bar)
        {
        }
    }
}