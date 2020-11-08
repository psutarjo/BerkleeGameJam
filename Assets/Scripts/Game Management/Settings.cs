using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings : MonoBehaviour
{
    public static Settings instance;

    // journal settings ////////////////////////////////////////////////////
    public KeyCode nextJournal = KeyCode.RightArrow;
    public KeyCode prevJournal = KeyCode.LeftArrow;
    public KeyCode toggleJournal = KeyCode.Tab;

    // system messages //////////////////////////////////////////////////////
    void Awake() {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(this);
    }
}
