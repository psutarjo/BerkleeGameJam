using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class PortalManager : MonoBehaviour
{
    public VisualEffect portalEffect;
    public GameObject unlockRune;


    private AudioSource m_audioSource;

    void Start() {
        m_audioSource = GetComponent<AudioSource>();
    }


    // triggering ////////////////////////////////////////////
    private void OnTriggerEnter(Collider other) {

        // Check if player has corresponding rune
        if (GameManager.instance.CheckRune(unlockRune.GetInstanceID().ToString()))
        {
            // disable collider
            gameObject.GetComponent<Collider>().isTrigger = true;
            
        }

    }
}
