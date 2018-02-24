namespace Online_Radio_Database
{
    public class Song
    {
        private string artistName;
        private string name;
        private int minutes;
        private int seconds;

        public Song(string artistName, string name, int minutes, int seconds)
        {
            ArtistName = artistName;
            Name = name;
            Minutes = minutes;
            Seconds = seconds;
        }

        public int Seconds
        {
            get { return seconds; }
            set
            {
                if (value < 0 || value > 59)
                {
                    throw new InvalidSongSecondsException();
                }
                seconds = value;
            }
        }

        public int Minutes
        {
            get { return minutes; }
            set
            {
                if (value < 0 || value > 14)
                {
                    throw new InvalidSongMinutesException();
                }
                minutes = value;
            }
        }


        public string Name
        {
            get { return name; }
            set
            {
                if (value.Length < 3 || value.Length > 30)
                {
                    throw new InvalidSongNameException();
                }
                name = value;
            }
        }

        public string ArtistName
        {
            get { return artistName; }
            set
            {
                if (value.Length < 3 || value.Length > 20)
                {
                    throw new InvalidArtistNameException();
                }
                artistName = value;
            }
        }

    }
}
