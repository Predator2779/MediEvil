using System.Collections.Generic;
using System.Threading.Tasks;
using Character.Classes;
using Global;
using UnityEngine;

namespace Character.StateMachine.CharacterStates
{
    public class DeathState : CharacterState
    {
        private bool _isDeath;
        private bool _isRespawned;

        public DeathState(Person person) : base(person)
        {
            Animation = "death";
        }

        public override void Enter()
        {
            base.Enter();
            IsCompleted = false;
        }

        public override void Execute()
        {
            if (AnimationCompleted()) Die();
            if (_isRespawned) Respawn();
        }

        public override void FixedExecute()
        {
        }

        private void Die()
        {
            if (_isDeath) return;

            _isDeath = true;
            
            Person.Movement.SetBodyType(RigidbodyType2D.Static);
            
            if (!Person.IsPlayer)
            {
                Person.gameObject.SetActive(false);
                return;
            }

            Task.Delay(Person.Data.TimeToRespawn).ContinueWith(_ => _isRespawned = true);
        }

        private void Respawn()
        {
            Person.Movement.SetBodyType(RigidbodyType2D.Dynamic);
            IsCompleted = true;
            _isDeath = false;
            _isRespawned = false;
            
            Person.transform.position = GetNearestPoint(Person.Data.SavePoints);
            Person.Health.TakeFullHeal();
            Person.Idle();
        }

        private Vector2 GetNearestPoint(List<Transform> points) // пока что.
        {
            if (points == null) return GlobalConstants.StartPointPosition;
            
            var length = points.Count;
            var position = Person.transform.position;
            var point = points[0].position;
            var value = Vector2.Distance(position, points[0].position);

            for (int i = 1; i < length; i++)
            {
                var newValue = Vector2.Distance(position, points[i].position);
                if (!(newValue < value)) continue;
                point = points[i].position;
                value = newValue;
            }

            return point;
        }
    }
}