namespace IRunesWebApp.Models
{
    public class TrackAlbum
    {
        public string TrackId { get; set; }

        public Track Track { get; set; }

        public string AlbumId { get; set; }

        public Album Album { get; set; }
    }
}