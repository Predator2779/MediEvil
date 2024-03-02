using UnityEngine;
using System.Timers;

namespace Other
{
    public class MyTimer
    {
        private readonly Timer _timer;

        public MyTimer(float ms)
        {
            _timer = new Timer { Interval = ms };
            _timer.Elapsed += OnTimerElapsed;
            _timer.AutoReset = true;
        }

        public void StartTimer()
        {
            _timer.Start();
        }

        public void StopTimer()
        {
            _timer.Stop();
        }

        private void OnTimerElapsed(object sender, ElapsedEventArgs e)
        {
            Debug.Log("Таймер сработал!");
        }
    }
}