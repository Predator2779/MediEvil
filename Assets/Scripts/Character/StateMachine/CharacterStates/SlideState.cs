using Character.Classes;
using UnityEngine;

namespace Character.StateMachine.CharacterStates
{
    public class SlideState : CharacterState
    {
        private Transform _transform;
        private Vector2 _normal;
        public SlideState(Person person) : base(person)
        {
            Animation = "slide";
            _transform = Person.GetComponent<Transform>();
            _normal = Person.Movement.ContactNormal;////
        }

        public override void Execute()
        {
            base.Execute();
            float angle = Mathf.Atan2(_normal.x, _normal.y) * Mathf.Rad2Deg;
            _transform.rotation = Quaternion.Euler(0, 0, -angle);
        }

        public override void Exit()
        {
            _transform.rotation = Quaternion.Euler(0, 0, 0);
            base.Exit();
        }
    }
}