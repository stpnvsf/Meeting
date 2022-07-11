namespace Meeting
{

    class Program
    {

        static void Main()
        {
            Meeting meeting = new Meeting(1, new DateTime(2022, 7, 12, 15, 0, 0), new DateTime(2022, 7, 12, 15, 15, 0));
            Meeting meeting1 = new Meeting(2, new DateTime(2022, 7, 12, 15, 16, 0), new DateTime(2022, 7, 12, 15, 30, 0));
            Meeting m3 = new Meeting(3, new DateTime(2022, 7, 15, 15, 16, 0), new DateTime(2022, 7, 15, 15, 30, 0));
            Meeting m4 = new Meeting(4, new DateTime(2022, 7, 15, 16, 16, 0), new DateTime(2022, 7, 15, 16, 30, 0));


            User user = new User("Bob", new Schedule(meeting));

            user.addMeeting(meeting1);
            user.addMeeting(m3);
            user.addMeeting(m4);
            user.viewSchedule(new DateTime(2022, 7, 12));
            user.removeMeeting(3);
            user.editMeeting(1, new DateTime(2022, 7, 12, 17, 0, 0), new DateTime(2022, 7, 12, 17, 15, 0));

            user.viewSchedule(new DateTime(2022, 7, 12));


            Console.ReadKey();

        }
    }

}