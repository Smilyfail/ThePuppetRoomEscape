using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] Transform playerTransform;
    private Camera camera;

    void Start()
    {
        camera = GetComponent<Camera>();
        camera.transform.position = new Vector3(playerTransform.position.x, - playerTransform.position.y, playerTransform.position.z + 4);
        camera.transform.LookAt(playerTransform.position);
    }

    void Update()
    {
        camera.transform.LookAt(playerTransform.position);
    }
}
