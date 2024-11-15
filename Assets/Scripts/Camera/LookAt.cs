using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{
    private RaycastHit hit;
    private float interactionRange = 10f;
    private string interactibleTag = "Interactible";
    Camera cam;
    Transform highlitObject;

    // Start is called before the first frame update
    void Start()
    {
        cam = gameObject.GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(cam.transform.position, cam.transform.forward * interactionRange, Color.red);
        if(Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, interactionRange))
        {
            if (hit.distance < interactionRange && hit.transform.CompareTag(interactibleTag))
            {
                highlitObject = hit.transform;
                HighlightObject(highlitObject);
            }
        }
        else if(highlitObject != null)
        {
            highlitObject.GetComponent<Interactible>().DeHighlightSelf();
        }
    }

    void HighlightObject(Transform hitTransform)
    {

        Debug.Log("Highlighting Object");
        Interactible hitObjectScript = hitTransform.GetComponent<Interactible>();

        if (hitObjectScript != null)
        {
            hitObjectScript.HighlightSelf();
        }
        else
        {
            Debug.Log("Interactible object has no Script!");
        }
    }
}
