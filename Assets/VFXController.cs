using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class VFXController : MonoBehaviour
{
    [SerializeField]
    public VisualEffect visualEffect;
    
    [SerializeField]
    private float spawnRate = 0;

    [SerializeField]
    private float particleSize = 0;

    [SerializeField]
    private float trailLife = 0;
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
