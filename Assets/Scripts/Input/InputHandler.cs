using UnityEngine;

namespace Input
{
    // [RequireComponent(typeof(Person))]
    public static class InputHandler
    {
        /*private Person _person;

        private void Start() => _person = GetComponent<Person>();
        private void Update() => CheckInput();*/

        private static void CheckInput()
        {
            /*_person.IsRun = GetShiftBtn();
            _person.Move(GetInputAxis());*/
        }

        private static Vector2 GetInputAxis() =>
            new Vector2(UnityEngine.Input.GetAxis("Horizontal"),
                UnityEngine.Input.GetAxis("Vertical"));

        public static bool GetShiftBtn() => UnityEngine.Input.GetKey(KeyCode.LeftShift);
    }
}