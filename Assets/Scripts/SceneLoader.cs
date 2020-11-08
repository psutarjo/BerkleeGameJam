using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public static SceneLoader instance = null;
    
    // scenes marked by names ///////////////////////////////////////
    public string gameScene;


    // system message ///////////////////////////////////////////////
    void Awake() {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(this);
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    
    // scenes ///////////////////////////////////////////////////////
    public void StartGame() {
        SceneManager.LoadScene(gameScene);
    }
}
