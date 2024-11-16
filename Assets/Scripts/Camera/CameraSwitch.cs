using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraSwitch : MonoBehaviour

{

    [SerializeField] PlayerMovement movement;
    [SerializeField] CameraMovement camera;
    [SerializeField] GameObject pillText;
    [SerializeField] TextMeshPro pillCounterText;
    [SerializeField] GameObject gameOverScreen;
    private bool fixedCamera;
    private int pillCounter;


    // Start is called before the first frame update
    void Start()
    {

        movement.enabled = false;
        camera.enabled = false;
        fixedCamera = true;
        pillCounter = 3;
        pillCounterText.text = "Pill counter: " + pillCounter;
        
    }

    // Update is called once per frame
    void Update()
    {

        if(fixedCamera && pillCounter > 0)
        {

            if (Input.GetKeyDown(KeyCode.E))
            {

                pillCounter--;
                switchToFirstPerson();
                StartCoroutine(startPlayerTime(10f));

            }
        }

        if(pillCounter == 0)
        {

            gameOverScreen.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {

                SceneManager.LoadScene(1);

            }
            if (Input.GetKeyDown(KeyCode.Escape))
            {

                SceneManager.LoadScene(0);

            }

        }



        
    }

    private void switchToFirstPerson()
    {

        movement.enabled = true;
        camera.enabled = true;
        fixedCamera = false;

    }

    private void switchToFixedPerspective()
    {

        pillCounterText.text = "Pill counter: " + pillCounter;
        movement.enabled = false;
        camera.enabled = false;
        fixedCamera = true;


    }

    private IEnumerator startPlayerTime(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        switchToFixedPerspective();
    }

}
