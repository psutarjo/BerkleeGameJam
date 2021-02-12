using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelPortal : RuneLock
{
    private bool unlocked = false;

    [SerializeField] private GameObject portalDest = null;
    
    public override void RuneUnlock() {
        if (unlocked) return;

        unlocked = true;
    }

    private void OnTriggerEnter(Collider other) {
        if (!unlocked || other.gameObject.tag != "Player") return;

        Vector3 newPosition = portalDest.transform.position;

        // teleport
        other.gameObject.GetComponent<CharacterController>().enabled = false;
        other.gameObject.transform.localPosition = newPosition;
        other.gameObject.GetComponent<CharacterController>().enabled = true;
    }
}
