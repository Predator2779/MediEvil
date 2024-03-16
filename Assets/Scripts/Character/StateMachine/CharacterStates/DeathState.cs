using System.Threading.Tasks;
using Character.Classes;
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

            Person.Movement.SetBodyType(RigidbodyType2D.Static);
            if (!Person.IsPlayer) Person.gameObject.SetActive(false);
            _isDeath = true;

            Task.Delay(Person.Data.TimeToRespawn).ContinueWith(_ => _isRespawned = true);
        }

        private void Respawn()
        {
            Person.Movement.SetBodyType(RigidbodyType2D.Dynamic);
            IsCompleted = true;
            _isDeath = false;
            _isRespawned = false;
            Person.transform.position = Person.Data.SpawnPoint;
            Person.Idle();
        }
    }
}