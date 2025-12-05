using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using System;


public class ScoringSystem : MonoBehaviour
{
    public float multiplierScore;
    public float baseScore;
    public float totalScore;

    public TMP_Text text;
    private SceneManagerScript sceneManagerScript;

    void Start()
    {
        var sceneManagerObject = GameObject.FindWithTag("sceneManager");
        sceneManagerScript = sceneManagerObject.GetComponent<SceneManagerScript>();

        baseScore = 0;
        multiplierScore = 1;
        totalScore = 0;
    }

    void Update()
    {
        text.text = "Score: " + totalScore;
        if(totalScore >= 500)
        {
            WinGame();
        }
        
    }

    public void KeyDestroyed()
    {
        multiplierScore += 0.5f;

        // Add to the total score using the multiplier
        totalScore += baseScore * multiplierScore;
    }

    public void CustomerServed()
    {
        baseScore += 1;
        totalScore += baseScore * multiplierScore;
    }

    public void ResetMultiplier()
    {
        multiplierScore = 0;
    }
    public void WinGame(){
        sceneManagerScript.StartGame();
    }
}