using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class BackToMenu : MonoBehaviour
{
    public void Back() {
        SceneLoader.instance.BackToMenu();
    }
}
