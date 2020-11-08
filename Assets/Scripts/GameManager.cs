using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;


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
}
