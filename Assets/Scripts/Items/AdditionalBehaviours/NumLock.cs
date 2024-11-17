using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using TMPro;
using UnityEngine;

public class NumLock : AdditionalInteraction
{
    private bool isInputtingCombination = true;
    [SerializeField] TMP_InputField numbercombination;
    [SerializeField] GameObject inputField;
    private string rightcombination = "213241";
    [SerializeField] GameObject player, door;
    [SerializeField] Camera cam;


    override public void Act()
    {
        isInputtingCombination = true;
        inputField.SetActive(true);
        numbercombination.text = "";

        player.GetComponent<PlayerMovement>().enabled = false;
        cam.GetComponent<CameraMovement>().enabled = false;
    }

    private void Update()
    {
        if (isInputtingCombination && numbercombination.text.Length == 6 && Input.GetKeyDown(KeyCode.Return))
        {
            if (numbercombination.text == rightcombination)
            {
                Destroy(door);
                // or
                player.transform.position = new Vector3(1f, 0.4f, 1.132f);
                isInputtingCombination = false;
                inputField.SetActive(false);
                player.GetComponent<PlayerMovement>().enabled = true;
                cam.GetComponent<CameraMovement>().enabled = true;

            }
            else 
            {
                numbercombination.text = "";
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isInputtingCombination = false;
            inputField.SetActive(false);

            player.GetComponent<PlayerMovement>().enabled = true;
            cam.GetComponent<CameraMovement>().enabled = true;
        }
    }
}