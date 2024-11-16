using UnityEngine;

public class Interactible : MonoBehaviour
{

    [SerializeField] bool isCollectible, isMovable, isInspectible, isItemRemover, hasSpecialAction;
    private bool isMovingToCam = false, isInspectingItem = false, isMovingBack = false;
    [SerializeField] Inventory inventory;
    [SerializeField, Header("Only fill this in for items that consume things!")] private string itemRequired;

    private Vector3 originalPosition;
    private Quaternion originalRotation;
    private float verticalRotation = 0f, horizontalRotation = 0f;

    private Camera cam;
    private string playerTag = "Player";
    private GameObject playerObject;

    [SerializeField] AdditionalInteraction additionalBehaviour;
    
    private float followSpeed = 15f, rotationSpeed = 15f, mouseSensitivity = 2f;

    void Start()
    {
        originalPosition = transform.position;
        playerObject = GameObject.FindGameObjectWithTag(playerTag);
        inventory = playerObject.GetComponent<Inventory>();
        originalRotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, transform.rotation.z);
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

        else if (isItemRemover)
        {
            inventory.RemoveItemFromInventory(itemRequired);
            if (additionalBehaviour != null)
            {
                additionalBehaviour.Act();
            }
        }

        else if(hasSpecialAction)
        {
            additionalBehaviour.Act();
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
            transform.rotation = Quaternion.Lerp(transform.rotation, originalRotation, rotationSpeed * Time.deltaTime);

            if (transform.position == originalPosition && transform.rotation == originalRotation)
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

        if (isInspectingItem && Input.GetMouseButton(0))
        {
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;
            verticalRotation -= mouseY;

            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
            horizontalRotation -= mouseX;

            var targetRotation = Quaternion.Euler(0, horizontalRotation, verticalRotation);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }
}
