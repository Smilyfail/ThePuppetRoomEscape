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
    private bool fixedCamera;
    private int pillCounter;

    public Vector3 fixedPosition = new Vector3(0f, 10f, -10f);
    public Vector3 fixedRotation = new Vector3(45f, 0f, 0f);


    // Start is called before the first frame update
    void Start()
    {

        movement.enabled = false;
        camera.enabled = false;
        fixedCamera = true;
        pillCounter = 3;
        pillCounterText.text = "Pill counter: " + pillCounter;
        setCameraToFixedPerspective();

    }

    // Update is called once per frame
    void Update()
    {

        if (fixedCamera && pillCounter > 0)
        {

            if (Input.GetKeyDown(KeyCode.E))
            {

                pillCounter--;
                switchToFirstPerson();
                StartCoroutine(startPlayerTime(10f));

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

    private IEnumerator startPlayerTime(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        switchToFixedPerspective();
    }

    private void setCameraToFixedPerspective()
    {

        mainCamera.transform.position = fixedPosition;
        mainCamera.transform.rotation = Quaternion.Euler(fixedRotation);

    }
}
