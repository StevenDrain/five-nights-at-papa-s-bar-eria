using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerOneController : MonoBehaviour
{
    
    [SerializeField] private CharacterController playerController;
    [SerializeField] private InputActionReference movement;
    [SerializeField] private int speed;
    private Vector3 movementDirection;

    [SerializeField] private GameObject BeerCounter;
    [SerializeField] private GameObject WineCounter;
    [SerializeField] private GameObject ShotCounter;
    [SerializeField] private GameObject MartiniCounter;
    bool hasDrink = false;
    [SerializeField] private GameObject hands;
    public bool hasBeer = false;
    public bool hasWine = false;
    public bool hasShot = false;
    public bool hasMartini = false;
    private int score;

    // Start is called before the first frame update
    void Start()
    {
        movement.action.Enable();
    }

    void Update()
    {
        PlayerMovement();
        PickupDrink();
        dropDrink();
        ServeDrink();
    }

    void PlayerMovement()
    {

        Vector2 inputDirection = movement.action.ReadValue<Vector2>();
        movementDirection = new Vector3(inputDirection.x, 0, inputDirection.y);
        playerController.Move(movementDirection * speed * Time.deltaTime);
        if (movementDirection != Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(
                transform.rotation,
                Quaternion.LookRotation(movementDirection),
                0.15f
            );
        }
    }

    void PickupDrink()
    {
        float pickupRange = 2.0f; // Adjust as needed
        if (Keyboard.current.eKey.wasPressedThisFrame)
        {
            if (hasDrink)
            {
                Debug.Log("Already holding a drink!");
                return;
            }

            if (Vector3.Distance(transform.position, BeerCounter.transform.position) < pickupRange)
            {
                Debug.Log("Picked up Beer!");
                // Instantiate a beer from the child of BeerCounter
                if (BeerCounter.transform.childCount > 0)
                {
                    GameObject beerPrefab = BeerCounter.transform.GetChild(0).gameObject;
                    GameObject beerInstance = Instantiate(beerPrefab, hands.transform.position, hands.transform.rotation, hands.transform);
                    beerInstance.SetActive(true);
                    beerInstance.transform.localScale = beerPrefab.transform.localScale;
                }
                hasDrink = true;
                hasBeer = true;

            }
            else if (Vector3.Distance(transform.position, WineCounter.transform.position) < pickupRange)
            {
                Debug.Log("Picked up Wine!");
                // Instantiate a wine from the child of WineCounter
                if (WineCounter.transform.childCount > 0)
                {
                    GameObject winePrefab = WineCounter.transform.GetChild(0).gameObject;
                    GameObject wineInstance = Instantiate(winePrefab, hands.transform.position, hands.transform.rotation, hands.transform);
                    wineInstance.SetActive(true);
                    wineInstance.transform.localScale = winePrefab.transform.localScale;
                }
                hasDrink = true;
                hasWine = true;
            }
            else if (Vector3.Distance(transform.position, ShotCounter.transform.position) < pickupRange)
            {
                Debug.Log("Picked up Shot!");
                // Instantiate a shot from the child of ShotCounter
                if (ShotCounter.transform.childCount > 0)
                {
                    GameObject shotPrefab = ShotCounter.transform.GetChild(0).gameObject;
                    GameObject shotInstance = Instantiate(shotPrefab, hands.transform.position, hands.transform.rotation, hands.transform);
                    shotInstance.SetActive(true);
                    shotInstance.transform.localScale = shotPrefab.transform.localScale;
                }
                hasDrink = true;
                hasShot = true;
            }
            else if (Vector3.Distance(transform.position, MartiniCounter.transform.position) < pickupRange)
            {
                Debug.Log("Picked up Martini!");
                // Instantiate a martini from the child of MartiniCounter
                if (MartiniCounter.transform.childCount > 0)
                {
                    GameObject martiniPrefab = MartiniCounter.transform.GetChild(0).gameObject;
                    GameObject martiniInstance = Instantiate(martiniPrefab, hands.transform.position, hands.transform.rotation, hands.transform);
                    martiniInstance.SetActive(true);
                    martiniInstance.transform.localScale = martiniPrefab.transform.localScale;
                }
                hasDrink = true;
                hasMartini = true;
            }
        }
    }

    void dropDrink() {
        //Drops drink when space is pressed
        if(Keyboard.current.spaceKey.wasPressedThisFrame) {
            if(hasDrink) {
                Debug.Log("dropped drink");
                hasDrink = false;
                hasBeer = false;
                hasWine = false;
                hasShot = false;
                hasMartini = false;
                foreach (Transform child in hands.transform)
                {
                    Destroy(child.gameObject);
                }
            }
        }
    }

    void ServeDrink()
    {
        if (Keyboard.current.eKey.wasPressedThisFrame)
        {
            float serveRange = 3.0f; // Adjust as needed
            // Find all customers in the scene
            GameObject[] customers = GameObject.FindGameObjectsWithTag("Customer");
            GameObject nearestCustomer = null;
            float minDistance = Mathf.Infinity;

            // Find the nearest customer within serveRange
            foreach (GameObject cust in customers)
            {
                float dist = Vector3.Distance(transform.position, cust.transform.position);
                if (dist < serveRange && dist < minDistance)
                {
                    minDistance = dist;
                    nearestCustomer = cust;
                }
            }

            if (nearestCustomer == null)
            {
                Debug.Log("No customer nearby to serve!");
                return;
            }

            if (hasDrink)
            {
                var customerScript = nearestCustomer.GetComponent<Customer>();
                if (hasBeer && customerScript.beerRequested)
                {
                    Debug.Log("Served Beer!");
                    foreach (Transform child in hands.transform)
                    {
                        Destroy(child.gameObject);
                    }
                    hasDrink = false;
                    hasBeer = false;
                    customerScript.served = true;
                    score += 10;
                    Debug.Log("score: " + score);
                }
                else if (hasWine && customerScript.wineRequested)
                {
                    Debug.Log("Served Wine!");
                    foreach (Transform child in hands.transform)
                    {
                        Destroy(child.gameObject);
                    }
                    hasDrink = false;
                    hasWine = false;
                    customerScript.served = true;
                    score += 10;
                    Debug.Log("score: " + score);
                }
                else if (hasShot && customerScript.shotRequested)
                {
                    Debug.Log("Served Shot!");
                    foreach (Transform child in hands.transform)
                    {
                        Destroy(child.gameObject);
                    }
                    hasDrink = false;
                    hasShot = false;
                    customerScript.served = true;
                    score += 10;
                    Debug.Log("score: " + score);
                }
                else if (hasMartini && customerScript.martiniRequested)
                {
                    Debug.Log("Served Martini!");
                    foreach (Transform child in hands.transform)
                    {
                        Destroy(child.gameObject);
                    }
                    hasDrink = false;
                    hasMartini = false;
                    customerScript.served = true;
                    score += 10;
                    Debug.Log("score: " + score);
                }
                else
                {
                    Debug.Log("Wrong drink or no request!");
                }
            }
            else
            {
                Debug.Log("No drink to serve!");
            }
        }
    }
}

