using System;
using System.Diagnostics;

namespace PUCGrafos.domain.utilidades
{

    public class ClockMeter
    {
        private Stopwatch stopwatch;

        public ClockMeter()
        {
            stopwatch = new Stopwatch();
        }

        public void Start()
        {
            stopwatch.Reset();
            stopwatch.Start();
        }

        public void Stop()
        {
            stopwatch.Stop();
        }

        public long ElapsedMilliseconds => stopwatch.ElapsedMilliseconds;
        
        public double ElapsedSeconds => stopwatch.Elapsed.TotalSeconds;

        public long Measure(Action action)
        {
            if (action == null) throw new ArgumentNullException(nameof(action));

            Start();
            action();
            Stop();
            return ElapsedMilliseconds;
        }
    }

}