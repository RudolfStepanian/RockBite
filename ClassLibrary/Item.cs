using System;

namespace ClassLibrary
{
    public class Item
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
        public int MaxCapacity { get; set; }

        public Item(string name, string description, string icon, int maxCapacity)
        {
            Name = name;
            Description = description;
            Icon = icon;
            MaxCapacity = maxCapacity;
        }

    }
}
