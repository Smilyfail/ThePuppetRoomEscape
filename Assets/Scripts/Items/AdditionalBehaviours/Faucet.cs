using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Faucet : AdditionalInteraction
{
    [SerializeField] GameObject mirror, foggedMirror;
    [SerializeField, Header("Add all That can be interacted with after here")] GameObject[] activatableObjects;
    private readonly string interactibleTag = "Interactible";

    public override void Act()
    {
        foreach (var obj in activatableObjects)
            obj.tag = interactibleTag;

        mirror.SetActive(false);
        foggedMirror.SetActive(true);
    }
}
