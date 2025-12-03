using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public float speed = 3f;
    private Rigidbody rb;
    public Vector3 direction = Vector3.forward;

    private ScoringSystem scoringSystemScript;

    private float keyLength;
    private bool isInsideClear;
    private bool wasScored;

    private Vector3 enterPosition;
    private float traveledDistance;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        var scoringSystem = GameObject.FindWithTag("Score");
        scoringSystemScript = scoringSystem.GetComponent<ScoringSystem>();

        keyLength = transform.localScale.z;
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + (-direction * speed * Time.fixedDeltaTime));

        if (isInsideClear)
        {
            
            traveledDistance = Vector3.Distance(enterPosition, transform.position);

            if (traveledDistance >= keyLength && !wasScored)
            {
                wasScored = true;
                scoringSystemScript.KeyDestroyed();
                Destroy(gameObject);
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Clear"))
        {
            isInsideClear = true;
            enterPosition = transform.position;
            traveledDistance = 0;
        }

        if (other.CompareTag("Dead"))
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Clear"))
        {
            isInsideClear = false;

            if (!wasScored)
            {
                scoringSystemScript.multiplierScore = 0;
            }
        }
    }

    void OnDestroy()
    {
        if (!wasScored)
        {
            scoringSystemScript.ResetMultiplier();
        }
    }
}