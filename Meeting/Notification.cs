using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meeting
{
    internal class Notification : INotification
    {
        private TimeSpan InfiniteTimeSpan = new TimeSpan(0, 0, 0, 0, -1);
        public string Message { get; set; }
        public TimeSpan Time { get; set; }
        public Timer Timer { get; set; }
        public Notification() { }
        public Notification(string message, TimeSpan time)
        {
            Message = message;
            Time = time;

            Timer = new Timer(notify, null, Time, InfiniteTimeSpan);

        }
        public void changeTime(TimeSpan time)
        {
            Timer.Change(time, InfiniteTimeSpan);
        }
        private void notify(object obj)
        {
            Console.WriteLine(Message);
        }
    }
}
