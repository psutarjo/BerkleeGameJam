using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEfxPlayer : MonoBehaviour
{
    public string myKey = "someSound";
    
    
    // system messages //////////////////////////////////////////////////////
    private void Update() {
        // on load: register self to game manager
        GameManager.instance.RegisterSoundMixer(myKey, gameObject);
    }
}
