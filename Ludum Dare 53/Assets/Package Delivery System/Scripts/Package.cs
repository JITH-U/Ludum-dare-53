using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controls the behaviour of the basic package.
/// </summary>
public class Package : MonoBehaviour
{
    // Public Methods
    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide(bool destory = false)
    {
        gameObject.SetActive(false);
        if (destory) Destroy(gameObject);
    }
}
