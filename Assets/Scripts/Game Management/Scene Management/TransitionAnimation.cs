using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TransitionAnimation : MonoBehaviour
{

    [SerializeField] private GameObject blackImage = null;

    private void Start() {
        blackImage.SetActive(false);
    }

    public void Reset() {
        
    }
}
