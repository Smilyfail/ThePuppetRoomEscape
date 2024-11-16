using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.UI;

public class LetterDesk : AdditionalInteraction
{

    [SerializeField] Inventory inventory;
    public bool isSortingLetters;
    private bool collectedAll;
    [SerializeField] GameObject player;
    [SerializeField] Camera cam;
    [SerializeField] GameObject letterMoveable;
    [SerializeField] GameObject tutorialText;
    [SerializeField] GameObject doorKnob;

    void Start()
    {

        doorKnob.GetComponent<Interactible>().enabled = false;
        doorKnob.tag = ("Untagged");
        collectedAll = false;
        isSortingLetters = false;

    }

    
    void Update()
    {
        
    }


    override public void Act()
    {
    
        player.GetComponent<PlayerMovement>().enabled = false;
        cam.GetComponent<CameraMovement>().enabled = false;
        cam.transform.position = new Vector3(3.32f, 1.39f, 0.97f);
        cam.transform.rotation = Quaternion.Euler(54.194f, 180.657f, 0f);

        if (inventory.isFull())
        {
            isSortingLetters = true;
            doorKnob.GetComponent<Interactible>().enabled = true;
            doorKnob.tag = ("Interactible");
            inventory.clearInventory();
            letterMoveable.SetActive(true);
            collectedAll = true;


        } else if (collectedAll) {

            isSortingLetters = true;

        } else
        {
            tutorialText.SetActive(true);

        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(tutorialText.activeInHierarchy)
            {
                tutorialText.SetActive(false);
            }

            player.GetComponent<PlayerMovement>().enabled = true;
            cam.GetComponent<CameraMovement>().enabled = true;
            isSortingLetters = false;
        }


    }
}
