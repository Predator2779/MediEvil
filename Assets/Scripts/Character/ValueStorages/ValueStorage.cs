using Character.ValueStorages.Bars;

namespace Character.ValueStorages
{
    public abstract class ValueStorage
    {
        public ValueStorage(float maxValue)
        {
            MaxValue = maxValue;
        }

        public ValueStorage(float maxValue, ValueBar bar)
        {
            MaxValue = maxValue;
            Bar = bar;
        }
        
        protected ValueBar Bar { get; }
        public float MinValue { get; } = 0;
        public float CurrentValue { get; private set; }
        public float MaxValue { get; }

        public virtual void Increase(float value)
        {
            float newValue = CurrentValue + value;
            SetValue(newValue > MaxValue ? MaxValue : newValue);
            ChangeBar();
        }

        public virtual void Decrease(float value)
        {
            float newValue = CurrentValue - value;
            SetValue(newValue < MinValue ? MinValue : newValue);
            ChangeBar();
        }

        public void SetValue(float value) => CurrentValue = value;

        private void ChangeBar()
        {
            if (Bar != null) Bar.SetCurrentValue(GetPercentageRation());
        }

        private float GetPercentageRation() => CurrentValue / MaxValue * 100;
    }
}