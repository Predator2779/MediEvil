using System.Collections;
using Character.Classes;
using Input;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

namespace Character.CharacterControllers.Inputs
{
    public sealed class InputController : Controller
    {
        private InputHandler _inputHandler;
        private Warrior _warrior;
        private bool _canCombo;

        private CompositeDisposable _disposables;

        private void OnDisable()
        {
            foreach (var d in _disposables) d?.Dispose();
            _disposables.Clear();
        }

        protected override void Initialize()
        {
            base.Initialize();
            _inputHandler = new InputHandler();
            _warrior = GetComponent<Warrior>();

            Subscribe();
        }

        private void Subscribe()
        {
            this.UpdateAsObservable()
                .Where(_ => !IsAttack())
                .Where(_ => !IsDefense())
                .Where(_ => !IsFall())
                .Where(_ => !IsWalk())
                .Where(_ => !IsRun())
                .Where(_ => !IsJump())
                .Where(_ => !IsSlide())
                .Where(_ => !IsRoll())
                .Subscribe(_ => { Idle(); });
            
            this.UpdateAsObservable()
                .Where(_ => IsAttack())
                .Subscribe(_ => { Attack(); });

            this.UpdateAsObservable()
                .Where(_ => IsWalk() && !IsRun())
                .Subscribe(_ => { Walk(); });

            this.UpdateAsObservable()
                .Where(_ => IsWalk() && IsRun())
                .Subscribe(_ => { Run(); });

            this.UpdateAsObservable()
                .Where(_ => IsFall())
                .Subscribe(_ => { Fall(); });

            this.UpdateAsObservable()
                .Where(_ => IsJump())
                .Subscribe(_ => { Jump(); });

            this.UpdateAsObservable()
                .Where(_ => IsSlide())
                .Subscribe(_ => { Slide(); });

            this.UpdateAsObservable()
                .Where(_ => IsDefense())
                .Subscribe(_ => { Defense(); });

            this.UpdateAsObservable()
                .Where(_ => IsRoll())
                .Subscribe(_ => { Roll(); });
        }

        protected override void Execute()
        {
            base.Execute();
            SetTempDirection(GetDirection());
        }
        
        private Vector2 GetDirection() => new Vector2(
            _inputHandler.GetHorizontalAxis(),
            _inputHandler.GetVerticalAxis());
        
        private bool IsWalk() => _inputHandler.GetHorizontalAxis() != 0 && _person.Movement.IsGrounded();
        private bool IsRun() => _inputHandler.GetShiftBtn() && _person.Stamina.CanUse;
        private bool IsFall() => !_person.Movement.IsGrounded() && _person.Movement.IsFall();
        
        private bool IsJump() => _inputHandler.GetVerticalAxis() > 0 &&
                                 _person.Stamina.CanUse &&
                                 !_person.Movement.IsFall() &&
                                 _person.Movement.IsGrounded();

        // добавить атаку в прыжке (для варриора)
        private bool IsSlide() => _inputHandler.GetVerticalAxis() < 0 &&
                                  _person.Movement.IsGrounded() &&
                                  _person.Movement.CanSlide();

        private bool IsRoll() => _inputHandler.GetSpaceBtn() &&
                                 _person.Stamina.CanUse &&
                                 !_person.Movement.IsFall() &&
                                 _person.Movement.IsGrounded();

        private bool IsAttack() => _inputHandler.GetLMB();
        private bool IsDefense() => _inputHandler.GetRMB();

        private void Attack()
        {
            if (_canCombo) _warrior.ComboAttack();
            else _warrior.Attack();

            // Observable.FromCoroutine(ResetCombo).Subscribe(_ =>
            // {
            //     
            // });

            // StopCoroutine(ResetCombo());
            // StartCoroutine(ResetCombo());
        }

        private IEnumerator ResetCombo()
        {
            _canCombo = true;
            yield return new WaitForSeconds(_warrior.Config.ComboInterval);
            _canCombo = false;
        }

        private void Defense() => _warrior.Defense();
        private void Fall() => _person.Fall();
        private void Jump() => _person.Jump();
        private void Slide() => _person.Slide();
        private void Roll() => _person.Roll();
        private void Run() => _person.Run();
        private void Walk() => _person.Walk();
        private void Idle() => _person.Idle();

        private void SetTempDirection(Vector2 input)
        {
            _person.Movement.Direction = input;

            if (Mathf.Abs(input.x) > 0)
                _person.Movement.TempDirection = new Vector2(_inputHandler.GetHorizontalAxis(), 0);
        }
    }
}