using UnityEngine;

namespace Input
{
    public class InputHandler
    {
        public float GetHorizontalAxis() => UnityEngine.Input.GetAxis("Horizontal");
        public float GetVerticalAxis() => UnityEngine.Input.GetAxis("Vertical");
        public bool GetShiftBtn() => UnityEngine.Input.GetKey(KeyCode.LeftShift);
        public bool GetSpaceBtn() => UnityEngine.Input.GetKey(KeyCode.Space);
    }
}