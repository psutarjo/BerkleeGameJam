using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueBox : MonoBehaviour
{    
    // parameters ////////////////////////////////////////
    public float duration = 3; // how long does each line last on screen

    // object containers /////////////////////////////////
    public GameObject Textbox; // should be a text mesh pro text box


    // show dialogue /////////////////////////////////////
    public void ShowDialogue(string newDialogue) {
        Textbox.GetComponent<TextMeshProUGUI>().text = newDialogue;
        StartCoroutine(ShowTimedDialogue());
    }
    
    
    // timer routine /////////////////////////////////////
    private IEnumerator ShowTimedDialogue() {
        float startTime = Time.time;
        while (Time.time - startTime <= 3) {
            yield return null;
        }
        Textbox.SetActive(false);
    }
}
