using Character.Classes;

namespace Character.CharacterControllers
{
    public interface IController
    {
        public void Initialize();
        public void Execute();
        public void FixedExecute();
    }
}