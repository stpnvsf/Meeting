using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meeting
{
    internal class User
    {
        public string Name { get; set; }
        public ISchedule Schedule { get; set; }
        public User(string name, ISchedule schedule)
        {
            Name = name;
            Schedule = schedule;
        }
        public void addMeeting(Meeting meeting)
        {
            Schedule.add(meeting);
        }
        public void removeMeeting(int id)
        {
            Schedule.remove(id);
        }
        public void editMeeting(int id, DateTime start, DateTime end)
        {
            Schedule.edit(id, start, end);
        }
        public void viewSchedule(DateTime date)
        {
            Schedule.view(date);
        }
        public void exportShedule(DateTime date)
        {
            Schedule.export(date);
        }
    }
}
