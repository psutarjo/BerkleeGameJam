using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnPoint : MonoBehaviour
{
    // public /////////////////////////////////////////////////////////////////////////////
    public GameObject respawnPoint;

    // private ////////////////////////////////////////////////////////////////////////////


    // trigger functions //////////////////////////////////////////////////////////////////
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag != "Player") {
            return;
        }

        Debug.Log("collide");

        Vector3 newPosition = new Vector3(0, 0, 0);
        newPosition += other.gameObject.transform.localPosition - transform.position
            + respawnPoint.transform.position; // the position of player when sent back to respawn

        Debug.Log(newPosition);

        // teleport
        other.gameObject.GetComponent<CharacterController>().enabled = false;
        other.gameObject.transform.localPosition = newPosition;
        other.gameObject.GetComponent<CharacterController>().enabled = true;
    }
}
