using System;

namespace EXS_Events_2022_07_04
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Clock clock = new(0, 5);
            clock.RunClock();

        }
    }
    public class Clock
    {
        public int Minute { get; set; } = 0;
        public int Hour { get; set; } = 0;
        public HourEventArgs MyEventArgs { get; set; } = new();

        public event EventHandler<HourEventArgs> OnNowIsMorning = (Sender, EventArgs) => { Console.WriteLine($"{EventArgs.Hour}:{EventArgs.Minute}"); Sun.SunIsRising(); Moon.MoonIsGone(); }; 

        public Clock(int minute, int hour)
        {
            Minute = minute;
            Hour = hour;
            MyEventArgs.Minute = Minute;
            MyEventArgs.Hour = Hour;
            if (Hour == 5 && Minute == 0)
            {
                OnNowIsMorning.Invoke(this, MyEventArgs);
            }
        }
        public void RunClock()
        {
            Hour = 0;
            Minute = 0;
            while(true)
            {
                Console.WriteLine($"{Hour}:{Minute}");
                Minute++;
                if(Minute == 60)
                {
                    Hour++;
                    Minute = 0;
                }
                if (Hour == 5 && Minute == 0)
                {
                    OnNowIsMorning.Invoke(this, MyEventArgs);
                }
                if (Hour == 19 && Minute == 0)
                {
                    Moon.MoonIsUp();
                }
                if (Hour == 24 && Minute == 0)
                {
                    Hour = 0;
                    break;
                }
            }

        }
    }

    public class HourEventArgs : EventArgs
    {
        public int Minute { get; set; }
        public int Hour { get; set; }
    }

    public class Sun
    {

        public static void SunIsRising()
        {
            Console.WriteLine("The Sun is Rising");
        }
    }
    public class Moon
    {

        public static void MoonIsUp()
        {
            Console.WriteLine("The Moon is Up");
            Console.WriteLine("Press Enter to continue");
            Console.ReadLine();
        }
        public static void MoonIsGone()
        {
            Console.WriteLine("The Moon is Gone");
            Console.WriteLine("Press Enter to continue");
            Console.ReadLine();
        }
    }
}
