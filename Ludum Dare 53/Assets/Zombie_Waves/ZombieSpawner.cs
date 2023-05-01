using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    [SerializeField] GameObject Zombie;
    [SerializeField] int maxX;
    [SerializeField] int maxZ;
    [SerializeField] int ZombieCount;
    [SerializeField] int MaxZombies;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(SpawnEnemies());
    }
    IEnumerator SpawnEnemies()
    {
        while (ZombieCount < MaxZombies)
        {
            maxX = Random.Range(200,800);
            maxZ = Random.Range(200,800);
            Instantiate(Zombie, new Vector3(maxX, 0, maxZ), Quaternion.identity);
            ZombieCount += 1;
            yield return new WaitForSeconds(5);
            
        }
    }
}
