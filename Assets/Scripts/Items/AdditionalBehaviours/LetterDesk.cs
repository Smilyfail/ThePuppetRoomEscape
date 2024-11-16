using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.UI;

public class LetterDesk : AdditionalInteraction
{

    [SerializeField] Inventory inventory;
    private bool isSortingLetters;
    [SerializeField] GameObject player;
    [SerializeField] Camera cam;

    [SerializeField] GameObject letter1;
    [SerializeField] GameObject letter2;
    [SerializeField] GameObject letter3;
    [SerializeField] GameObject letter4;
    [SerializeField] GameObject letter5;

    [SerializeField] GameObject tutorialText;
    [SerializeField] GameObject doorKnob;

    void Start()
    {

        doorKnob.GetComponent<Interactible>().enabled = false;

    }

    
    void Update()
    {
        
    }


    override public void Act()
    {
    
        player.GetComponent<PlayerMovement>().enabled = false;
        cam.GetComponent<CameraMovement>().enabled = false;
        cam.transform.position = Vector3.zero;

        if(inventory.isFull())
        {
            isSortingLetters = true;
            doorKnob.GetComponent<Interactible>().enabled = true;

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

            isSortingLetters = false;
            player.GetComponent<PlayerMovement>().enabled = true;
            cam.GetComponent<CameraMovement>().enabled = true;
        }


    }
}
