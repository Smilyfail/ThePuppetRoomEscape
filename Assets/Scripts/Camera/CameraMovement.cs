    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class CameraMovement : MonoBehaviour
    {
        [SerializeField] Transform playerTransform; 
        Vector3 offset = new Vector3(0, 2, -4);
        private float followSpeed = 5f;
        private float rotationSpeed = 5f;


    void LateUpdate()
        {

            Vector3 targetPosition = playerTransform.position + playerTransform.TransformDirection(offset);

            transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);

            Quaternion targetRotation = Quaternion.LookRotation(playerTransform.position - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

    }
    }
