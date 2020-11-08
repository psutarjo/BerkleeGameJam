using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rune : Clickable
{
    // clicking and hovering ///////////////////////////////////////////
    public override void Click() {
        LightUp();
    }

    public override void Hover() {
        Debug.Log("rune is hovered upon");
    }

    // aux functions ///////////////////////////////////////////////////
    private void LightUp() {
        // TODO: fill this function with actual functionality
        Debug.Log("rune is clicked");
    }


    // system messages /////////////////////////////////////////////////
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
