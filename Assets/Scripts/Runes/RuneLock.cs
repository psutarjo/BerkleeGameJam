using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuneLock : MonoBehaviour
{
    public string myKey = "theRune";

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.CheckRune(myKey)) {
            RuneUnlock();
        }
    }


    // virtual: unlock function /////////////////////////////////////////
    public virtual void RuneUnlock() {}
}
