
namespace DungeonsAndCodeWizards.Bags
{
    using DungeonsAndCodeWizards.Items;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public abstract class Bag
    {
        #region Fields
        private List<Item> items;
        #endregion

        #region Constructors
        protected Bag(int capacity)
        {
            this.Capacity = capacity;
            items = new List<Item>();
        }
        #endregion

        #region Properties
        public int Capacity { get; protected set; }

        public int Load => this.Items.Sum(i => i.Weight);

        public IReadOnlyCollection<Item> Items
        {
            get { return items.AsReadOnly(); }
        }

        #endregion 

        #region Methods
        public void AddItem(Item item)
        {
            if (this.Load + item.Weight > Capacity)
            {
                throw new InvalidOperationException("Bag is full!");
            }
            this.items.Add(item);
        }

        public Item GetItem(string name)
        {
            if (!this.items.Any())
            {
                throw new InvalidOperationException("Bag is empty!");
            }
            var searchedItem = this.items.FirstOrDefault(i => i.Name == name);

            if (searchedItem == null)
            {
                throw new ArgumentException($"No item with name {name} in bag!");
            }
            this.items.Remove(searchedItem);

            return searchedItem;
        }
        #endregion
    }
}
