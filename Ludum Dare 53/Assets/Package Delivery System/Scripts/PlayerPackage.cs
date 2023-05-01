using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controls the player package pickup and delivery.
/// </summary>
public class PlayerPackage : MonoBehaviour
{
    private Package package;
    public ParticleSystem ps;

    private void OnTriggerEnter(Collider other)
    {
        // player collide the package
        if (other.TryGetComponent(out package))
        {
            ps.Play(true);
            FindObjectOfType<soundmanager>().play("pickup");
            package.Hide(true);
            DeliveryManager.Instance.ShowNextPackage(package);
            package = null;
        }

        // player collide the delivery point
        if (other.gameObject.CompareTag("DeliveryPoint"))
        {
            ps.Play(true);
            FindObjectOfType<soundmanager>().play("drop");
            DeliveryManager.Instance.DeliveryComplete();
            other.gameObject.SetActive(false);
        }
    }
}
