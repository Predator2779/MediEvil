using Character.ValueStorages.Bars;
using UnityEngine;

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
        protected float MaxValue { get; }

        public virtual void Increase(float value)
        {
            CurrentValue = Mathf.Clamp(CurrentValue + value, CurrentValue, MaxValue);
            ChangeBar();
        }

        public virtual void Decrease(float value)
        {
            CurrentValue = Mathf.Clamp(CurrentValue - value, MinValue, CurrentValue);
            ChangeBar();
        }

        private void ChangeBar()
        {
            if (Bar != null) Bar.SetCurrentValue(GetPercentageRation());
        }

        public float GetPercentageRation() => CurrentValue / MaxValue * 100;
    }
}