    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] Rigidbody rb;
    private float moveSpeed = 2f;
    private float rotationSpeed = 150f;
    private Vector3 moveDirection;
    private float mouseSensitivity = 10f;

    void Start()
    {

    }

    void Update()
    {
 
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");   


        moveDirection = transform.forward * moveVertical + transform.right * moveHorizontal;

        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        transform.Rotate(Vector3.up, mouseX * rotationSpeed * Time.deltaTime);
    }

    void FixedUpdate()
    {
        if (rb != null)
        {
            rb.MovePosition(rb.position + moveDirection * moveSpeed * Time.fixedDeltaTime);

        }

    }
}
