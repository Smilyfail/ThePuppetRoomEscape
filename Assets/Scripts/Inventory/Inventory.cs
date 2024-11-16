using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    List<string> itemsInInventory;
    [SerializeField] List<GameObject> inventorySlots;
    private bool[] isSlotOccupied;
    [SerializeField] List<Sprite> itemSprites;

    private void Start()
    {
        itemsInInventory = new List<string>();
    }

    public void AddItemToInventory(string itemName)
    {
        itemsInInventory.Add(itemName);

        foreach (string item in itemsInInventory)
            Debug.Log(item);

        var itemPosition = itemsInInventory.Count - 1;

        inventorySlots[itemPosition].GetComponent<Image>().sprite = itemSprites.Find(x => x.name == itemName);
        inventorySlots[itemPosition].gameObject.SetActive(true);
    }

    public void RemoveItemFromInventory(string itemName) 
    {
        if (itemsInInventory.Contains(itemName))
        {

        }
    }
}
