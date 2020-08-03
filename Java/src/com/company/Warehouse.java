package com.company;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

public class Warehouse {
    public int Id;
    public int CellsCount;
    public ArrayList<WarehouseCell> Cells;
//    public Map<Integer, WarehouseCell> Cells;

    public Warehouse(int id, int cellsCount)
    {
        Id = id;
        CellsCount = cellsCount;
        Cells = new ArrayList<WarehouseCell>();
        for (int i = 1; i <= cellsCount; i++)
        {
//            Cells.put(i, new WarehouseCell(i, null, null));
            Cells.add(new WarehouseCell(i, null, null));
        }
    }

    public void AddItem(Item newItem, int count)
    {
        WarehouseCell itemCell = null;
        for(WarehouseCell a: Cells){
            if(a.CellItem.Name == newItem.Name) {itemCell = a;}
        }
        if ((itemCell.CellItem.MaxCapacity - itemCell.getItemCount()) > count && itemCell != null)
        {
            itemCell.CellItem = newItem;
            itemCell.setItemCount(count);
            return;
        }

        WarehouseCell temp = null;
        for(WarehouseCell a: Cells){
            if(a.CellItem.Name == null) {temp = a;}
        }
        if (temp != null)
        {
            temp.CellItem = newItem;
            temp.setItemCount(count);
        }
        else
        {
            throw new ArrayIndexOutOfBoundsException("no place to add");
        }
    }

    public void AddItemCertaint(Item newItem, int cellId)
    {
        WarehouseCell temp = null;
        for(WarehouseCell a: Cells){
            if(a.Id == cellId) {temp = a;}
        }
//        WarehouseCell temp = Cells.get(cellId);
        if (temp.CellItem != null)
        {
            temp.CellItem = newItem;
        }
        else
        {
            throw new ArrayIndexOutOfBoundsException("This cell is already filled");
        }
    }

    public static void TransferItem(Warehouse A, Warehouse B, int count, int id)
    {
        WarehouseCell transferCell = null;
        for(WarehouseCell a: A.Cells){
            if(a.Id == id) {transferCell = a;}
        }
//        WarehouseCell transferCell = A.Cells.get(id);
        if (transferCell == null)
        {
            throw new ArrayIndexOutOfBoundsException("No item to transfer");
        }
        if ((transferCell.CellItem.MaxCapacity - transferCell.getItemCount()) > count)
        {
            B.AddItem(transferCell.CellItem, count);
            transferCell.CellItem = null; // as we working whith linked objects there is no need to certify which object to null
            // should be added functionality for stacking items in one cell
        }
        else
        {
            throw new ArrayIndexOutOfBoundsException("not enough space for transfer");
        }

    }
}