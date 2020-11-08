using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMotion : MonoBehaviour
{
    public float xSensitivity = 100;
    public float ySensitivity = 100;

    public Transform playerBody;

    private float xRotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float xDiff = Input.GetAxis("Mouse X") * xSensitivity * Time.deltaTime;
        float yDiff = Input.GetAxis("Mouse Y") * ySensitivity * Time.deltaTime;

        xRotation -= yDiff;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * xDiff);
    }
}
