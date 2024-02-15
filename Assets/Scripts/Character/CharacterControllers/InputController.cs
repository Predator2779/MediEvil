using Character.Classes;
using Input;

namespace Character.CharacterControllers
{
    public class InputController : Controller
    {
        public InputController(Person2 person) : base(person)
        {
        }

        public override void Execute()
        {
            base.Execute();
            
            CheckInput();
        }

        private void CheckInput()
        {
            // if (InputHandler.GetShiftBtn()) Person.Jump();
        }
    }
}