using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeySpawning : MonoBehaviour
{
    public Transform[] Spawners;
    

    public GameObject Key;
    Renderer KeyR;

   public Vector3 KeySize;
   public int SpawnerRandom;
   public Material ZeroColor;
   public Material OneColor;
   public Material TwoColor;
   public Material ThreeColor;
    void Start()
    {
        StartCoroutine(DelayedLoop());
        KeyR = Key.GetComponent<Renderer>();

    }
    IEnumerator DelayedLoop()
    {
        for (int i = 0; i < 30; i++) 
        {
            Debug.Log("Iteration " + (i + 1) + " started at: " + Time.time);

            KeySize = new Vector3(1,1,Random.Range(0.5f,10f));
            SpawnerRandom = Random.Range(0, 4);
            yield return new WaitForSeconds(3.5f);
            Key.transform.localScale = KeySize;
            Instantiate(Key, Spawners[SpawnerRandom].position , Spawners[Random.Range(0,3)].rotation);
        }
        Debug.Log("Loop completed!");
    }
    // Update is called once per frame
    void Update()
    {
        if (SpawnerRandom == 3)
        {
            KeyR.material = ThreeColor;
        }
        else if (SpawnerRandom == 2)
        {
            KeyR.material = TwoColor;
        }
        else if (SpawnerRandom == 1)
        {
            KeyR.material = OneColor;
        }
        else if (SpawnerRandom == 0)
        {
            KeyR.material = ZeroColor;
        }
       
       
    }
}
