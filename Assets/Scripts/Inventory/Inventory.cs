using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    List<string> itemsInInventory;
    [SerializeField] GameObject[] inventorySlots;
    private bool[] isSlotOccupied = { false, false, false, false, false };
    [SerializeField] List<Sprite> itemSprites;

    void Start()
    {
        itemsInInventory = new List<string>();
    }

    public void AddItemToInventory(string itemName)
    {
        itemsInInventory.Add(itemName);

        var itemPosition = Array.IndexOf(isSlotOccupied, true);

        inventorySlots[itemPosition].GetComponent<Image>().sprite = itemSprites.Find(x => x.name == itemName);
        inventorySlots[itemPosition].gameObject.SetActive(true);
        isSlotOccupied[itemPosition] = true;
    }

    public void RemoveItemFromInventory(string itemName) 
    {
        if (itemsInInventory.Contains(itemName))
        {
            var itemposition = Array.IndexOf(inventorySlots, inventorySlots.First(x => x.GetComponent<Image>().sprite.name == itemName));
            isSlotOccupied[itemposition] = false;
            inventorySlots[itemposition].gameObject.SetActive(false);
        }
    }
}
