using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Faucet : AdditionalInteraction
{
    [SerializeField] GameObject[] activatableObjects;
    private string interactibleTag = "Interactible";

    public override void Act()
    {
        foreach (var obj in activatableObjects)
            obj.tag = interactibleTag;
    }
}
