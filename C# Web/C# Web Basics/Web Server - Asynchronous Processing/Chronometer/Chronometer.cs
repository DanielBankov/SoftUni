using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Chronometer
{
    public class Chronometer : IChronometer
    {
        private long miliseconds;
        private bool isRunning;
        public Chronometer()
        {
            this.Laps = new List<string>();
        }

        public string GetTime => GetCurrentTime();

        private string GetCurrentTime()
        {
            return $"{(miliseconds / 60000):D2}:{(miliseconds / 1000):D2}.{(miliseconds % 1000):D4}";
        }

        public List<string> Laps { get; }

        public string Lap()
        {
            var time = GetCurrentTime();
            Laps.Add(time);
            return time;
        }

        public void Reset()
        {
            this.Stop();
            this.miliseconds = 0;
            Laps.Clear();
        }

        public void Start()
        {
            isRunning = true;

            Task.Run(() =>
            {
                while (isRunning)
                {
                    Thread.Sleep(1);
                    miliseconds++;
                }
            });
        }

        public void Stop()
        {
            isRunning = false;
        }
    }
}
