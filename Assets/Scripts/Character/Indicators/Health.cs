using Character.Classes;

namespace Character.Indicators
{
    public class Health : Indicator
    {
        public Health(Person person)
        {
            Person = person;
        }

        public override void Decrease(int value)
        {
            base.Decrease(value);
            if (CurrentValue <= MinValue) Person.Die(); 
        }
    }
}