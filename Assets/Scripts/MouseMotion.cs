using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMotion : MonoBehaviour
{
    public float xSensitivity = 100;
    public float ySensitivity = 100;

    public Transform playerBody;

    public LayerMask runeLayer;

    public float interactRange;

    private float xRotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float xDiff = Input.GetAxis("Mouse X") * xSensitivity;
        float yDiff = Input.GetAxis("Mouse Y") * ySensitivity;

        xRotation -= yDiff;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * xDiff);

        CheckClickInput();
    }

    private GameObject CheckClickInput() { // sending clicking and hovering messages
        // I'm assuing there's only one object in contact with player
        RaycastHit hit;
        bool isClicking = Input.GetMouseButton(0);
        if (Physics.Raycast(transform.position, transform.forward, out hit, interactRange, runeLayer)) {
            Clickable hovered = hit.collider.gameObject.GetComponent<Clickable>();
            if (isClicking) {
                hovered.Click();
            }
            else {
                hovered.Hover();
            }

            return hit.collider.gameObject;
        }
        else {
            Debug.Log("no hit");
        }

        return null;
    }
}
