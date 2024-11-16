using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    List<string> itemsInInventory;

    private void Start()
    {
        itemsInInventory = new List<string>();
    }

    public void AddItemToInventory(string itemName)
    {
        itemsInInventory.Add(itemName);
        
        foreach (string item in itemsInInventory) 
            Debug.Log(item);
    }

    public void RemoveItemFromInventory(string itemName) 
    {
        if (itemsInInventory.Contains(itemName)) 
            itemsInInventory.Remove(itemName);
    }
}
