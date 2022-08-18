using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class InventorySlot : ISerializationCallbackReceiver
{
    [NonSerialized] private InventoryItemData itemData; // Refrence to the data
    [SerializeField] private int _itemID = -1;
    [SerializeField] private int stackSize; // Current stack size - how many of the data do we hav?

    public InventoryItemData ItemData => itemData;
    public int StackSize => stackSize;

    public InventorySlot(InventoryItemData source, int amount) // Constructer to make a occupied inventory slot.
    {
        itemData = source;
        _itemID = itemData.ID;
        stackSize = amount;
    }

    public InventorySlot() // Constructor to make an empty inventory slot.
    {
        ClearSlot();
    }

    public void ClearSlot() // Clears the slot.
    {
        itemData = null;
        _itemID = -1;
        stackSize = -1;
    }

    public void AssignItem(InventorySlot invSlot) // Assignes an item to the slot.
    {
        if (itemData == invSlot.itemData) AddToStack(invSlot.stackSize); // Does the slot contain the same item? Add to stack if so.
        else // Overwrite slot with the inventory slot that we are passing in.
        {
            itemData = invSlot.itemData;
            _itemID = itemData.ID;
            stackSize = 0;
            AddToStack(invSlot.stackSize);
        }
    }

    public void UpdateInventorySlot(InventoryItemData data, int amount) // Updates slot directly.
    {
        itemData = data;
        _itemID = itemData.ID;
        stackSize = amount;
    }

    public bool EnoughRoomLeftInStack(int amountToAdd, out int amountRemaining) // Would there be enough room in the stack for the amount we are trying to add.
    {
        amountRemaining = ItemData.MaxStackSize - stackSize;

        return EnoughRoomLeftInStack(amountToAdd);
    }

    public bool EnoughRoomLeftInStack(int amountToAdd)
    {
        if(itemData == null || itemData != null && stackSize + amountToAdd <= itemData.MaxStackSize) return true;
        else return false;
    }

    public void AddToStack(int amount)
    {
        stackSize += amount;
    }

    public void RemoveFromStack(int amount)
    {
        stackSize -= amount;
    }

    public bool SplitStack(out InventorySlot splitStack)
    {
        if (StackSize <= 1) // Is there enough to actually split? If not return false.
        {
            splitStack = null;
            return false;
        }

        int halfStack = Mathf.RoundToInt(stackSize / 2); // Get half of stack.
        RemoveFromStack(halfStack);


        splitStack = new InventorySlot(itemData, halfStack); // Creates a copy of this slot with half the stack size.
        return true;
    }

    public void OnBeforeSerialize()
    {

    }

    public void OnAfterDeserialize()
    {
        if (_itemID == -1) return;

        var db =Resources.Load<Database>("ItemDatabase");
        itemData = db.GetItem(_itemID);
    }
}
