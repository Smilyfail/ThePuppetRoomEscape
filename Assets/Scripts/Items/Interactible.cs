using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interactible : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HighlightSelf()
    {
        var outline = gameObject.AddComponent<Outline>();

        outline.OutlineMode = Outline.Mode.OutlineAll;
        outline.OutlineColor = Color.cyan;
        outline.OutlineWidth = 5f;
    }

    public void DeHighlightSelf()
    {
        Destroy(gameObject.GetComponent<Outline>());
    }
}
