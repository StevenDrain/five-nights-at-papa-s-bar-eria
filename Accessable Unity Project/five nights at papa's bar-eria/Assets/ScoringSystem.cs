using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using System;


public class ScoringSystem : MonoBehaviour
{
    public int mulitiplierScore;
    public int regScore;
    public int score;
    private string srtingScore;

    public TMP_Text text;
    // Start is called before the first frame update
    void Start()
    {
        mulitiplierScore = 0;
    }

    // Update is called once per frame
    void Update()
    { 
        score = mulitiplierScore + regScore;
        srtingScore = score.ToString();
        text.text = "Score: " + srtingScore;
        ;
    }
   public void KeyDestroyed()
    {
        mulitiplierScore += 1;
    }
}
