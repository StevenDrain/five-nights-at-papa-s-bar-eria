using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer : MonoBehaviour
{
    public GameObject[] spots;
    public float speed = 2f;
    private Transform targetSpot;
    private static HashSet<int> occupiedSpots = new HashSet<int>();
    private int mySpotIndex = -1;

    private bool served = false;
    public GameObject request;

    void Start()
    {
        spots = new GameObject[8];
        for (int i = 0; i < 8; i++)
        {
            spots[i] = GameObject.Find((i + 1).ToString());
        }
        ChooseSpot();
    }

    void Update()
    {
        if (targetSpot != null)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, targetSpot.position, step);

            if (Vector3.Distance(transform.position, targetSpot.position) < 0.01f)
            {
                if (served == false)
                {
                    requestBeer();
                }
                
            }
        }
    }

    void OnDestroy()
    {
        if (mySpotIndex != -1)
        {
            occupiedSpots.Remove(mySpotIndex);
        }
    }

    void ChooseSpot()
    {
        for (int i = 0; i < spots.Length; i++)
        {
            if (!occupiedSpots.Contains(i))
            {
                occupiedSpots.Add(i);
                mySpotIndex = i;
                targetSpot = spots[i].transform;
                break;
            }
        }
    }

    void requestBeer()
    {
        bool beerRequested = false;

        if (beerRequested == true)
        {
            if(served == true) {
                
            }
            return;
        }
        else
        {
            request.SetActive(true);
            beerRequested = true;
        }
    }
}
