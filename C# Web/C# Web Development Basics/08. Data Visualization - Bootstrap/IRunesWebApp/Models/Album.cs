namespace IRunesWebApp.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public class Album : BaseModel<string>
    {
        public string Name { get; set; }

        public string Cover { get; set; }

        public ICollection<TrackAlbum> Tracks { get; set; } = new HashSet<TrackAlbum>();

        [NotMapped]
        public decimal Price => decimal.Multiply(this.Tracks.Select(t => t.Track).Sum(tr => tr.Price), 0.87m);
    }
}
