using UnityEngine;

public class Faucet : AdditionalInteraction
{
    [SerializeField] GameObject helpText;
    [SerializeField, Header("Add all That can be interacted with after here")] GameObject[] activatableObjects;
    private readonly string interactibleTag = "Interactible";

    public override void Act()
    {
        foreach (var obj in activatableObjects)
            obj.tag = interactibleTag;

        helpText.gameObject.SetActive(true);
    }
}
