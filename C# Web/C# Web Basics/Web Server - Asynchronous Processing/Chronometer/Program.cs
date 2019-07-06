using System;
using System.Collections.Generic;
using System.Linq;

namespace Chronometer
{
    class Program
    {
        static void Main(string[] args)
        {
            IChronometer chronometer = new Chronometer();
            ReadCommand(chronometer);
        }

        private static void ReadCommand(IChronometer chronometer)
        {

            var  input = Console.ReadLine();

            while (input != "exit")
            {
                switch (input)
                {
                    case "start":
                        chronometer.Start();
                        break;
                    case "stop":
                        chronometer.Stop();
                        break;
                    case "lap":
                        Console.WriteLine(chronometer.Lap());
                        break;
                    case "laps":
                        Console.WriteLine("Laps " + (chronometer.Laps.Count == 0 ? "no laps." : "\r\n" + 
                            string.Join(Environment.NewLine,
                                chronometer.Laps.Select((lap, index) =>
                                    $"{index}. {lap}"))));
                        break;
                    case "time":
                        Console.WriteLine(chronometer.GetTime);
                        break;
                    case "reset":
                        chronometer.Reset();
                        break;
                }

                input = Console.ReadLine();
            }
        }
    }
}
