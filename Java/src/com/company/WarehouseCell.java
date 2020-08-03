package com.company;

import java.util.concurrent.ExecutionException;

public class WarehouseCell {
    public int Id;
    public Item CellItem;
    private Integer ItemCount;
    public void setItemCount(int value){
        if (value > this.CellItem.MaxCapacity){
            ItemCount = value;
        } else {
            throw new ArithmeticException("");
        }
    }
    public int getItemCount(){
        return this.ItemCount;
    }

    public WarehouseCell() { }

    public WarehouseCell(int id, Item cellItem, Integer itemCount)
    {
        Id = id;
        CellItem = cellItem;
        ItemCount = itemCount;
    }
}
