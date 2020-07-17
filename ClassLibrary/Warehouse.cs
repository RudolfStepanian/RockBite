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

        public void AddItem(Item newItem, int count)
        {
            WarehouseCell itemCell = Cells.Find(x => x.CellItem.Name == newItem.Name);
            if ((itemCell.CellItem.MaxCapacity - itemCell.ItemCount) > count && itemCell != null)
            {
                itemCell.CellItem = newItem;
                itemCell.ItemCount = count;
                return;
            }

            WarehouseCell temp = Cells.Find(x => x.CellItem == null);
            if (temp != null)
            {
                temp.CellItem = newItem;
                temp.ItemCount = count;
            }
            else
            {
                throw new Exception("no place to add");
            }
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

        public static void TransferItem(Warehouse A, Warehouse B, int count, int id)
        {
            WarehouseCell transferCell = A.Cells.Find(x => x.Id == id);
            if (transferCell == null)
            {
                throw new Exception("No item to transfer");
            }
            if ((transferCell.CellItem.MaxCapacity - transferCell.ItemCount) > count)
            {
                B.AddItem(transferCell.CellItem, count);
                transferCell.CellItem = null; // as we working whith linked objects there is no need to certify which object to null
                // should be added functionality for stacking items in one cell
            }
            else
            {
                throw new Exception("not enough space for transfer");
            }



        }


    }
}
