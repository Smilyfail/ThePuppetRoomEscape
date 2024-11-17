using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowRecipe : AdditionalInteraction
{

    [SerializeField] GameObject player;
    [SerializeField] Camera cam;
    [SerializeField] GameObject recipe;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetKeyDown(KeyCode.Escape) && recipe.activeInHierarchy)
        {

            player.GetComponent<PlayerMovement>().enabled = true;
            cam.GetComponent<CameraMovement>().enabled = true;
            recipe.SetActive(false);

        }

    }

    override public void Act()
    {


        player.GetComponent<PlayerMovement>().enabled = false;
        cam.GetComponent<CameraMovement>().enabled = false;
        recipe.SetActive(true);
        

    }
}
