using UnityEngine;

public class LookAt : MonoBehaviour
{
    private RaycastHit hit;
    private float interactionRange = 10f;
    private string interactibleTag = "Interactible";
    Camera cam;
    Transform highlitObject;
    private string interactionKey = "e";

    // Start is called before the first frame update
    void Start()
    {
        cam = gameObject.GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(cam.transform.position, cam.transform.forward * interactionRange, Color.red);
        if(Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, interactionRange) && hit.distance < interactionRange && hit.transform.CompareTag(interactibleTag))
        {
            highlitObject = hit.transform;
            HighlightObject(highlitObject);
        }

        else if(highlitObject != null)
            Destroy(highlitObject.GetComponent<Outline>());

        if(Input.GetKeyUp(interactionKey) && highlitObject.CompareTag(interactibleTag))
            highlitObject.GetComponent<Interactible>().Inspect();

    }

    void HighlightObject(Transform hitTransform)
    {
        if(hitTransform.GetComponent<Outline>() == null) 
        { 
            var outline = hitTransform.gameObject.AddComponent<Outline>();

            outline.OutlineMode = Outline.Mode.OutlineAll;
            outline.OutlineColor = Color.cyan;
            outline.OutlineWidth = 5f;
        }
    }
}
