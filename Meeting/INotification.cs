using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meeting
{
    internal interface INotification
    {
        string Message { get; set; }
        TimeSpan Time { get; set; }
        Timer Timer { get; set; }
        public void changeTime(TimeSpan time);
    }
}
