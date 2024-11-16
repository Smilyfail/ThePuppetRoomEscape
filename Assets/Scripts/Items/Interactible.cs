using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Interactible : MonoBehaviour
{

    [SerializeField] bool isCollectible;
    [SerializeField] bool isMovable;
    [SerializeField] bool isInspectible;
    private bool isMovingToCam = false;
    private bool isInspectingItem = false;
    private bool isMovingBack = false;
    private Vector3 originalPosition;
    [SerializeField] Inventory inventory;
    private string playerTag = "Player";
    private GameObject playerObject;
    private float followSpeed = 5f;
    [SerializeField] private Camera cam;

    void Start()
    {
        originalPosition = transform.position;
        playerObject = GameObject.FindGameObjectWithTag(playerTag);
        inventory = playerObject.GetComponent<Inventory>();
    }

    public void Inspect()
    {
        if (isCollectible || isInspectible)
        {
            cam = Camera.main;

            isMovingToCam = true;
            isInspectingItem = true;

            playerObject.GetComponent<PlayerMovement>().enabled = false;
            cam.GetComponent<CameraMovement>().enabled = false;
        }
    }

    private void PickUp()
    {
        inventory.AddItemToInventory(gameObject.name);
        Destroy(gameObject);

        playerObject.GetComponent<PlayerMovement>().enabled = true;
        cam.GetComponent<CameraMovement>().enabled = true;

        isInspectingItem = false;
    }

    void Update() 
    {

    }

    private void LateUpdate()
    {
        if (isMovingToCam)
        {
            Vector3 targetPosition = cam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 2f));
            transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);

            if (transform.position == targetPosition)
                isMovingToCam = false;
        }
        else if (isMovingBack)
        {
            transform.position = Vector3.Lerp(transform.position, originalPosition, followSpeed * Time.deltaTime);
            
            if (transform.position == originalPosition)
            {
                isMovingBack = false;
                isInspectingItem = false;

                playerObject.GetComponent<PlayerMovement>().enabled = true;
                cam.GetComponent<CameraMovement>().enabled = true;
            }
        }

        if (Input.GetKeyUp(KeyCode.E) && isCollectible && isInspectingItem && !isMovingBack && !isMovingToCam)
            PickUp();

        else if (Input.GetKeyUp(KeyCode.Escape) && isInspectingItem && !isMovingBack && !isMovingToCam)
            isMovingBack = true;
    }
}
