using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class JournalUI : MonoBehaviour
{
    // object containers ////////////////////////////////////////////
    public GameObject journalTextBox; // should be a text mesh pro
    public GameObject NormalUIObj; // the "Normal UI" object in canvas

    // keyboard settings ////////////////////////////////////////////


    // system messages //////////////////////////////////////////////
    private void Update() {
        // TODO: input logic
        if (Input.GetKeyDown(nextKey)) {
            NextPage();
        }
        else if (Input.GetKeyDown(prevKey)) {
            NextPage(true);
        }
        else if (Input.GetKeyDown(toggleKey)) {
            CloseJournal();
        }
    }


    // game manager message /////////////////////////////////////////
    public void AddJournalEntry(string newEntry) { // add the new entry into list
        journalTextBox.GetComponent<TextMeshProUGUI>().text += newEntry;
        journalTextBox.GetComponent<TextMeshProUGUI>().text += "\n\n";
    }


    // open, close and turn page ////////////////////////////////////
    public void OpenJournal() {
        // the game manager calls this method to show journal
        
        // TODO: play sound

        // activate self
        gameObject.SetActive(true);
    }

    public void CloseJournal() {
        // called when journal is closed
        
        // TODO: play sound

        // deactivate self
        gameObject.SetActive(false);

        // active normal UI
        NormalUIObj.SetActive(true);
    }

    public void NextPage(bool reverse = false) {
        // call this method to turn page, reverse=true means to turn backwards
        int maxPage = journalTextBox.GetComponent<TextMeshProUGUI>().textInfo.pageCount;

        // TODO: play sound

        // next page
        if (!reverse && journalTextBox.GetComponent<TextMeshProUGUI>().pageToDisplay < maxPage) {
            journalTextBox.GetComponent<TextMeshProUGUI>().pageToDisplay++;
        }
        // previous page
        else if (reverse && journalTextBox.GetComponent<TextMeshProUGUI>().pageToDisplay > 1) {
            journalTextBox.GetComponent<TextMeshProUGUI>().pageToDisplay--;
        }
    }
}
