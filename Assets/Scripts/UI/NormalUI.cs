using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalUI : MonoBehaviour
{
    // object containers
    public GameObject journalUI;
    
    // system messages ///////////////////////////////////////////////
    void Update()
    {
        if (Input.GetKeyDown(Settings.instance.toggleJournal)) {
            // close self
            gameObject.SetActive(false);

            // open journal
            journalUI.GetComponent<JournalUI>().OpenJournal();
        }
    }
}
