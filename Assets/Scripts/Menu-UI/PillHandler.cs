using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PillHandler : MonoBehaviour
{
    [SerializeField] PlayerMovement movement;
    [SerializeField] CameraMovement camera;
    [SerializeField] GameObject pillText;
    [SerializeField] TextMeshProUGUI pillCounterText;
    [SerializeField] GameObject gameOverScreen;
    [SerializeField] Camera mainCamera;
    [SerializeField] GameObject pauseMenu;

    private bool fixedCamera;
    private int pillCounter;

    private float timer;
    private bool timerActive;

    public Vector3 fixedPosition = new Vector3(0f, 10f, -10f);
    public Vector3 fixedRotation = new Vector3(45f, 0f, 0f);


    // Start is called before the first frame update
    void Start()
    {


        fixedCamera = true;
        pillCounter = 3;
        pillCounterText.text = "Pill counter: " + pillCounter;
        setCameraToFixedPerspective();
        movement.enabled = false;
        camera.enabled = false;
        timer = 0;
        timerActive = false;

    }

    // Update is called once per frame
    void Update()
    {

        if (fixedCamera && pillCounter > 0 && !pauseMenu.activeSelf)
        {

            if (Input.GetKeyDown(KeyCode.E))
            {

                pillCounter--;
                switchToFirstPerson();
                startTimer(10f);

            }
        }

        if (pillCounter == 0 && fixedCamera == true)
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

        if (timerActive)
        {
            timer -= Time.deltaTime;

            if (timer <= 0f)
            {
                switchToFixedPerspective();
                timerActive = false;
            }


        }
    }

    private void switchToFirstPerson()
    {

        movement.enabled = true;
        camera.enabled = true;
        fixedCamera = false;
        pillText.SetActive(false);

    }

    private void switchToFixedPerspective()
    {

        pillText.SetActive(true);
        pillCounterText.text = "Pill counter: " + pillCounter;
        movement.enabled = false;
        camera.enabled = false;
        fixedCamera = true;
        setCameraToFixedPerspective();


    }


    private void startTimer(float duration)
    {
        timer = duration;
        timerActive = true;
    }

    private void setCameraToFixedPerspective()
    {

        mainCamera.transform.position = fixedPosition;
        mainCamera.transform.rotation = Quaternion.Euler(fixedRotation);

    }
}
