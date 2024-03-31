using Character.ValueStorages.Bars;

namespace Character.ValueStorages
{
    public abstract class ValueStorage
    {
        protected ValueStorage(float currentValue, float maxValue)
        {
            CurrentValue = currentValue;
            MaxValue = maxValue;
        }

        protected ValueStorage(float currentValue, float maxValue, ValueBar bar)
        {
            CurrentValue = currentValue;
            MaxValue = maxValue;
            Bar = bar;
        }

        private ValueBar Bar { get; }
        protected float MinValue { get; } = 0;
        protected float CurrentValue { get; private set; }
        public float MaxValue { get; }

        public virtual void Increase(float value)
        {
            var newValue = CurrentValue + value;
            SetValue(newValue > MaxValue ? MaxValue : newValue);
            ChangeBar();
        }

        public virtual void Decrease(float value)
        {
            var newValue = CurrentValue - value;
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