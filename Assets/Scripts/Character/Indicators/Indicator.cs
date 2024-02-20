using Character.Classes;

namespace Character.Indicators
{
    public abstract class Indicator
    {
        protected Person Person { get; set; }

        protected int MinValue { get; set; }
        protected int CurrentValue { get; set; }
        protected int MaxValue { get; set; }

        public virtual void Increase(int value)
        {
            int newValue = CurrentValue + value;
            CurrentValue = newValue < MaxValue ? MaxValue : newValue;
        }

        public virtual void Decrease(int value)
        {
            int newValue = CurrentValue - value;
            CurrentValue = newValue < MinValue ? MinValue : newValue;
        }

        public int GetPercentageRation() => CurrentValue / MaxValue;
    }
}