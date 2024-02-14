using Character.Classes;
using Input;

namespace Character.CharacterControllers
{
    public class InputController : Controller
    {
        public InputHandler InputHandler { get; }

        public InputController(Person2 person, InputHandler inputHandler) : base(person)
        {
            InputHandler = inputHandler;
        }

        public override void Execute()
        {
            base.Execute();
            
            CheckInput();
        }

        private void CheckInput()
        {
            if (InputHandler.GetShiftBtn()) Person.Jump();
        }
    }
}