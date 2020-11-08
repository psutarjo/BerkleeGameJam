using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryTrigger : MonoBehaviour
{
    // story text ////////////////////////////////////////////
    public string dialogue;
    public string journal;

    // status ////////////////////////////////////////////////
    public bool isTriggered = false;

    // object container //////////////////////////////////////
    public Collider cd;


    // triggering ////////////////////////////////////////////
    private void OnTriggerEnter(Collider other) {
        if (!isTriggered && other.gameObject.tag == "Player") {
            isTriggered = true;

            // talk to game manager
            GameManager.instance.RegisterNewTrigger(dialogue, journal);

            gameObject.SetActive(false);
        }
    }
}
