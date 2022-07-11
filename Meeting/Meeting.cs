using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meeting
{
    internal class Meeting : IComparable<Meeting>
    {
        public int Id { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public INotification Notification { get; set; }

        public Meeting(int id, DateTime start, DateTime end)
        {
            if((start > DateTime.Now) && (start < end))
            {
                Id = id;
                Start = start;
                End = end;
                Notification = null;
            }
            else if (start > end)
            {
                Console.WriteLine("Время начала не может быть раньше окончания");
            }
            else if (start < DateTime.Now)
            {
                Console.WriteLine("Встреча должна быть запланирована на будущее время");
            }

        }
        public Meeting(DateTime start, DateTime end)
        {
            if ((start > DateTime.Now) && (start < end))
            {
                Start = start;
                End = end;
                Notification = null;
            }
            else if (start > end) 
            {
                Console.WriteLine("Время начала не может быть раньше окончания");
            }
            else if(start < DateTime.Now)
            {
                Console.WriteLine("Встреча должна быть запланирована на будущее время");
            }
        }
        public Meeting(int id, DateTime start, DateTime end, TimeSpan notificationTime)
        {
            if((start > DateTime.Now) && (start < end))
            {
                Id = id;
                Start = start;
                End = end;
                Notification = new Notification(ToString(), (Start - DateTime.Now).Subtract(notificationTime));
            }
            else if (start > end)
            {
                Console.WriteLine("Время начала не может быть раньше окончания");
            }
            else if (start < DateTime.Now)
            {
                Console.WriteLine("Встреча должна быть запланирована на будущее время");
            }


        }
        public void changeTime(TimeSpan time)
        {
            Notification.changeTime((Start - DateTime.Now).Subtract(time));
        }

        public int CompareTo(Meeting meeting)
        {
            if ((Start.CompareTo(meeting.Start) == 1) && (End.CompareTo(meeting.End) == 1))
                return 1;
            if ((Start.CompareTo(meeting.Start) == -1) && (End.CompareTo(meeting.End) == -1))
                return -1;
            else
                return 0;
        }

        public override string ToString()
        {
            return String.Format("Дата: {0}\tНачало: {1}\tКонец: {2}",
                Start.ToShortDateString(), Start.ToShortTimeString(), End.ToShortTimeString());
        }

    }
}
