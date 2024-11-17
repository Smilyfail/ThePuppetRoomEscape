using System.Collections.Generic;
using UnityEngine;

public class FormPuzzleHandler : MonoBehaviour
{
    [SerializeField] List<GameObject> pressedShapes, correctShapes, allShapes;
    [SerializeField] GameObject player;

    public void TryAddShape(GameObject shape)
    {
        if(correctShapes.Contains(shape))
        {
            pressedShapes.Add(shape);

            if (pressedShapes.Count == 4)
            {
                //Maybe play successful sound
                foreach (GameObject shapeObject in allShapes)
                    shapeObject.tag = "Untagged";
                player.transform.position = new Vector3(-0.602999985f, 0.43599999f, -4.54400015f);
            }
        }
        else
        {
            //TODO: play unsuccessful sound
            pressedShapes = new List<GameObject>();
        }
    }
}
