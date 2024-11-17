    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class CameraMovement : MonoBehaviour
    {
        [SerializeField] Transform playerTransform; 
        Vector3 offset = new Vector3(0, 0.5f, 0);

        private float followSpeed = 100f;
        private float rotationSpeed = 5f;
        private float mouseSensitivity = 5f;
        private float maxVerticalAngle = 60f;

        private float verticalRotation = 0f;


    void LateUpdate()
        {

        Vector3 targetPosition = playerTransform.position + playerTransform.TransformDirection(offset);
        transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);

        // Handle camera rotation
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;
        verticalRotation -= mouseY;
        verticalRotation = Mathf.Clamp(verticalRotation, -maxVerticalAngle, maxVerticalAngle); 

        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity; 
        Quaternion horizontalRotation = Quaternion.Euler(0, mouseX * rotationSpeed, 0);

        // Apply rotations
        transform.rotation = Quaternion.Euler(verticalRotation, playerTransform.eulerAngles.y, 0);

    }
    }
