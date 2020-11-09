using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class SceneLoader : MonoBehaviour
{
    public static SceneLoader instance = null;
    
    // scenes marked by names ///////////////////////////////////////
    public string gameScene;
    public string endScene;
    public string menuScene;


    // system message ///////////////////////////////////////////////
    void Awake() {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(this);
    }

    
    // scenes ///////////////////////////////////////////////////////
    public void StartGame() {
        SceneManager.LoadScene(gameScene);
    }

    public void EndGame() {
        SceneManager.LoadScene(endScene);
    }

    public void BackToMenu() {
        SceneManager.LoadScene(menuScene);
    }
}
