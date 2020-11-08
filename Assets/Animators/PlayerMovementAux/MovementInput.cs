using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementInput : MonoBehaviour
{
    // components //////////////////////////////////////////////////////////////////
    private Animator myAnimator;
    private GameObject myCamera;

    // key settings ////////////////////////////////////////////////////////////////
    public KeyCode forward = KeyCode.W;
    public KeyCode backward = KeyCode.S;
    public KeyCode left = KeyCode.A;
    public KeyCode right = KeyCode.D;

    // parameter settings //////////////////////////////////////////////////////////
    public float xSensitivity;
    public float ySensitivity;
    public float forwardSpeed;
    public float leftSpeed;
    public float interactRange;
    public LayerMask runeLayer;

    // animator trigger collections ////////////////////////////////////////////////
    private Dictionary<KeyCode, string> movementTriggers;


    // system messages /////////////////////////////////////////////////////////////
    void Start()
    {
        myAnimator = gameObject.GetComponent<Animator>();
        myCamera = GameObject.FindWithTag("MainCamera");

        // initialize movement trigger dictionary
        movementTriggers = new Dictionary<KeyCode, string>();
        movementTriggers.Add(forward, "W");
        movementTriggers.Add(backward, "S");
        movementTriggers.Add(left, "A");
        movementTriggers.Add(right, "D");

        //// initialize mouse position
        //lastMousePos = (Vector2)Input.mousePosition;
    }

    void Update()
    {
        // update movement keys
        ResetAnimator();
        foreach (KeyCode i in CheckMovementInput()) {
            myAnimator.SetBool(movementTriggers[i], true);
            myAnimator.SetBool("MovePressed", true);
        }

        CheckClickInput();
    }

    private void LateUpdate() {
        // TODO: differentiate mouse positions
        float xDiff = Input.GetAxis("Mouse X");
        float yDiff = Input.GetAxis("Mouse Y");

        // TODO: update horizontal movement
        gameObject.transform.Rotate(new Vector3(0, xDiff * xSensitivity, 0));
        // TODO: update vertical movement
        myCamera.transform.Rotate(new Vector3(-yDiff * ySensitivity, 0, 0));
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

    private GameObject CheckClickInput() { // sending clicking and hovering messages
        // I'm assuing there's only one object in contact with player
        RaycastHit hit;
        bool isClicking = Input.GetMouseButton(0);
        if (Physics.Raycast(myCamera.transform.position, myCamera.transform.forward, out hit, Mathf.Infinity, runeLayer)) {
            // if it's in "touching range"
            if (hit.distance <= interactRange) {
                Clickable hovered = hit.collider.gameObject.GetComponent<Clickable>();
                if (isClicking) {
                    hovered.Click();
                }
                else {
                    hovered.Hover();
                }

                return hit.collider.gameObject;
            }
        }
        else {
            Debug.Log("no hit");
        }

        return null;
    }
}
