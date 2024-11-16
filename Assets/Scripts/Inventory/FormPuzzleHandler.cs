using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FormPuzzleHandler : MonoBehaviour
{
    [SerializeField] List<GameObject> pressedShapes, correctShapes;
    [SerializeField] GameObject door;

    public void TryAddShape(GameObject shape)
    {
        if(correctShapes.Contains(shape))
        {
            pressedShapes.Add(shape);

            if (pressedShapes.Count == 4)
            {
                //Maybe play successful sound
                GameObject.Destroy(door);
            }
        }
        else
        {
            //TODO: play unsuccessful sound
            pressedShapes = new List<GameObject>();
        }
    }
}
