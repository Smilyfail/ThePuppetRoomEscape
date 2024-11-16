using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour
{

    [SerializeField] GameObject mainMenuPanel;
    [SerializeField] GameObject settingPanel;

    // Start is called before the first frame update
    void Start()
    {

        mainMenuPanel.SetActive(true);
        settingPanel.SetActive(false);
        
    }


        public void openSettingPanel()
        {

            mainMenuPanel.SetActive(false);
            settingPanel.SetActive(true);

    }

    public void openMainMenuPanel()
    {

        mainMenuPanel.SetActive(true);
        settingPanel.SetActive(false);

    }

    public void startGame()
    {

        SceneManager.LoadScene(1);

    }
}
