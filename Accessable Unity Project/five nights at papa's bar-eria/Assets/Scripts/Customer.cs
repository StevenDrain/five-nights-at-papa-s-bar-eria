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
    private bool drinkRequested = false;
    public GameObject request;
    public GameObject beer;
    public GameObject shot;
    public GameObject wine;
    public GameObject martini;
    private bool beerRequested = false;
    private bool shotRequested = false;
    private bool wineRequested = false;
    private bool martiniRequested = false;

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

                if (drinkRequested == false)
                {
                    requestDrink();
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

    void requestDrink()
    {
        
        if (served == true)
        {
            return;
        }
        else
        {
            Debug.Log("Requesting Drink");
            int drinkType = Random.Range(1, 5); // 1 to 4 inclusive
            request.SetActive(true);

            // Activate the selected drink
            switch (drinkType)
            {
                case 1:
                    if (beer != null) beer.SetActive(true);
                    beerRequested = true;
                    break;
                case 2:
                    if (shot != null) shot.SetActive(true);
                    shotRequested = true;
                    break;
                case 3:
                    if (wine != null) wine.SetActive(true);
                    wineRequested = true;
                    break;
                case 4:
                    if (martini != null) martini.SetActive(true);
                    martiniRequested = true;
                    break;
            }
            drinkRequested = true;
        }
    }
}
