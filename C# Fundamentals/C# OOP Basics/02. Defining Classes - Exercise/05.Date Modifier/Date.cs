namespace _05.Date_Modifier
{
    public class Date
    {
        private int day;
        private int month;
        private int year;

        public int Day
        {
            get { return day; }
            set { day = value; }
        }

        public int Month
        {
            get { return month; }
            set { month = value; }
        }

        public int Year
        {
            get { return year; }
            set { year = value; }
        }

        public Date(int year, int month, int day)
        {
            Year = year;
            Month = month;
            Day = day;
        }
    }
}
