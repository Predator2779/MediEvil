namespace Character.Indicators
{
    public class Stamina : Indicator
    {
        public bool CanUse() => CurrentValue > MinValue;
    }
}