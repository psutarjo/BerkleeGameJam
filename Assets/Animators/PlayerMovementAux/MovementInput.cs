using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementInput : MonoBehaviour
{
    private Animator myAnimator;

    // key settings ////////////////////////////////////////////////////////////////
    public KeyCode forward = KeyCode.W;
    public KeyCode backward = KeyCode.S;
    public KeyCode left = KeyCode.A;
    public KeyCode right = KeyCode.D;


    // animator trigger collections ////////////////////////////////////////////////
    private Dictionary<KeyCode, string> movementTriggers;


    // system messages /////////////////////////////////////////////////////////////
    void Start()
    {
        myAnimator = gameObject.GetComponent<Animator>();

        // initialize movement trigger dictionary
        movementTriggers = new Dictionary<KeyCode, string>();
        movementTriggers.Add(forward, "W");
        movementTriggers.Add(backward, "S");
        movementTriggers.Add(left, "A");
        movementTriggers.Add(right, "D");
    }

    void Update()
    {
        // update movement keys
        ResetAnimator();
        foreach (KeyCode i in CheckMovementInput()) {
            myAnimator.SetBool(movementTriggers[i], true);
            myAnimator.SetBool("MovePressed", true);
        }

        // TODO: update facing direction
            // TODO: update horizontal movement
            // TODO: update vertical movement
    }


    // aux functions ///////////////////////////////////////////////////////////////
    private List<KeyCode> CheckMovementInput() { // check and return the pressed movement key
        List<KeyCode> results = new List<KeyCode>();
        results.Clear();
        foreach (KeyCode i in new KeyCode[] { forward, backward, left, right }) {
            if (Input.GetKey(i)) {
                results.Add(i);
            }
        }

        return results;
    }

    private void ResetAnimator() { // set all movement input bools false
        foreach (string i in new string[] {"W", "S", "A", "D"}) {
            myAnimator.SetBool(i, false);
        }
        myAnimator.SetBool("MovePressed", false);
    }
}
