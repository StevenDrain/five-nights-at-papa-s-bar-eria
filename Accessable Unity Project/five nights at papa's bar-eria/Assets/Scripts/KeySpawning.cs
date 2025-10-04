using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeySpawning : MonoBehaviour
{
    public Transform[] Spawners;
    

    public GameObject Key;

    public Vector3 KeySize;
    void Start()
    {
        StartCoroutine(DelayedLoop());
    }
    IEnumerator DelayedLoop()
    {
        for (int i = 0; i < 30; i++) 
        {
            Debug.Log("Iteration " + (i + 1) + " started at: " + Time.time);

            KeySize = new Vector3(1,1,Random.Range(0.5f,10f));

            yield return new WaitForSeconds(3.5f);
            Key.transform.localScale = KeySize;
            Instantiate(Key, Spawners[Random.Range(0,3)].position , Spawners[Random.Range(0,3)].rotation);
        }
        Debug.Log("Loop completed!");
    }
    // Update is called once per frame
    void Update()
    {
       
    }
}
