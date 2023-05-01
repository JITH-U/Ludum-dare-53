using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// <summary>
/// Manages the delivery system such as provide delivery jobs, keep track how many delivery completes.
/// </summary>
public class DeliveryManager : MonoBehaviour
{
    public static DeliveryManager Instance { get; private set; }

    [Header("References")]
    [SerializeField] private Transform[] packagePoints;
    [SerializeField] private Transform[] deliveryPoints;
    [SerializeField] private Package packagePrefab;

    [Header("Delivery Info")]
    [SerializeField] private Delivery currentDelivery;
    [SerializeField] private int minPackages = 1;
    [SerializeField] private int maxPackages = 4;
    [SerializeField] private int timeBtnDelivery = 5;             

    [Header("UI")]
    [SerializeField] private TMP_Text packagesText;
    [SerializeField] private TMP_Text deliveredText;
    [SerializeField] private TMP_Text infoText;
    [SerializeField] private TMP_Text deliveryTimerText;

    // Private variables
    private int packagesCount = 0;
    private int deliveryDone = 0;
    [HideInInspector] private readonly List<Transform> tempPackagePoints = new();
    [HideInInspector] private int index;
    [HideInInspector] private Package spawnedPackage;
    private float timer;
    [HideInInspector] private bool isDeliveryDone;

    private void Awake()
    {
        // make singleton
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(Instance);
    }

    private void Start()
    {
        // initailize variables
        index = -1;
        packagesCount = 0;
        infoText.gameObject.SetActive(false);
        timer = timeBtnDelivery;
        isDeliveryDone = true;
        deliveryTimerText.gameObject.SetActive(false);

        // deactivate all the delivery points
        for (int i = 0; i < deliveryPoints.Length; i++)
            deliveryPoints[i].gameObject.SetActive(false);
    }

    private void Update()
    {
        // start a new delivery
        if (isDeliveryDone)
        {
            timer -= Time.deltaTime;
            deliveryTimerText.text = $"Delivery Arrived In {(int)timer}s";
            deliveryTimerText.gameObject.SetActive(true);
            if (timer <= 0)
            {
                isDeliveryDone = false;
                timer = timeBtnDelivery;
                deliveryTimerText.gameObject.SetActive(false);
                CreateNewDelivery();
            }
        }

        //// test
        //if (Input.GetKeyDown(KeyCode.Space))
        //    CreateNewDelivery();
    }

    // Public Methods
    public void ShowNextPackage(Package package)
    {
        currentDelivery.packages.Remove(package);
        currentDelivery.ShowNextPackage();

        // update UI
        packagesText.text = $"{currentDelivery.deliveredPackages}/{packagesCount}";
    }

    public void DeliveryComplete()
    {
        // reset variables
        packagesCount = 0;
        tempPackagePoints.Clear();

        // destroy uncolleted packages
        for (int i = 0; i < currentDelivery.packages.Count; i++)
            Destroy(currentDelivery.packages[i].gameObject);

        currentDelivery.End();
        deliveryDone++;
        Invoke(nameof(StartNewDelivery), 4);        // wait 2 sec before start new delivery

        // update UI
        packagesText.text = $"0/0";
        deliveredText.text = $"Delivered: {deliveryDone}";

        infoText.text = "Delivery Completed!";
        infoText.gameObject.SetActive(true);
        Invoke(nameof(DisableInfo), 2);
    }

    // Private Methods
    private void CreateNewDelivery()
    {
        // initialize temppackagepoints
        tempPackagePoints.Clear();
        for (int i = 0; i < packagePoints.Length; i++)
            tempPackagePoints.Add(packagePoints[i].transform);

        // choose one random delivery point and how many packages needs to collects for that delivery
        index = Random.Range(0, deliveryPoints.Length);
        currentDelivery.deliveryPoint = deliveryPoints[index];
        packagesCount = Random.Range(minPackages, maxPackages + 1);

        // spawn random package prefab at the random package point
        for (int i = 0; i < packagesCount; i++)
        {
            index = Random.Range(0, tempPackagePoints.Count);
            spawnedPackage = Instantiate(packagePrefab);
            spawnedPackage.transform.position = tempPackagePoints[index].position;

            currentDelivery.packages.Add(spawnedPackage);
            tempPackagePoints.RemoveAt(index);
        }

        // update UI
        packagesText.text = $"0/{packagesCount}";

        // start the delivery
        currentDelivery.Start();
        tempPackagePoints.Clear();

        infoText.text = "Delivery Started!";
        infoText.gameObject.SetActive(true);
        Invoke(nameof(DisableInfo), 2);
    }

    private void DisableInfo()
    {
        infoText.gameObject.SetActive(false);
    }

    private void StartNewDelivery()
    {
        isDeliveryDone = true;
    }
}