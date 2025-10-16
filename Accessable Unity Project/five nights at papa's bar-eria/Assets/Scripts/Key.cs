using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Key : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 3f;
    Rigidbody rb;
    public Vector3 direction = Vector3.forward;
    private GameObject scoringSystem;
    public ScoringSystem scoringSystemScript;
    bool wasScored;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        scoringSystem = GameObject.FindWithTag("Score");
        scoringSystemScript = scoringSystem.GetComponent<ScoringSystem>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + (-direction * speed * Time.fixedDeltaTime));
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Clear")
        {
            wasScored = true; // <-- Use flag instead of tag
            Destroy(gameObject);
        }
        if (other.gameObject.tag == "Dead")
        {
            Destroy(gameObject);
        }
    }

    void OnDestroy()
    {
        if (wasScored)
        {
            scoringSystemScript.KeyDestroyed();
        }
        else
        {
            scoringSystemScript.mulitiplierScore = 0;
        }
    }
}

