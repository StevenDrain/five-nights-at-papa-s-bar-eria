using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AISpawner : MonoBehaviour
{
    public GameObject customer;
    public Transform spawnPoint;
    public int maxCustomers = 1;
    private int currentCustomers = 0;

    // Update is called once per frame
    public float spawnInterval = 10f; // Time in seconds between spawns
    private float spawnTimer = 0f;

    void Update()
    {
        if (currentCustomers < maxCustomers)
        {
            spawnTimer += Time.deltaTime;
            if (spawnTimer >= spawnInterval)
            {
                Instantiate(customer, spawnPoint.position, spawnPoint.rotation);
                currentCustomers++;
                spawnTimer = 0f;
            }
        }
    }
}
