using System.Threading.Tasks;
using Character.Classes;
using Global;
using UnityEngine;

namespace Character.StateMachine.CharacterStates
{
    public class SlideState : TiredState
    {
        private Transform _transform;
        private Quaternion _prevQuaternion;
        private Vector2 _normal;

        public SlideState(Person person) : base(person)
        {
            Animation = "slide";
            _transform = Person.transform;
        }

        public override void Enter()
        {
            _normal = Person.Movement.ContactNormal;
            _prevQuaternion = _transform.rotation;
            
            Person.Movement.Slide();
            IsCompleted = false;
            base.Enter();
        }

        public override void Execute()
        {
            Person.Movement.SetSideByVelocity();
            
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
            var rot = _transform.rotation.eulerAngles;
            _transform.rotation = Quaternion.Euler(rot.x, rot.y, -angle);
        }

        public override void Exit()
        {
            _transform.rotation = Quaternion.Euler(_transform.rotation.x, _transform.rotation.y, _prevQuaternion.z);
            IsCompleted = true;
            IsCooldown = true;
            
            Task.Delay(GlobalConstants.SlideCooldown).ContinueWith(_ => IsCooldown = false);
        }
    }
}