using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controls the player package pickup and delivery.
/// </summary>
public class PlayerPackage : MonoBehaviour
{
    private Package package;

    private void OnTriggerEnter(Collider other)
    {
        // player collide the package
        if (other.TryGetComponent(out package))
        {
            package.Hide(true);
            DeliveryManager.Instance.ShowNextPackage(package);
            package = null;
        }

        // player collide the delivery point
        if (other.gameObject.CompareTag("DeliveryPoint"))
        {
            DeliveryManager.Instance.DeliveryComplete();
            other.gameObject.SetActive(false);
        }
    }
}
