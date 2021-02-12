using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class Rune : Clickable
{
    public GameObject rune;
    public VisualEffect runeEffect;

    private AudioSource m_audioSource;
    public string myKey;
    
    // clicking and hovering ///////////////////////////////////////////
    public override void Click() {
       if (GameManager.instance.CheckRune(myKey) == false)
       {
            Disappear();
            Debug.Log("Rune is Clicked");
       }
    }

    public override void Hover() {
        Debug.Log("rune is hovered upon");
    }


    // aux functions ///////////////////////////////////////////////////
    private void Disappear() {
        // Terminate rune spawn rate
       runeEffect.SetFloat("Spawn Rate", 0);
       //  Unlock rune
       GameManager.instance.UnlockRune(myKey);
       //  Stop rune sound effect
       m_audioSource.Stop();
    }


    // system messages /////////////////////////////////////////////////
    void Start()
    {
        // myKey = rune.GetInstanceID().ToString();
        m_audioSource = GetComponent<AudioSource>();
        GameManager.instance.RegisterRune(myKey);
    }
}
