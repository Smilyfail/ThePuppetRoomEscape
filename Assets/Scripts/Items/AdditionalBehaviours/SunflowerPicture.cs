using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunflowerPicture : AdditionalInteraction
{
    [SerializeField] GameObject door;
    public override void Act()
    {
        Destroy(door);
    }
}
