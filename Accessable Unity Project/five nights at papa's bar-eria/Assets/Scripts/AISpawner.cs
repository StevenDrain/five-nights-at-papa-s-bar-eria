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
    void Update()
    {
        if (currentCustomers < maxCustomers)
        {
            Instantiate(customer, spawnPoint.position, spawnPoint.rotation);
            currentCustomers++;
        }
    }
}
