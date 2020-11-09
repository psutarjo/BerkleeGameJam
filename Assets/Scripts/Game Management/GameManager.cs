using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    // progress trackers /////////////////////////////////////////////////////
    // TODO: rune progress
    public Dictionary<string, bool> runes;

    // object containers /////////////////////////////////////////////////////
    public GameObject mainDialogueBox;
    public GameObject mainJournal;


    // system messages ///////////////////////////////////////////////////////
    void Awake() {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(this);
    }


    // scene loading messages ///////////////////////////////////////////////
    public void StartGame() {
        // load the first scene
        SceneLoader.instance.StartGame();
    }


    // story trigger handles ////////////////////////////////////////////////
    public void RegisterNewTrigger(string dialogue, string journal) { // called whenever a trigger is triggered
        // show dialogue
        mainDialogueBox.GetComponent<DialogueBox>().ShowDialogue(dialogue);
        // add journal entry
        mainJournal.GetComponent<JournalUI>().AddJournalEntry(journal);
    }

    
    // rune system //////////////////////////////////////////////////////////
    public void RegisterRune(string key, bool initial = false) {
        runes.Add(key, initial);
    }

    public void UnlockRune(string key) {
        if (runes.ContainsKey(key)) {
            runes[key] = true;
        }
    }

    public bool CheckRune(string key) {
        return (runes.ContainsKey(key) && runes[key] == true);
    }
}
