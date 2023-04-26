using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextButton : MonoBehaviour
{
    public void Next()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.buildIndex + 1);
    }
    // public void NextPanel()
    // {
    //     Scene scene = SceneManager.GetActiveScene();
    //     SceneManager.LoadScene(scene.buildIndex);
    // }
}
