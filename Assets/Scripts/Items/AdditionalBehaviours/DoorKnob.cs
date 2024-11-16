using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorKnob : AdditionalInteraction
{

    [SerializeField] GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    override public void Act()
    {

        //either
        //trigger opening animation
        //or
        player.transform.position = new Vector3(-1.18f, 0.436f, 2.29f);
        
    }
}
