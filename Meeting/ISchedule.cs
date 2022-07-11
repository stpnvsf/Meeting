using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meeting
{
    internal interface ISchedule
    {
        void add(Meeting meeting);
        void remove(int id);
        void edit(int id, DateTime start, DateTime end);
        void view(DateTime date);
        void export(DateTime date);
    }
}
