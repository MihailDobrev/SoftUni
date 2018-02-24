namespace Online_Radio_Database
{
    public class InvalidSongLengthException:InvalidSongException
    {
        public override string Message => "Invalid song length.";
    }
}
