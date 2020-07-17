using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    public class Warehouse
    {
        public int Id { get; set; }
        public int CellsCount { get; set; }
        public List<WarehouseCell?> Cells { get; set; }

        public Warehouse(int id, int cellsCount)
        {
            Id = id;
            CellsCount = cellsCount;
            Cells = new List<WarehouseCell>();
            for (int i = 1; i <= cellsCount; i++)
            {
                Cells.Add(new WarehouseCell(i, null, null));
            }
        }

        public void AddItem(Item newItem)
        {
            WarehouseCell temp = Cells.Find(x => x.CellItem == null);
            temp.CellItem = newItem;
        }

        public void AddItemCertaint(Item newItem, int cellId)
        {
            WarehouseCell temp = Cells.Find(x => x.Id == cellId);
            if (temp.CellItem != null)
            {
                temp.CellItem = newItem;
            }
            else
            {
                throw new Exception("This cell is already filled");
            }
        }


    }
}
