namespace Online_Radio_Database
{
    using System;
    using System.Collections.Generic;

    public class Startup
    {
        public static void Main()
        {
            List<Song> songs = AddSongs();
            PrintSongs(songs);
        }

        private static void PrintSongs(List<Song> songs)
        {
            int minutes = 0;
            int seconds = 0;

            foreach (var song in songs)
            {
                minutes += song.Minutes;
                seconds += song.Seconds;
            }
            int minutesToAdd = seconds / 60;
            int totalSeconds = seconds % 60;
            int totalMinutes = minutes + minutesToAdd;
            int totalHours = totalMinutes / 60;
            totalMinutes = totalMinutes % 60;

            Console.WriteLine("Songs added: {0}", songs.Count);
            Console.WriteLine("Playlist length: {0}h {1}m {2}s", totalHours, totalMinutes, totalSeconds);
        }

        private static List<Song> AddSongs()
        {
            List<Song> songs = new List<Song>();

            int totalSongs = int.Parse(Console.ReadLine());

            for (int line = 0; line < totalSongs; line++)
            {
                
                string[] songArgs = Console.ReadLine().Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
           
                try
                {
                    var indexOfMinuteSecondSeparation = songArgs[2].IndexOf(':');

                    if (songArgs.Length < 3 || indexOfMinuteSecondSeparation < 1 ||
                        indexOfMinuteSecondSeparation > songArgs[2].Length - 2)
                    {
                        throw new InvalidSongException();
                    }

                    var artist = songArgs[0];
                    var songName = songArgs[1];
                    var minutes = int.Parse(songArgs[2].Substring(0, indexOfMinuteSecondSeparation));
                    var seconds = int.Parse(songArgs[2].Substring(indexOfMinuteSecondSeparation + 1));

                    Song song = new Song(artist, songName, minutes, seconds);
                    Console.WriteLine("Song added.");
                    songs.Add(song);


                }
                catch (InvalidSongException ise)
                {
                    Console.WriteLine(ise.Message);
                    continue;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid song length.");
                    continue;
                }
            }
            return songs;
        }
    }
}
