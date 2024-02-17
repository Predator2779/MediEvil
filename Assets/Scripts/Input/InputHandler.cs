using UnityEngine;

namespace Input
{
    // [RequireComponent(typeof(Person))]
    public class InputHandler
    {
        /*private Person _person;

        private void Start() => _person = GetComponent<Person>();
        private void Update() => CheckInput();*/

        private void CheckInput()
        {
            /*_person.IsRun = GetShiftBtn();
            _person.Move(GetInputAxis());*/
        }

        public float GetHorizontalAxis() => UnityEngine.Input.GetAxis("Horizontal");
        public float GetVerticalAxis() => UnityEngine.Input.GetAxis("Vertical");
        public bool GetShiftBtn() => UnityEngine.Input.GetKey(KeyCode.LeftShift);
    }
}