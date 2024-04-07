using System.Collections.Generic;
using System.Threading.Tasks;
using Character.Classes;
using Character.ComponentContainer;
using Global;
using UnityEngine;

namespace Character.StateMachine.CharacterStates
{
    public class DeathState : CharacterState
    {
        private Person _person;
        private bool _isDeath;
        private bool _isRespawned;

        public DeathState(Person person) : base(person.Container)
        {
            Animation = "death";
            _person = person;
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

            _person.Describe();
            PersonContainer.Movement.SetBodyType(RigidbodyType2D.Static);
            
            if (!PersonContainer.IsPlayer)
            {
                PersonContainer.gameObject.SetActive(false);
                return;
            }

            Task.Delay(PersonContainer.Config.TimeToRespawn).ContinueWith(_ => _isRespawned = true);
        }

        private void Respawn()  //// вынести в отдельный класс
        {
            PersonContainer.Movement.SetBodyType(RigidbodyType2D.Dynamic);
            IsCompleted = true;
            _isDeath = false;
            _isRespawned = false;
            
            PersonContainer.transform.position = GetNearestPoint(PersonContainer.Config.SavePoints);
            PersonContainer.Health.TakeFullHeal();

            // PersonContainer.Idle(); удалить
        }

        private Vector2 GetNearestPoint(List<Transform> points) // пока что.
        {
            if (points == null) return GlobalConstants.StartPointPosition;
            
            var length = points.Count;
            var position = PersonContainer.transform.position;
            var point = GlobalConstants.StartPointPosition;
            var distance = Vector2.Distance(position, point);

            for (int i = 0; i < length; i++)
            {
                var newPoint = points[i].position;
                var newDistance = Vector2.Distance(position, newPoint);
                
                if (newDistance > distance) continue;
                
                point = newPoint;
                distance = newDistance;
            }

            return point;
        }
    }
}