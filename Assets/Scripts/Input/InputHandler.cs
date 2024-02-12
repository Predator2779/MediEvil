using Character;
using UnityEngine;

namespace Input
{
    [RequireComponent(typeof(Person))]
    public class InputHandler : MonoBehaviour
    {
        private Person _person;

        private void Start() => _person = GetComponent<Person>();
        private void Update() => CheckInput();

        private void CheckInput()
        {
            // _person.IsRun = GetShiftBtn();
            _person.Move(GetInputAxis());
        }

        private Vector2 GetInputAxis() =>
            new(UnityEngine.Input.GetAxis("Horizontal"),
                UnityEngine.Input.GetAxis("Vertical"));

        private bool GetShiftBtn() => UnityEngine.Input.GetKey(KeyCode.LeftShift);
    }
}