using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meeting
{
    internal class Schedule : ISchedule
    {
        public List<Meeting> MeetingList { get; set; }

        public Schedule(Meeting meeting)
        {
            MeetingList = new List<Meeting>() { meeting };
        }
        private bool validate(DateTime start, DateTime end)
        {
            Meeting meeting = new Meeting(start, end);
            bool condition = MeetingList.Any(s => s.CompareTo(meeting) == 0);

            if (!condition)
                return true;
            else
            {
                Console.WriteLine("На это время уже запланирована встреча");
                return false;
            }
        }
        public void add(Meeting meeting)
        {
            if (validate(meeting.Start, meeting.End))
                MeetingList.Add(meeting);
        }
        public void remove(int id)
        {
            try
            {
                Meeting meeting = MeetingList.First(s => s.Id == id);
                MeetingList.Remove(meeting);
                if (meeting.Notification != null)
                {
                    meeting.Notification.Timer.Dispose();
                }
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine("Не запланировано встречи с id {0}", id);
            }

        }
        public void edit(int id, DateTime start, DateTime end)
        {
            if (validate(start, end))
            {
                try
                {
                    MeetingList.First(s => s.Id == id).Start = start;
                    MeetingList.First(s => s.Id == id).End = end;
                }
                catch(InvalidOperationException ex)
                {
                    Console.WriteLine("Не запланировано встречи с id {0}", id);
                }
                
            }

        }
        public void view(DateTime date)
        {
            var schedule = MeetingList.Where(s => s.Start.Date.Equals(date.Date)).ToList();
            schedule.Sort();

            foreach (Meeting meeting in schedule)
                Console.WriteLine(meeting);
        }
        public void export(DateTime date)
        {
            var schedule = MeetingList.Where(s => s.Start.Date.Equals(date.Date)).ToList();
            schedule.Sort();

            using (StreamWriter writer = new StreamWriter(@"C:\Users\Dori\Новая папка\Meeting\Meeting\export.txt", false))
            {
                writer.WriteLine(
                    date.Date);
                foreach (Meeting meeting in schedule)
                {
                    writer.WriteLine(meeting.ToString());
                }
            }

        }
    }
}
