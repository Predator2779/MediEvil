namespace Character.CharacterControllers
{
    public interface IController
    {
        protected void Initialize();
        protected void Execute();
        protected void FixedExecute();
    }
}