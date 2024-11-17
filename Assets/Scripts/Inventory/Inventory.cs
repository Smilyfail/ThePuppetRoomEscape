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
    [SerializeField] Sprite defaultInventorySprite;

    void Start()
    {
        itemsInInventory = new List<string>();
        foreach (var itemSlot in inventorySlots)
            itemSlot.SetActive(false);
    }

    public void AddItemToInventory(string itemName)
    {
        itemsInInventory.Add(itemName);

        var itemPosition = Array.IndexOf(isSlotOccupied, false);

        inventorySlots[itemPosition].GetComponent<Image>().sprite = itemSprites.Find(x => x.name == itemName.ToLower());
        inventorySlots[itemPosition].SetActive(true);
        isSlotOccupied[itemPosition] = true;
    }

    public void RemoveItemFromInventory(string itemName) 
    {
        if (itemsInInventory.Contains(itemName))
        {
            var itemposition = Array.IndexOf(inventorySlots, inventorySlots.First(x => x.GetComponent<Image>().sprite.name == itemName.ToLower()));
            isSlotOccupied[itemposition] = false;
            inventorySlots[itemposition].SetActive(false);
            inventorySlots[itemposition].GetComponent<Image>().sprite = defaultInventorySprite;
            itemsInInventory.Remove(itemName);
        }
    }

    public bool isFull()
    {

        if(itemsInInventory.Count == 5)
        {

            return true;
        } else
        {

            return false;
        }
    }

    public void clearInventory()
    {

        for(int i = 0; i < 5; i++)
        {

            isSlotOccupied[i] = false;
            inventorySlots[i].SetActive(false);
            inventorySlots[i].GetComponent<Image>().sprite = defaultInventorySprite;

        }

        itemsInInventory = new List<string>();

    }
}
