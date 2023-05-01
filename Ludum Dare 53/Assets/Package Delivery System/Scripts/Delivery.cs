using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Provides the basic things for the delivery.
/// </summary>
[System.Serializable]
public class Delivery
{
    public Transform deliveryPoint;
    public List<Package> packages = new();
    public int deliveredPackages = 0;

    // Public Methods
    public void Start()
    {
        if (!deliveryPoint || packages.Count <= 0) return;

        deliveryPoint.gameObject.SetActive(false);
        ShowPackage(0);
    }

    public void ShowNextPackage()
    {
        deliveredPackages++;

        // check all packages picked
        if (packages.Count <= 0)
        {
            deliveryPoint.gameObject.SetActive(true);
            return;
        }

        ShowPackage(0);
    }

    public void End()
    {
        deliveryPoint = null;
        packages.Clear();
        deliveredPackages = 0;
    }

    // Private Methods
    private void ShowPackage(int index)
    {
        for (int i = 0; i < packages.Count; i++)
        {
            if (i == index) packages[i].Show();
            else packages[i].Hide();
        }
    }
}
