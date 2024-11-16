using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FormPuzzle : AdditionalInteraction
{
    [SerializeField] FormPuzzleHandler handler;

    public override void Act()
    {
        handler.TryAddShape(gameObject);
    }
}
