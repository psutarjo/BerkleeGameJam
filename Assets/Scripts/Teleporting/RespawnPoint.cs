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

        Vector3 newPosition = other.gameObject.transform.position - transform.position
            + respawnPoint.transform.position; // the position of player when sent back to respawn

        Debug.Log(newPosition);

        // teleport
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.transform.position = newPosition;
    }
}
