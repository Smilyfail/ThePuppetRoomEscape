using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using TMPro;
using UnityEngine;

public class NumLock : AdditionalInteraction
{
    private bool isInputtingCombination = true;
    [SerializeField] TMP_InputField numbercombination;
    private string rightcombination = "123456";
    [SerializeField] GameObject player, door;
    [SerializeField] Camera cam;

    override public void Act()
    {
        isInputtingCombination = true;
        numbercombination.enabled = true;

        player.GetComponent<PlayerMovement>().enabled = false;
        cam.GetComponent<CameraMovement>().enabled = false;
    }

    private void Update()
    {
        if (isInputtingCombination && numbercombination.text.Length == 6)
        {
            if (numbercombination.text == rightcombination)
            {
                Destroy(door);
            }
            else 
            {
                numbercombination.text = "";
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isInputtingCombination = false;
            numbercombination.enabled = false;

            player.GetComponent<PlayerMovement>().enabled = true;
            cam.GetComponent<CameraMovement>().enabled = true;
        }
    }
}