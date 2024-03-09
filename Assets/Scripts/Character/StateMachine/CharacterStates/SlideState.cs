using System.Threading.Tasks;
using Character.Classes;
using Global;
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
        }

        public override void Enter()
        {
            _normal = Person.Movement.ContactNormal;
            IsCompleted = false;
            base.Enter();
        }

        public override void Execute()
        {
            if (!Person.Movement.CanSlide()) Exit();

            base.Execute();
            RotateByNormal();

            if (Person.Movement.Direction.y <= 0) return;
            
            Exit();
            Person.Jump();
        }

        private void RotateByNormal()
        {
            float angle = Mathf.Atan2(_normal.x, _normal.y) * Mathf.Rad2Deg;
            _transform.rotation = Quaternion.Euler(0, 0, -angle);
        }

        public override void Exit()
        {
            _transform.rotation = Quaternion.Euler(0, 0, 0);
            IsCompleted = true;
            IsCooldown = true;
            
            Task.Delay(GlobalConstants.SlideCooldown).ContinueWith(_ => IsCooldown = false);
            base.Exit();
        }
    }
}