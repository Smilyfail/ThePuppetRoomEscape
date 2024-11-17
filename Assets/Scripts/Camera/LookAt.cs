using UnityEngine;

public class LookAt : MonoBehaviour
{
    private RaycastHit hit;
    private float interactionRange = 1f;
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
        //Debug.DrawRay(cam.transform.position, cam.transform.forward * interactionRange, Color.red);
        Ray ray = cam.ScreenPointToRay(new Vector3(cam.pixelWidth / 2f, cam.pixelHeight / 2f, 0f));

        if (Physics.Raycast(ray, out hit, interactionRange) &&
            hit.distance < interactionRange &&
            hit.transform.CompareTag(interactibleTag))
        {
            highlitObject = hit.transform;
            HighlightObject(highlitObject);
        }

        else if(highlitObject != null)
            Destroy(highlitObject.GetComponent<Outline>());

        if(Input.GetKeyUp(KeyCode.E) && highlitObject != null && highlitObject.CompareTag(interactibleTag))
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
