using UnityEngine;

namespace Global.Zenject
{
    public class PrintTest : ITest
    {
        public void PrintTest2()
        {
            Debug.Log("Printed!");
        }
    }
}