using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextButton : MonoBehaviour
{
    Scene scene;
    private void OnEnable() 
    {
        scene = SceneManager.GetActiveScene();
    }
    public void Next()
    {
        SceneManager.LoadScene(scene.buildIndex + 1);
    }
    // public void NextPanel()
    // {
    //     Scene scene = SceneManager.GetActiveScene();
    //     SceneManager.LoadScene(scene.buildIndex);
    // }
}
