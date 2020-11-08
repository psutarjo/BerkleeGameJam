using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Clickable : MonoBehaviour
{
    // interfaces /////////////////////////////////////////////////////
    public abstract void Click();
    public abstract void Hover();
}
