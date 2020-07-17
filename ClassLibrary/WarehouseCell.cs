using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    public class WarehouseCell
    {
        public int Id { get; set; }
        public Item? CellItem { get; set; }
        public int? ItemCount 
        {
            set {
                if (value > this.CellItem.MaxCapacity)
                {
                    ItemCount = value;
                }
                else
                {
                    throw new Exception("out of storage exception");
                }
            }
            get { return ItemCount; } 
        }

        public WarehouseCell(int id, Item cellItem, int? itemCount)
        {
            Id = id;
            CellItem = cellItem;
            ItemCount = itemCount;
        }
    }
}
