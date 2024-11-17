using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorKnobBathroom : AdditionalInteraction
{

    [SerializeField] Transform player;
    public override void Act()
    {
        player.position = new Vector3(-3.96300006f, 0.43599999f, -1.05999994f);
    }
}
