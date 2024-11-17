using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunflowerPicture : AdditionalInteraction
{
    [SerializeField] GameObject youWonScreen;

    public override void Act()
    {

        youWonScreen.SetActive(true);
        Time.timeScale = 0;

    }
}
