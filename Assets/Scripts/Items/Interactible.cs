using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interactible : MonoBehaviour
{

    [SerializeField] bool isCollectible;
    [SerializeField] bool isMovable;
    [SerializeField] Inventory inventory;
    private string playerTag = "Player";

    public void Interact()
    {
        if (isCollectible)
        {
            var inventory = GameObject.FindGameObjectWithTag(playerTag).GetComponent<Inventory>();
            inventory.AddItemToInventory(gameObject.name);
            Destroy(gameObject);
        }
    }
}
