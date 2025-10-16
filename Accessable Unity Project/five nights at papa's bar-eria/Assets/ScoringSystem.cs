using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoringSystem : MonoBehaviour
{
    public int mulitiplierScore;
    // Start is called before the first frame update
    void Start()
    {
        mulitiplierScore = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(mulitiplierScore);
    }
   public void KeyDestroyed()
    {
        mulitiplierScore += 1;
    }
}
