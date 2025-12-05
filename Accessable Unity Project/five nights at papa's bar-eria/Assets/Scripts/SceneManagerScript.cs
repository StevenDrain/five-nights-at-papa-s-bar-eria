using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;


public class SceneManagerScript : MonoBehaviour
{
    public string MainSceneName;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartGame()
    {
        SceneManager.LoadScene(MainSceneName);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
