using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLetters : MonoBehaviour {

    [SerializeField] LetterDesk desk;
    private bool isDragging = false;
    private Plane dragPlane;
    private Camera mainCamera;
    private Vector3 offset;

    void Start()
    {
        mainCamera = Camera.main; 
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && desk.isSortingLetters)
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit) && hit.transform == transform)
            {
                isDragging = true;
                dragPlane = new Plane(Vector3.up, hit.point);
                offset = transform.position - hit.point;
            }
        }


        if (Input.GetMouseButton(0) && isDragging)
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            float distance;

            if (dragPlane.Raycast(ray, out distance))
            {
                Vector3 point = ray.GetPoint(distance);
                transform.position = new Vector3(point.x + offset.x, transform.position.y, point.z + offset.z);
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
        }
    }

}
