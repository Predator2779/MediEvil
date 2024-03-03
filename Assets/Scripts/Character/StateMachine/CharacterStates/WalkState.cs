using Character.Classes;

namespace Character.StateMachine.CharacterStates
{
    public class WalkState : CharacterState
    {
        public WalkState(Person person) : base(person)
        {
            Animation = "walk";
        }
        
        public override void Execute()
        {
            Person.SpriteRenderer.flipX = Person.Movement.Direction.x < 0;
        }

        public override void FixedExecute()
        {
            base.FixedExecute();
            if (Person.Movement.IsGrounded()) Person.Movement.Walk();
        }
    }
}