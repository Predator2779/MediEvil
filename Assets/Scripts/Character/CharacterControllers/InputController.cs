using Character.Classes;

namespace Character.CharacterControllers
{
    public class InputController : Controller
    {
        public InputController(Person person) : base(person)
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