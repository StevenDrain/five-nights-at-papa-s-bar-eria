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
    void Start()
    {
        rb = GetComponent<Rigidbody>();
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
            //Update Score
            //hold down key for the length of the key
            Destroy(gameObject);

        }
        if (other.gameObject.tag == "Dead")
        {
            Destroy(gameObject);
        }
    }
}
