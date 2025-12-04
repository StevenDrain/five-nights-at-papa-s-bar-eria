using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer : MonoBehaviour
{
    [SerializeField] private GameObject[] spots;
    [SerializeField] private float speed = 2f;
    private Transform targetSpot;
    private static HashSet<int> occupiedSpots = new HashSet<int>();
    private int mySpotIndex = -1;

    public bool served = false;
    private bool drinkRequested = false;
    [SerializeField] private GameObject request;
    [SerializeField] private GameObject beer;
    [SerializeField] private GameObject shot;
    [SerializeField] private GameObject wine;
    [SerializeField] private GameObject martini;
    public bool beerRequested = false;
    public bool shotRequested = false;
    public bool wineRequested = false;
    public bool martiniRequested = false;

    public GameObject player;

    void Start()
    {
        spots = new GameObject[8];
        for (int i = 0; i < 8; i++)
        {
            spots[i] = GameObject.Find((i + 1).ToString());
        }
        ChooseSpot();
        player = GameObject.FindGameObjectWithTag("Player");
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
                givenDrink();
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
        // Find an available spot
        List<int> availableSpots = new List<int>();
        for (int i = 0; i < spots.Length; i++)
        {
            if (!occupiedSpots.Contains(i))
            {
            availableSpots.Add(i);
            }
        }

        if (availableSpots.Count > 0)
        {
            // Randomly pick from available spots
            int randomIndex = Random.Range(0, availableSpots.Count);
            mySpotIndex = availableSpots[randomIndex];
            occupiedSpots.Add(mySpotIndex);
            targetSpot = spots[mySpotIndex].transform;
        }
        else
        {
            // All spots occupied, start coroutine to wait
            StartCoroutine(WaitForAvailableSpot());
        }
        }

        IEnumerator WaitForAvailableSpot()
        {
        while (true)
        {
            for (int i = 0; i < spots.Length; i++)
            {
            if (!occupiedSpots.Contains(i))
            {
                mySpotIndex = i;
                occupiedSpots.Add(mySpotIndex);
                targetSpot = spots[mySpotIndex].transform;
                yield break;
            }
            }
            yield return new WaitForSeconds(0.5f);
        }
    }

    void requestDrink()
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

    void givenDrink()
    {
        if (served == true)
        {
            request.SetActive(false);
            Destroy(gameObject, 1f);
        }
    }
}
