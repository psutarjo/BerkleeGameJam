using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JournalUI : MonoBehaviour
{
    // object containers ////////////////////////////////////////////
    public GameObject journalTextBox; // should be a text mesh pro

    // separate data structure to store each line of story //////////
    private List<string> entries;

    // remember last page ///////////////////////////////////////////


    // system messages //////////////////////////////////////////////
    private void Awake() {
        entries = new List<string>();
        entries.Clear();
    }

    private void Update() {
        // TODO: input logic
    }


    // game manager message /////////////////////////////////////////
    public void AddJournalEntry(string newEntry) { // add the new entry into list
        entries.Add(newEntry);
    }


    // open, close and turn page ////////////////////////////////////
    public void OpenJournal() {
        // TODO: the game manager calls this method to show journal
    }

    public void CloseJournal() {
        // TODO: called when journal is closed
    }

    public void NextPage(bool reverse = false) {
        // TODO: call this method to turn page, reverse=true means to turn backwards
    }
}
