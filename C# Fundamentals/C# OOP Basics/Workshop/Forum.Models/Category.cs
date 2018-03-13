namespace Forum.Models
{
    using System.Collections.Generic;
    public class Category
    {
        public Category(int id, string name, ICollection<int> postIds)
        {
            Id = id;
            Name = name;
            PostIds = new List<int>(postIds);
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<int> PostIds { get; set; }

    }
}
