using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;

public class SceneLoader : MonoBehaviour
{
    public static SceneLoader instance = null;
    
    // scenes marked by names ///////////////////////////////////////
    public string gameScene;
    public string endScene;
    public string menuScene;


    // transition settings //////////////////////////////////////////
    public float transitionTime;


    // states ///////////////////////////////////////////////////////
    private bool isLoading = false;


    // scene change animation ///////////////////////////////////////
    [SerializeField] private Image blackImage = null;


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
        LoadSceneWithName(gameScene);
    }

    public void EndGame() {
        LoadSceneWithName(menuScene);
    }

    public void BackToMenu() {
        LoadSceneWithName(menuScene);
    }

    private void LoadSceneWithName(string sceneName) {
        if (isLoading) return;
        StartCoroutine(LoadSceneWithAnimation(sceneName));
    }


    private IEnumerator LoadSceneWithAnimation(string sceneName) {
        isLoading = true;
        GameManager.instance.interactionOn = false;

        blackImage.gameObject.SetActive(true);

        float newAlpha = 0;

        while (newAlpha < 1) {

            newAlpha += Time.deltaTime / transitionTime * 1;

            Color tempColor = blackImage.color;
            tempColor.a = Mathf.Min(255, newAlpha);
            blackImage.color = tempColor;

            yield return null;
        }

        SceneManager.LoadScene(sceneName);

        while (newAlpha > 0) {

            newAlpha -= Time.deltaTime / transitionTime * 1;

            Color tempColor = blackImage.color;
            tempColor.a = Mathf.Max(newAlpha, 0);
            blackImage.color = tempColor;


            yield return null;
        }

        blackImage.gameObject.SetActive(false);

        isLoading = false;
        GameManager.instance.interactionOn = true;
    }
}
